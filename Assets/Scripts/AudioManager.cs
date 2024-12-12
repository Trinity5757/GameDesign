using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{

    // Declare the AudioSource variable
    public AudioSource backgroundMusic;
    public AudioSource collisionSound;
    public AudioSource bowRelease;
    public AudioSource click;
    public AudioSource winNoise;
    public AudioSource looseNoise;

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
        if(collisionSound != null)
        {
            collisionSound.Play();
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

    public void PlayBowRelease()
    {
        if(bowRelease != null)
        {
            bowRelease.Play();
        }
    }

}
