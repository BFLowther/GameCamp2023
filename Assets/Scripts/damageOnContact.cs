using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using SuperPupSystems.Helper;

public class DamageOnContact : MonoBehaviour

{
    public int damage;
    public bool destroyAfterHit = false;
    public bool damagePause = false;
    public float coolDown = 0.2f;
    public float currentCoolDown = 0.0f;

    void Awake()
    {
        
    }

    void Start()
    {
        
    }

    void Update()
    {
        currentCoolDown -= Time.deltaTime;
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (damagePause || currentCoolDown >= 0.0f)
            return;
        
        if (other.gameObject.GetComponent<Health>()) {
            Debug.Log("damaged");
            currentCoolDown = coolDown;
            Health h = other.gameObject.GetComponent<Health>();
            h.Damage(damage);
            if (destroyAfterHit){
                Destroy(transform.parent.gameObject, 0.1f);
            }
        }else {

        }
    }
}
