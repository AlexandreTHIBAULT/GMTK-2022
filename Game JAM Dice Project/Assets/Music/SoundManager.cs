using System.Collections;
using System.Collections.Generic;
using UnityEngine.Audio;
using UnityEngine;


public class SoundManager : MonoBehaviour
{
    public AudioClip gameOverClip;
    public AudioClip diceRolling;
    public AudioClip diceDeath;
    public AudioClip greenAttack;
    public AudioClip redAttack;
    public AudioClip blueAttack;


    [HideInInspector] public AudioSource audio;
    [HideInInspector] public DiceColorDetector colorDetector;
    

    // Start is called before the first frame update
    void Start()
    {
        audio = GetComponent<AudioSource>();
        colorDetector = GameObject.Find("PlayerDice").GetComponent<DiceColorDetector>();


    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void playSoundGameOver()
    {
        audio.clip = gameOverClip;
        audio.PlayOneShot(audio.clip, 0.75f);
        PlaySoundDiceDeath();
        
    }

    public void PlaySoundDiceRolling()
    {
        audio.PlayOneShot(diceRolling, 1.5f);
    }

    public void PlaySoundDiceDeath()
    {
        audio.PlayOneShot(diceDeath, 1);
    }

    public void PlaySoundAttack()
    {
        if (colorDetector.currentColor == ColorEnum.Red)
        {
            audio.PlayOneShot(redAttack, 1);
        }
        else if (colorDetector.currentColor == ColorEnum.Green)
        {
            audio.PlayOneShot(greenAttack, 1);
        }
        else if (colorDetector.currentColor == ColorEnum.Blue)
        {
            audio.PlayOneShot(blueAttack, 1);
        }
    }
    
}
