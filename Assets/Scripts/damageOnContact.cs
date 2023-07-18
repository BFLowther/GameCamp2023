using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using SuperPupSystems.Helper;

public class DamageOnContact : MonoBehaviour

{
    public int damage;

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.GetComponent<Health>()) {
            Health h = collision.gameObject.GetComponent<Health>();
            h.Damage(damage);
        }
    }
}
