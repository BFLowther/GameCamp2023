using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using SuperPupSystems.Helper;

public class Meat : MonoBehaviour
{
     void OnTriggerEnter2D(Collider2D other){
        if(other.CompareTag("Player")){
            other.gameObject.GetComponent<Health>().Heal(2);
        }
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

}
