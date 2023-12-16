using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : Singelton<AudioManager>
{

    [SerializeField] AudioClip touchSound;
    [SerializeField] float touchVolume = 0.8f;
    AudioSource audioSource;

 

     void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }


    public void PlaySingleShotAudio(AudioClip audioClip, float volume)
    {
         audioSource.PlayOneShot(audioClip, volume);

    }

    public void PlayTouchSoundEffect()
    {       
            PlaySingleShotAudio(touchSound, touchVolume);       
    }

}
