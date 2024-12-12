using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{

    // Declare the AudioSource variable
    public AudioClip backgroundMusic;
    public AudioClip collisionSound;
    public AudioClip bowRelease;
    public AudioClip click;
    public AudioClip winNoise;
    public AudioClip looseNoise;

    // Start is called before the first frame update
    void Start()
    {
        //Plays the background music
        backgroundMusic.Play();
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.P))
        {
            if(backgroundMusic.isPlaying)
            {
                backgroundMusic.Pause();
            }
            else
            {
                backgroundMusic.Play();
            }
        }
    }

    public void PlayCollisionSound()
    {
        if(bowRelease != null)
        {
            bowRelease.Play();
        }
    }

    public void PlayClickSound()
    {
        if(click != null)
        {
            click.Play();
        }
    }

    public void PlayWinNoise()
    {
        if(winNoise != null)
        {
            winNoise.Play();
        }
    }

    public void PlayLooseNoise()
    {
        if(looseNoise != null)
        {
            looseNoise.Play();
        }
    }

}
