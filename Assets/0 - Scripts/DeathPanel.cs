using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class DeathPanel : MonoBehaviour
{
    public static DeathPanel Instance;

    PlayerHealth playerHealth;
    HealthPanel healthPanel;
    PlayerController playerController;
 

    [SerializeField] TextMeshProUGUI deathHeadingText;
    [SerializeField] GameObject UiControlls;
    [SerializeField] GameObject detailsPanel;


    private void Awake()
    {
        if(Instance == null)
        {
            Instance = this;
        }
    }


    void Start()
    {
        if (GamePlayUI.Instance)
        {
            GamePlayUI.Instance.Player.GetComponent<Animator>().SetBool("isRunning", false);
            GamePlayUI.Instance.Player.GetComponent<Animator>().SetBool("isIdeling", true);
        }
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
            playerHealth.IncreaseHealth(25);
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

  

 
