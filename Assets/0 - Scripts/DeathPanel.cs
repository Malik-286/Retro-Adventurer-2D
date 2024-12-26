using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
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
        if (Adsmanager.Instance != null)
        {
            Adsmanager.Instance.Interstitial.LoadInterstitialAd();
        }


        if (HealthPanel.instance)
        {
            healthPanel = HealthPanel.instance;
        }
        if (PlayerHealth.Instance)
        {
            playerHealth = PlayerHealth.Instance;
            playerController = PlayerHealth.Instance.gameObject.GetComponent<PlayerController>();
            PlayerHealth.Instance.gameObject.GetComponent<Animator>().SetBool("isRunning", false);
            PlayerHealth.Instance.gameObject.GetComponent<Animator>().SetBool("isClimbing", false);
            PlayerHealth.Instance.gameObject.GetComponent<Animator>().SetBool("isJumping", false);
            PlayerHealth.Instance.gameObject.GetComponent<Animator>().SetBool("isIdeling", true);
        }

    }

    public void PressHomeButton()
    {
        if (Adsmanager.Instance != null)
        {
            Adsmanager.Instance.Interstitial.ShowInterstitialAd();
        }
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
        if (Adsmanager.Instance != null)
        {
            Adsmanager.Instance.Interstitial.ShowInterstitialAd();
        }
        Time.timeScale = 1.0f;
        if (PlayerHealth.Instance)
        {
            PlayerHealth.Instance.IncreaseHealth(25);
            PlayerHealth.Instance.EnableAndDisablePlayerHealthComponent();

            // Ensure all other animations are reset before reviving the player
            Animator playerAnimator = PlayerHealth.Instance.GetComponent<Animator>();
            playerAnimator.SetBool("isDead", false);
            playerAnimator.SetBool("isRunning", false);
            playerAnimator.SetBool("isClimbing", false);
            playerAnimator.SetBool("isJumping", false);

            // Set idle animation as default
            playerAnimator.SetBool("isIdeling", true);

            // Revive the player
            PlayerHealth.Instance.isAlive = true;
        }
        UpdateHealthIcon();
        UiControlls.SetActive(true);
        detailsPanel.SetActive(true);
        this.gameObject.SetActive(false);
    }


    public void PressReloadButton()
    {
        if (Adsmanager.Instance != null)
        {
            Adsmanager.Instance.Interstitial.ShowInterstitialAd();
        }
        Time.timeScale = 1.0f;
        if (GameManager.GetInstance() != null)
        {
             GameManager.GetInstance().ReloadGame();
        }
    }

    void UpdateHealthIcon()
    {
        if (healthPanel != null)
        {
            if (HealthPanel.instance)
            {
                HealthPanel.instance.heartImages[0].SetActive(true);
            }
        }

    }

   
}

  

 
