using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StartScreen : MonoBehaviour
{
    public void Play(){
        SceneManager.LoadScene("Main");
    }

    public void Quit(){
        Application.Quit();
        Debug.Log("Quit");
    }

    public void Credits(){
        if(Time.timeScale == 0)
        {
            Time.timeScale = 1;
        }
        else{
            Debug.Log("timeScale is not 0");
        }
        SceneManager.LoadScene("Credits");
    }
}
