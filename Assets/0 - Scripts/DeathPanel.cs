using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class DeathPanel : MonoBehaviour
{


    CurrencyManager currencyManager;
    PlayerHealth playerHealth;
    HealthPanel healthPanel;
 

    [SerializeField] TextMeshProUGUI deathHeadingText;
    [SerializeField] GameObject UiControlls;
    [SerializeField] GameObject detailsPanel;





    void Start()
    {
         currencyManager = FindObjectOfType<CurrencyManager>();
        playerHealth = FindObjectOfType<PlayerHealth>();
        healthPanel = FindObjectOfType<HealthPanel>();
   
     }

    public void PressHomeButton()
    {
        Time.timeScale = 1.0f;  
        if (AudioManager.GetInstance() != null)
        {
            AudioManager.GetInstance().PlayTouchSoundEffect();
        }
        if (GameManager.GetInstance() != null)
        {
              GameManager.GetInstance().LoadNextScene("Main Menu");
        }
    }

    public void PressContinueButton()
    {
   
        Time.timeScale = 1.0f;
        if (AudioManager.GetInstance() != null)
        {
            AudioManager.GetInstance().PlayTouchSoundEffect();
        }
        if (currencyManager != null)
        {
            if(currencyManager.GetCurrentCoins() >= 100 && playerHealth != null)
            {
                currencyManager.DecreaseCoins(100);
                currencyManager.SaveCurrencyData();
                playerHealth.IncreaseHealth(25);
                playerHealth.isAlive = true;
                UpdateHealthIcon();
                this.gameObject.SetActive(false);
                UiControlls.SetActive(true);
                detailsPanel.SetActive(true);
                playerHealth.EnableAndDisablePlayerHealthComponent();

            }
            else if(currencyManager.GetCurrentCoins() < 100 && playerHealth != null)
            {
                playerHealth.EnableAndDisablePlayerHealthComponent();
                deathHeadingText.text = " Not enough Coins ! ";

            }
        }
 
    }


    public void PressReloadButton()
    {
        Time.timeScale = 1.0f;
        if (GameManager.GetInstance() != null)
        {
             GameManager.GetInstance().ReloadGame();
        }
    }

    void UpdateHealthIcon()
    {
        if(healthPanel != null)
        {
            healthPanel.heartImages[0].SetActive(true);
        }

    }

   
}

  

 
