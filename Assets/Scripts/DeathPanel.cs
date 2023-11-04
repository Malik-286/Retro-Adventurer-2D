using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class DeathPanel : MonoBehaviour
{


    GameManager gameManager;
    AudioManager audioManager;
    CurrencyManager currencyManager;
    PlayerHealth playerHealth;
    [SerializeField] TextMeshProUGUI deathHeadingText;
      void Start()
    {
        gameManager = FindObjectOfType<GameManager>(); 
        audioManager = FindObjectOfType<AudioManager>();
        currencyManager = FindObjectOfType<CurrencyManager>();
        playerHealth = FindObjectOfType<PlayerHealth>();
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

    public void PressContinueButton()
    {
        Time.timeScale = 1.0f;
        if (audioManager.GetInstance() != null)
        {
            audioManager.PlayTouchSoundEffect();
        }
        if (currencyManager != null)
        {
            if(currencyManager.GetCurrentCoins() >= 100 && playerHealth != null)
            {
                currencyManager.DecreaseCoins(100);
                currencyManager.SaveCurrencyData();
                playerHealth.IncreaseHealth(25);
                playerHealth.isAlive = true;
                playerHealth.EnableAndDisablePlayerHealthComponent();
                this.gameObject.SetActive(false);
            }
              else if(currencyManager.GetCurrentCoins() < 100 && playerHealth != null)
            {
                deathHeadingText.text = "You Don't have enough Coins ! ";
                PressReloadButton();
            }
        }

    }

    public void PressReloadButton()
    {
        Time.timeScale = 1.0f;

        if (audioManager.GetInstance() != null)
        {
            audioManager.PlayTouchSoundEffect();
        }
        if (gameManager.GetInstance() != null) 
        {
            gameManager.ReloadGame();
        }

    }

   


}
