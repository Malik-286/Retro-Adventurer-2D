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


        playerController.GetComponent<Animator>().SetBool("isRunning", false);
        playerController.GetComponent<Animator>().SetBool("isClimbing", false); 
        playerController.GetComponent<Animator>().SetBool("isJumping", false);

        playerController.GetComponent<Animator>().SetBool("isIdeling", true);

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
        if (CurrencyManager.instance)
        {
            playerHealth.IncreaseHealth(25);
            
            playerHealth.GetComponent<Animator>().SetBool("isDead", false);
            playerHealth.GetComponent<Animator>().SetBool("isRunning", false);
            playerHealth.GetComponent<Animator>().SetBool("isIdeling", true);

            playerHealth.isAlive = true;
            UpdateHealthIcon();
            this.gameObject.SetActive(false);
            UiControlls.SetActive(true);
            detailsPanel.SetActive(true);
            playerHealth.EnableAndDisablePlayerHealthComponent();
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

  

 
