using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : Singelton<AudioManager>
{

   public static AudioManager Instance;

    [SerializeField] AudioClip touchSound;
    [SerializeField] float touchVolume = 0.8f;

 
    public AudioSource audioSource;
    public bool bTouchSoundEnable = true;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
    }
    void Start()
    {
        DontDestroyOnLoad(this.gameObject);

        audioSource = GetComponent<AudioSource>();
    }


   public void SoundAdjust(bool ON)
    {
        if (ON)
        {
            audioSource.mute = true;
        }
        else
        {
            audioSource.mute = false;
        }
    }

    public void PlaySingleShotAudio(AudioClip audioClip, float volume)
    {
         audioSource.PlayOneShot(audioClip, volume);

    }

    public void PlayTouchSoundEffect()
    {
        if (!bTouchSoundEnable)
        {
            return;
        }
          PlaySingleShotAudio(touchSound, touchVolume);
 
    }

}
