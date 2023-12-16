using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
public class GamePlayUI : MonoBehaviour
{



      [SerializeField] TextMeshProUGUI coinsText;
      [SerializeField] TextMeshProUGUI levelNoText;
      [SerializeField] TextMeshProUGUI killsCounterText;
      [SerializeField] GameObject uiControllsButtons;
      [SerializeField] Button pauseButton;
 

    public GameObject pausePanel;
    public GameObject deathPanel;
    public GameObject timeEndPanel;
    TimerPanel timerPanel;

    CurrencyManager currencyManager;
    GameManager gameManager;
    KillsCounter killsCounter;
    AudioManager audioManager;
    
     void Start()
    {
        currencyManager = FindObjectOfType<CurrencyManager>();
        gameManager = FindObjectOfType<GameManager>();
        killsCounter = FindObjectOfType<KillsCounter>();
        pausePanel.SetActive(false);
        deathPanel.SetActive(false);
        timeEndPanel.SetActive(false);
        audioManager = FindObjectOfType<AudioManager>();
        timerPanel = FindObjectOfType<TimerPanel>();
    }

    void Update()
    {

        UpdateCurrencyText();
        UpdateLevelNoText(); 
        UpdateKillsCountText();


        if(timerPanel != null )
        {
            if(timerPanel.isTimeCompleted == true)
            {
                uiControllsButtons.SetActive(false);
                timeEndPanel.SetActive(true);
            }
        }

        if(pausePanel.activeInHierarchy || deathPanel.activeInHierarchy )

        {
            pauseButton.interactable = false;
            uiControllsButtons.SetActive(false);
        }
        else  
        {
            pauseButton.interactable = true;
            uiControllsButtons.SetActive(true);
        }




    }





    void UpdateCurrencyText()
    {
        if (currencyManager.GetInstance() != null)
        {
            coinsText.text = currencyManager.GetCurrentCoins().ToString();
        }
    }

    void UpdateLevelNoText()
    {
        if (gameManager.GetInstance() != null)
        {
            levelNoText.text = gameManager.GetActiveSceneName();
        }
    }

    void UpdateKillsCountText()
    {
        killsCounterText.text = killsCounter.GetCurrentSceneKills().ToString();
    }


    

    public void PauseGame()
    {
         
        uiControllsButtons.SetActive(false);
        pausePanel.SetActive(true);
        Time.timeScale = 0f;

        if (audioManager.GetInstance() != null)
        {
            audioManager.PlayTouchSoundEffect();
        }            
    }

}
