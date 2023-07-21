using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Win : MonoBehaviour
{
    public GameObject winText;

    void OnTriggerEnter2D(Collider2D other)
    {
        Debug.Log("Test");
        if(other.gameObject.CompareTag("Player"))
        {
            winText.SetActive(true);
            Debug.Log("Win");
        }
    }
}
