using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOver : MonoBehaviour
{
    [HideInInspector] public Clock clock;
    
    // Start is called before the first frame update
    void Start()
    {
        Time.timeScale = 1;

        clock = GameObject.Find("GameManager").GetComponent<Clock>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ResetGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        Debug.Log("Restart");
    }
}
