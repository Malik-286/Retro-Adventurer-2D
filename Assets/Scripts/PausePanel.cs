using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PausePanel : MonoBehaviour
{
    

    GameManager gameManager;
    AudioManager audioManager;


    [SerializeField] AudioClip touchSound;
    [SerializeField] GameObject uiControllsButtons;
    public Sprite[] audioIcons;
    public Image audioImage;
 

    void Start()
    {
        gameManager = FindObjectOfType<GameManager>();
        audioManager  = FindObjectOfType<AudioManager>();
       

       
    }


    public void ResumeGame()
    {
        Time.timeScale = 1;
        uiControllsButtons.SetActive(true);
        this.gameObject.SetActive(false);
        if (audioManager.GetInstance() != null)
        {
            audioManager.PlayTouchSoundEffect();
        }
    }

    public void PressHomeButton()
    {

        if(audioManager.GetInstance() != null)
        {
            audioManager.PlayTouchSoundEffect();
        }
        if(gameManager.GetInstance() != null)
        {
            Time.timeScale = 1;
            gameManager.LoadNextScene("Main Menu");
        }
    }

    public void MuteUnMuteAudio()
    {  

        if (audioManager.GetInstance() != null)
        {
            audioManager.PlayTouchSoundEffect();

            if (audioManager.GetComponent<AudioSource>().mute == true)
            {
                audioManager.GetComponent<AudioSource>().mute = false;
                audioImage.sprite = audioIcons[0];
            }
            else if (audioManager.GetComponent<AudioSource>().mute == false)
            {
                audioManager.GetComponent<AudioSource>().mute = true;
                audioImage.sprite = audioIcons[1];

            }
        }
    }
     
}
