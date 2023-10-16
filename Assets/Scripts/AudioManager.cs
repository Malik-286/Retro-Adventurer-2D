using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : Singelton<AudioManager>
{
    AudioSource audioSource;
     void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }


    public void PlaySingleShotAudio(AudioClip audioClip, float volume)
    {
         audioSource.PlayOneShot(audioClip, volume);

    }
    
}
