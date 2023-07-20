using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Pause : MonoBehaviour
{
    bool isPaused = false;
    public GameObject pausePanel;
    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Escape) && isPaused == false){
            PauseGame();
        }
        else if(Input.GetKeyDown(KeyCode.Escape) && isPaused == true){
            Resume();
        }
    }

    public void Quit(){
        Application.Quit();
        Debug.Log("Quit");
    }
//evan
    public void PauseGame(){
        Time.timeScale = 0;
        isPaused = true;
        pausePanel.SetActive(true);
    }

    public void Resume(){
        Time.timeScale = 1;
        isPaused = false;
        pausePanel.SetActive(false);
    }

    public void BackToStart()
    { 
        if(Time.timeScale == 0)
        {
            Time.timeScale = 1;
        }
        else{
            Debug.Log("timeScale is not 0");
        }
        
        SceneManager.LoadScene("StartScreen");
    }
}
