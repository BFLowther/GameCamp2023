using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class swing : MonoBehaviour
{

    public int direction = 1;
    public float velocity = 50.0f;
        
    // Start is called before the first frame update
    void Start()
    {   
        transform.Rotate(0, 0, 270);
    }

    // Update is called once per frame
    void Update()
    {
        transform.Rotate(0, 0, velocity * direction * Time.deltaTime);
        if (transform.localEulerAngles.z >= 0 && transform.localEulerAngles.z <= 180) {
            velocity -= 1;
        } else {
            velocity += 1;
        }
        // if (direction == 1) {
        //     if (transform.localEulerAngles.z > 90 - 5 && transform.localEulerAngles.z < 90 + 5) {
        //         direction = -1;
        //     }
        // } else {
        //     if (transform.localEulerAngles.z < 270 + 5 && transform.localEulerAngles.z > 270 - 5) {
        //         direction = 1;
        //     }
        // }

        // if (transform.localEulerAngles.z > 180) {
        //     velocity += 1;
        // } else {
        //     velocity -= 1;
        // }
    }
}
