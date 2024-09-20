using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PausePanel : MonoBehaviour
{
 

    [SerializeField] AudioClip touchSound;
    [SerializeField] GameObject uiControllsButtons;
    public Sprite[] audioIcons;
    [SerializeField] Image audioImage;
  
 

    public void ResumeGame()
    {
        Time.timeScale = 1;
        this.gameObject.SetActive(false);

        uiControllsButtons.SetActive(true);
        if (AudioManager.GetInstance() != null)
        {
            AudioManager.GetInstance().PlayTouchSoundEffect();
        }
          this.gameObject.SetActive(false);

    }

    public void PressHomeButton()
    {

        if(AudioManager.GetInstance() != null)
        {
            AudioManager.GetInstance().PlayTouchSoundEffect();
        }
        if(GameManager.GetInstance() != null)
        {
            Time.timeScale = 1;
            GameManager.GetInstance().LoadNextScene("Main Menu");
        }
    }

    public void MuteUnMuteAudio()
    {  

        if (AudioManager.GetInstance() != null)
        {
            AudioManager.GetInstance().PlayTouchSoundEffect();

            if (AudioManager.GetInstance().GetComponent<AudioSource>().mute == false)
            {
                 
                AudioManager.GetInstance().GetComponent<AudioSource>().mute = true;
                audioImage.sprite = audioIcons[1];
            }

            else if (AudioManager.GetInstance().GetComponent<AudioSource>() == true)
            {
                
                AudioManager.GetInstance().GetComponent<AudioSource>().mute = false;
                audioImage.sprite = audioIcons[0];
            }

        }
    }

    public void ReloadLevel()
    {
        if (GameManager.instance)
        {
            GameManager.instance.ReloadGame();
        }
    }
   

}
