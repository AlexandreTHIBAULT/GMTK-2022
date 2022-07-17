using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Clock : MonoBehaviour
{
    public TextMeshProUGUI clockText;
    public int clock;
    public TextMeshProUGUI scoreText;
    public int score;

    // Start is called before the first frame update
    void Start()
    {
        clock = 0;
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void UpdateClock()
    {
        clock++;
        clockText.text = clock.ToString();
    }

    public void UpdateScore()
    {
        score++;
        scoreText.text = "score : " + score.ToString();
    }
}
