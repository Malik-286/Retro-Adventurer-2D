using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
public class GamePlayUI : MonoBehaviour
{

    public static GamePlayUI Instance;

      [SerializeField] TextMeshProUGUI coinsText;
      [SerializeField] TextMeshProUGUI levelNoText;
      [SerializeField] TextMeshProUGUI killsCounterText;
      [SerializeField] GameObject uiControllsButtons;
      [SerializeField] Button pauseButton;

    public GameObject Player;
    public GameObject pausePanel;
    public GameObject deathPanel;
    public GameObject timeEndPanel;
    TimerPanel timerPanel;

     KillsCounter killsCounter;
     
     void Start()
    {
          killsCounter = FindObjectOfType<KillsCounter>();
        pausePanel.SetActive(false);
        deathPanel.SetActive(false);
        timeEndPanel.SetActive(false);
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
        if (CurrencyManager.instance)
        {
            coinsText.text = CurrencyManager.instance.GetCurrentCoins().ToString();
        }
    }

    void UpdateLevelNoText()
    {
        if (GameManager.GetInstance())
        {
            levelNoText.text = GameManager.GetInstance().GetActiveSceneName();
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

        if (AudioManager.GetInstance())
        {
            AudioManager.GetInstance().PlayTouchSoundEffect();
        }            
    }

}
