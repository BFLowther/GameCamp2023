using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Move : MonoBehaviour
{
    public int speed;
    public int jumpforce;
    public Rigidbody2D rigi;

    public Vector2 boxSize;
    public Vector2 boxSizeRight;
    public Vector2 boxSizeLeft;
    public Vector2 boxSizeUp;

    public float maxDistance;
    public LayerMask layerMask;
    public SpriteRenderer Player;
    public bool rightFacing;
    public bool jumpedLastFrame;
    public Vector2 boxCastPosition;

Animator anim;
    // Start is called before the first frame update
    void Start()
    {
        rigi=GetComponent<Rigidbody2D>();
        anim=GetComponent<Animator>();
        jumpedLastFrame = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (Time.deltaTime == 0) {
            return;
        }
        if (Input.GetAxis("Horizontal") < 0.0f) {
            Player.flipX = true;
        }
        if (Input.GetAxis("Horizontal") > 0.0f) {
            Player.flipX = false;
        }


        if (Input.GetAxisRaw("Horizontal") == 0.0f) {
            anim.SetBool("Running", false);
        } else {
            rigi.velocity = new Vector2(Input.GetAxisRaw("Horizontal")*speed,rigi.velocity.y);
            anim.SetBool("Running", true);
        }
        if ((Input.GetAxis("Jump") > 0 && jumpedLastFrame == false) && GroundCheck()) {
            jumpedLastFrame = true;
        }
    }

    void FixedUpdate() {
        boxCastPosition = new Vector2 (transform.position.x,transform.position.y-1);
        if (jumpedLastFrame) {
            rigi.AddForce(Vector2.up * jumpforce * Time.fixedDeltaTime, ForceMode2D.Impulse);
            jumpedLastFrame = false; }
        if (wallCheckCeiling() && rigi.velocity.y > 0) {
            rigi.AddForce(-Vector2.up, ForceMode2D.Impulse);
        }

        }
    
    private bool GroundCheck() {
        if(Physics2D.BoxCast(boxCastPosition,boxSize,0,-transform.up,maxDistance,layerMask)) {
            return true;
        } else {
            return false;
        } 
        
    } 
    
    private bool wallCheckCeiling() {
        if(Physics2D.BoxCast(transform.position,boxSizeUp,0,transform.up,maxDistance,layerMask)) {
            return true;
        } else {
            return false;
        }
    } 
}
