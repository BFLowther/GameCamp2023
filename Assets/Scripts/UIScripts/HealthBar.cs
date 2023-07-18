using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using SuperPupSystems.Helper;

public class HealthBar : MonoBehaviour
{
    private Slider slider;

    public Health health;

    void Start(){
        slider = GetComponent<Slider>();
    }

    void Update(){
        slider.value = health.CurrentHealth;
    }
    
}
