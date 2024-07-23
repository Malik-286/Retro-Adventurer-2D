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
         
        if (AudioManager.GetInstance())
        {
            if (musicSwitch.value > 0)
            {
                AudioManager.GetInstance().GetComponent<AudioSource>().mute = true;
            }
            else if (musicSwitch.value <= 0)
            {
                AudioManager.GetInstance().GetComponent<AudioSource>().mute = false;
            }
        }

    }

    public void AdjustSoundSettings()
    {
      
        if (AudioManager.GetInstance())
        {
            if(soundSwitch.value > 0)
            {
                AudioManager.GetInstance().bTouchSoundEnable = false;
            }
            else if (soundSwitch.value <= 0)
            {
                AudioManager.GetInstance().bTouchSoundEnable = true;
            }
        }
    }

}

    
