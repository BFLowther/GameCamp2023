using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Move : MonoBehaviour
{
    public int speed;
    public int jumpforce;
    public Rigidbody2D rigi;

    public Vector2 boxSize;
    public Vector2 boxSizeUp;


    public float maxDistance;
    public LayerMask layerMask;
    public SpriteRenderer Player;
    public bool rightFacing;
    public bool jumpedLastFrame;
    public Vector2 boxCastPosition;
    public bool dead = false;

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
            anim.SetBool("Running", true);
            if (Input.GetAxis("Vertical") < 0) {
                rigi.velocity = new Vector2(Input.GetAxisRaw("Horizontal") * 0.5f * speed,rigi.velocity.y);
            } else {
                rigi.velocity = new Vector2(Input.GetAxisRaw("Horizontal")*speed,rigi.velocity.y);
            }
        }
        if (((Input.GetAxis("Jump") > 0 ||  (Input.GetAxis("Vertical") > 0))&& jumpedLastFrame == false) && GroundCheck()) {
            jumpedLastFrame = true;
        }
        if (Input.GetAxis("Vertical") < 0) {
            anim.SetBool("Creeping", true);
        } else {
            anim.SetBool("Creeping", false);
        }
    }

    void FixedUpdate() {
        if (dead)
            return; 
        
        boxCastPosition = new Vector2 (transform.position.x,transform.position.y-1);
        if (jumpedLastFrame) {
            anim.SetBool("Jumping", true);
            rigi.AddForce(Vector2.up * jumpforce * Time.fixedDeltaTime, ForceMode2D.Impulse);
            jumpedLastFrame = false; }
        if (wallCheckCeiling() && rigi.velocity.y > 0) {
            rigi.AddForce(-Vector2.up, ForceMode2D.Impulse);
        }
        if (!(GroundCheck())) {
            Debug.Log("INAIR");
        } else {
            Debug.Log("ONGROUND");
            anim.SetBool("Jumping", false);
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

    public void Death()
    {
        anim.SetBool("Dying", true);
        dead = true;
    }
}
