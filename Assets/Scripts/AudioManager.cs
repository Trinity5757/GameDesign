using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{

    // Declare the AudioSource variable
    public AudioSource backgroundMusic;

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
}
