using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class jumptest : MonoBehaviour
{
    public Rigidbody2D rb;
    public float jumpAmount = 10;
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space=true))
            {
                rb.AddForce(Vector2.up * jumpAmount, ForceMode2D.Impulse);
            }
    }
}