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

        playerHealth.IncreaseHealth(25);

        // Ensure all other animations are reset before reviving the player
        Animator playerAnimator = playerHealth.GetComponent<Animator>();
        playerAnimator.SetBool("isDead", false);
        playerAnimator.SetBool("isRunning", false);
        playerAnimator.SetBool("isClimbing", false);
        playerAnimator.SetBool("isJumping", false);

        // Set idle animation as default
        playerAnimator.SetBool("isIdeling", true);

        // Revive the player
        playerHealth.isAlive = true;

        UpdateHealthIcon();
        UiControlls.SetActive(true);
        detailsPanel.SetActive(true);
        playerHealth.EnableAndDisablePlayerHealthComponent();
        this.gameObject.SetActive(false);
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

  

 
