using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{







    AudioSource audioSource;

    void Awake()
    {
        audioSource = GetComponent<AudioSource>();
        PlayGamePlayAudio();
    }

    public void PlayGamePlayAudio()
    {
        audioSource.Play();
        audioSource.loop = true;
    }

    public void PlaySingleShotAudio(AudioClip audioClip, float volume)
    {
        audioSource.PlayOneShot(audioClip, volume);

    }




}
