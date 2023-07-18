using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class move : MonoBehaviour
{
    public int speed;
    public int jumpforce;
    public Rigidbody2D rigi;


    // Start is called before the first frame update
    void Start()
    {
        
rigi=GetComponent<Rigidbody2D>();   
    }

    // Update is called once per frame
    void Update()
    {
        rigi.velocity = new Vector2(Input.GetAxisRaw("Horizontal")*speed,rigi.velocity.y);
        if (Input.GetKeyDown(KeyCode.UpArrow)) {
            rigi.AddForce(Vector2.up *jumpforce, ForceMode2D.Impulse);
        }
    }
}
