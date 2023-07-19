using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Move : MonoBehaviour
{
    public int speed;
    public int jumpforce;
    public Rigidbody2D rigi;
    public Vector2 boxSize;
    public float maxDistance;
    public LayerMask layerMask;

    // Start is called before the first frame update
    void Start()
    {
        rigi=GetComponent<Rigidbody2D>();   
    }

    // Update is called once per frame
    void Update()
    {
        rigi.velocity = new Vector2(Input.GetAxisRaw("Horizontal")*speed,rigi.velocity.y);
        if (Input.GetKeyDown(KeyCode.UpArrow) && GroundCheck()) {
            rigi.AddForce(Vector2.up * jumpforce, ForceMode2D.Impulse);
        }
    }

    private bool GroundCheck() {
    if(Physics2D.BoxCast(transform.position,boxSize,0,-transform.up,maxDistance,layerMask)) {

    return true;

} else {
    return false;
}


    } 
}
