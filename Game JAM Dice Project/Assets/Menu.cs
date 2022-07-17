using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour
{
    public void Play()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    public void HowToPlay()
    {
        GameObject.Find("CanvasMenu").GetComponent<Canvas>().enabled = false;
        GameObject.Find("CanvasRules").GetComponent<Canvas>().enabled = true;
    }
    
    public void QuitHowToPlay()
    {
        GameObject.Find("CanvasMenu").GetComponent<Canvas>().enabled = true;
        GameObject.Find("CanvasRules").GetComponent<Canvas>().enabled = false;
    }
}

//GameObject.Find("Enemies") .enabled = true;
//GameObject.Find("CanvasMenu").GetComponent<Canvas>().enabled = true;
//GameObject.Find("CanvasRules").GetComponent<Canvas>().enabled = true;