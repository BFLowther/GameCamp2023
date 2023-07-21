using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using SuperPupSystems.Helper;

public class DamageOnContact : MonoBehaviour

{
    public int damage;
    public bool destroyAfterHit = false;

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.GetComponent<Health>()) {
            Debug.Log("damaged");
            Health h = other.gameObject.GetComponent<Health>();
            h.Damage(damage);
            if (destroyAfterHit){
                Destroy(transform.parent.gameObject, 0.5f);
            }
        }else {

        }
        
    }
}
