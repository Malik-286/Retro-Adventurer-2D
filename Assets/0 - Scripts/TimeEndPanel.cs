using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimeEndPanel : MonoBehaviour
{

    GameManager gameManager;
    AudioManager audioManager;


    [SerializeField] GameObject UiControlls;
    void Start()
    {
        gameManager = FindObjectOfType<GameManager>();  
        audioManager = FindObjectOfType<AudioManager>();
    }

      void Update()
    {
        if(this.gameObject.activeInHierarchy)
        {
            UiControlls.SetActive(false);
        }
    }
    public void PressHomeButton()
    {
        Time.timeScale = 1.0f;
        if (audioManager.GetInstance() != null)
        {
            audioManager.PlayTouchSoundEffect();
        }
        if (gameManager.GetInstance() != null)
        {
            gameManager.LoadNextScene("Main Menu");
        }
    }

    public void PressReloadButton()
    {
        Time.timeScale = 1.0f;
        if (gameManager.GetInstance() != null)
        {
            gameManager.ReloadGame();
        }
    }

}
