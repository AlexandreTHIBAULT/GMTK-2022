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

    private Waves ennemies;

    // Start is called before the first frame update
    void Start()
    {
        clock = 5;
        ennemies = GameObject.Find("Enemies").GetComponent<Waves>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void UpdateClock()
    {
        clock--;
        clockText.text = clock.ToString();

        if (clock==0){
            clock = 6;
            ennemies.NewWave();
        }
    }

    public void UpdateScore()
    {
        score++;
        scoreText.text = "score : " + score.ToString();
    }
}
