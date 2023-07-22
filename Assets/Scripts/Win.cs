using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using SuperPupSystems.Helper;

public class Win : MonoBehaviour
{
    public GameObject winText;
    public GameObject playerWin;
    public SpriteRenderer player;
    public SpriteRenderer prin;
    public Move move;

    void OnTriggerEnter2D(Collider2D other)
    {
        if(other.gameObject.CompareTag("Player"))
        {
            winText.SetActive(true);
            playerWin.SetActive(true);
            player.enabled = false;
            move.enabled = false;
            prin.enabled = false;

            gameObject.GetComponent<Timer>().StartTimer();
        }
    }

    public void LoadMainScene() {
        SceneManager.LoadScene("StartScreen");
    }
}
