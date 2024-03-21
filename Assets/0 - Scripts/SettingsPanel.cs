using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class SettingsPanel : MonoBehaviour
{

    [SerializeField] Slider musicSwitch;
    [SerializeField] Slider soundSwitch;
    [SerializeField] AudioClip gamePlayAudio;
    [SerializeField] TextMeshProUGUI versionText;

      void Start()
    {
        versionText.text = Application.version;
    }
    public void AdjustMusicSettings()
    {
        if (AudioManager.GetInstance() != null)
        {
            if (musicSwitch.value > 0)
            {
                AudioManager.GetInstance().GetComponent<AudioSource>().mute = false;
            }
            else if (musicSwitch.value <= 0)
            {
                AudioManager.GetInstance().GetComponent<AudioSource>().mute = true;
            }
        }

    }

    public void AdjustSoundSettings()
    {
        if(AudioManager.GetInstance() != null)
        {
            if(soundSwitch.value > 0)
            {
                AudioManager.GetInstance().bTouchSoundEnable = true;
            }
            else if (soundSwitch.value <= 0)
            {
                AudioManager.GetInstance().bTouchSoundEnable = false;
            }
        }
    }

}

    
