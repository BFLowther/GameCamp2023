using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ResetScreen : MonoBehaviour
{
    public void Restart()
    {
        SceneManager.LoadScene("Main");
    }
}
