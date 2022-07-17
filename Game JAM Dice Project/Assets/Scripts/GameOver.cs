using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;
public class GameOver : MonoBehaviour
{
    [HideInInspector] public Clock score;

    private TextMeshProUGUI scoreT;
    
    // Start is called before the first frame update
    void Start()
    {
        Time.timeScale = 1;

        score = GameObject.Find("GameManager").GetComponent<Clock>();
        scoreT = GameObject.Find("Score").GetComponent<TextMeshProUGUI>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void UpdateScore()
    {
        scoreT.text = "Score : "+score.score.ToString();
    }

    public void ResetGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        Debug.Log("Restart");

    }
}
