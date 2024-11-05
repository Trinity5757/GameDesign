using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public AudioSource source;

    void Start()
    {
        audioSource.Play();
    }
    public void Stop()
    {
        audioSource.Stop();
    }
}