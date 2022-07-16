using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Clock : MonoBehaviour
{
    public Text clockText;
    public int clock;

    // Start is called before the first frame update
    void Start()
    {
        clock = 0;
        clockText = GameObject.Find("ClockText").GetComponent<Text>();
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
}
