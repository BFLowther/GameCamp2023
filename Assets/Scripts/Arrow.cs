using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Arrow : MonoBehaviour
{
    public float xspeed = 25.0f;
    public float yspeed = 0.0f;
    public int direction = 1;
    bool hitWall = false;

    Rigidbody2D rb2d;

    void Start() {
        rb2d = gameObject.GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void FixedUpdate() {
        if (hitWall || Time.fixedDeltaTime == 0.0f)
            return;
        
        rb2d.MovePosition(rb2d.position + new Vector2(direction * xspeed * Time.fixedDeltaTime, yspeed * Time.fixedDeltaTime));
        if (xspeed > 0) {xspeed -= 0.1f * direction;}
        yspeed -= 0.025f;
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (!other.gameObject.CompareTag("Player")) {
            hitWall = true;
            if (gameObject.GetComponentInChildren<DamageOnContact>()) {
                Destroy(gameObject.GetComponentInChildren<DamageOnContact>());
            }
        }
    }
}
