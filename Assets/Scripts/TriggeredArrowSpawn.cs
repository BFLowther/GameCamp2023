using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggeredArrowSpawn : MonoBehaviour
{

    public GameObject arrow;
    public int direction = 1;
    public bool vertical = false;

    public int launchStrength = 25;

    // Start is called before the first frame update
    void Start()
    {
        // InvokeRepeating("SpawnArrow", 0f, cooldown);
    }

    // Update is called once per frame
    void SpawnArrow()
    {
        GameObject clone = Instantiate(arrow, transform.position, transform.rotation);
        if (!vertical) {
            clone.GetComponent<Arrow>().xspeed = launchStrength; clone.GetComponent<Arrow>().yspeed = 1;
            clone.GetComponent<Arrow>().direction = direction;  
            Destroy(clone, 5f);
        } else {
            clone.GetComponent<Arrow>().xspeed = 0; clone.GetComponent<Arrow>().yspeed = launchStrength * direction;
            clone.GetComponent<Arrow>().direction = direction;
            Destroy(clone, 5f);
        }
    }
}
