using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class AudioMenu : MonoBehaviour
{
    public AudioClip boum;
    public AudioSource audio;
    // Staat is called before the first frame update
    void Start()
    {
        audio = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void tambour()
    {
        audio.PlayOneShot(boum, 1);
    }
}
