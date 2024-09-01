using hardartcore.CasualGUI;
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
      public GameObject uiControllsButtons;
      [SerializeField] Button pauseButton;

     [Header("Player Prefebs")]
     [SerializeField] Transform playerInstantiatePosition; 
     public GameObject[] playerPrefebs;


    public GameObject Player;
    public GameObject pausePanel;
    public GameObject TutotialPanel;
    public GameObject deathPanel;
    public GameObject detailsPanel;
    public GameObject timeEndPanel;
    TimerPanel timerPanel;


    KillsCounter killsCounter;
    PlayerController playerController;
    PlayerHealth playerHealth;

    void Awake()
    {
        if (PlayerPrefs.GetInt("OneTime") == 0)
        {
            TutotialPanel.SetActive(true);
        }
        else
        {
            TutotialPanel.SetActive(false);
        }
    }
    void Start()
    {

        InstantiateSelectedPlayer();

        killsCounter = FindObjectOfType<KillsCounter>();
        playerController = FindObjectOfType<PlayerController>();
        pausePanel.SetActive(false);
        deathPanel.SetActive(false);
        timeEndPanel.SetActive(false);
        timerPanel = FindObjectOfType<TimerPanel>();
        playerHealth = FindObjectOfType<PlayerHealth>();
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
            if (playerHealth.isAlive == true)
            {
                pauseButton.interactable = true;
                uiControllsButtons.SetActive(true);
            }
        }




    }

    public void InstantiateSelectedPlayer()
    {
        int currentPlayerIndex = PlayerPrefs.GetInt("CurrentPlayer", 0); // Default to skin 0 if not set
        Instantiate(playerPrefebs[currentPlayerIndex], playerInstantiatePosition.position, Quaternion.identity);
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
        if(killsCounterText != null || killsCounter != null)
        {
            killsCounterText.text = killsCounter.GetCurrentSceneKills().ToString();
        }
     
         
    }


    public void PlayAD()
    {
        if (Adsmanager.Instance)
        {
            Adsmanager.Instance.ShowIntersitial();
        }
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


    #region Player Movement Calling Methods for UI Buttons

    public void Attack()
    {
        if(playerController != null)
        {
            playerController.Attack();
        }
    }

    public void Jump()
    {
        if (playerController != null)
        {
            playerController.Jump();
        }
    }
    public void MoveLeftPressed()
    {
        if (playerController != null)
        {
            playerController.MoveLeftPressed();
        }
    }

    public void MoveLeftReleased()
    {
        if (playerController != null)
        {
            playerController.MoveLeftReleased();
            playerController.StopMoving();
        }
    }

    public void MoveRightPressed()
    {
        if (playerController != null)
        {
            playerController.MoveRightPressed();
        }
    }

    public void MoveRightReleased()
    {
        if (playerController != null)
        {
            playerController.MoveRightReleased();
            playerController.StopMoving();
        } 
    }

    public void MoveUpPressed()
    {
        if (playerController != null)
        {
            playerController.MoveUpPressed();
         }
    }

    public void MoveUpReleased()
    {
        if (playerController != null)
        {
            playerController.MoveUpReleased();
             
        }
    }


    public void MoveDownPressed()
    {
        if (playerController != null)
        {
            playerController.MoveDownPressed();
         }
    }

    public void MoveDownReleased()
    {
        if (playerController != null)
        {
            playerController.MoveDownReleased();
 
        }
    }

    #endregion

}
