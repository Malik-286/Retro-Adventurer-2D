using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class DeathPanel : MonoBehaviour
{


    PlayerHealth playerHealth;
    HealthPanel healthPanel;
    PlayerController playerController;
 

    [SerializeField] TextMeshProUGUI deathHeadingText;
    [SerializeField] GameObject UiControlls;
    [SerializeField] GameObject detailsPanel;





    void Start()
    {
      
        playerHealth = FindObjectOfType<PlayerHealth>();
        healthPanel = FindObjectOfType<HealthPanel>();
        playerController = FindObjectOfType<PlayerController>();

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
        playerController.GetComponent<Animator>().Rebind();
        Time.timeScale = 1.0f;

        if (AudioManager.GetInstance() != null)
        {
            AudioManager.GetInstance().PlayTouchSoundEffect();
        }
        if (CurrencyManager.instance)
        {
            if(CurrencyManager.instance.GetCurrentCoins() >= 100 && playerHealth != null)
            {
                CurrencyManager.instance.DecreaseCoins(100);
                CurrencyManager.instance.SaveCurrencyData();
                playerHealth.IncreaseHealth(25);
                playerHealth.isAlive = true;
                UpdateHealthIcon();
                this.gameObject.SetActive(false);
                UiControlls.SetActive(true);
                detailsPanel.SetActive(true);
                playerHealth.EnableAndDisablePlayerHealthComponent();

            }
            else if(CurrencyManager.instance.GetCurrentCoins() < 100 && playerHealth != null)
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

  

 
