using hardartcore.CasualGUI;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
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

    string chapterKey;
    int chapterProgress;
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

        print("ActualLoaded Scene Count " + SceneManager.GetActiveScene().buildIndex);
        PlayerPrefs.SetInt("CurrentLevel", SceneManager.GetActiveScene().buildIndex);

        CheckChaperterLocks();

        int currentLevel = PlayerPrefs.GetInt("CurrentLevel");
        int chapterIndex = currentLevel / 10; // Determine the chapter index (0 for first chapter, 1 for second, etc.)
        chapterProgress = (currentLevel % 10 + 1) * 10; // Calculate the progress within the chapter

        ChapterProgressManager.SetChapterProgress(chapterIndex, chapterProgress);
    }

    void Update()
    {
        
        UpdateCurrencyText();
        UpdateLevelNoText(); 
        UpdateKillsCountText();
        PlayerMovementwithKeyboard();

        if (timerPanel != null )
        {
            if(timerPanel.isTimeCompleted == true)
            {
                //uiControllsButtons.SetActive(false);
                timeEndPanel.SetActive(true);
            }
        }

        if(pausePanel.activeInHierarchy || deathPanel.activeInHierarchy )

        {
            pauseButton.interactable = false;
            //uiControllsButtons.SetActive(false);
        }
        else  
        {
            if (playerHealth.isAlive == true)
            {
                pauseButton.interactable = true;
                //uiControllsButtons.SetActive(true);
            }
        }




    }

    public void PlayerMovementwithKeyboard()
    {
        //Key Down
        if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            MoveRightPressed();
        }
        if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            MoveLeftPressed();
        }
        if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            MoveDownPressed();
        }
        if (Input.GetKeyDown(KeyCode.DownArrow))
        {
            MoveUpPressed();
        }
        if (Input.GetKeyDown(KeyCode.Space) == true)
        {
            Jump();
        }
        if (Input.GetKeyDown(KeyCode.Mouse0) == true)
        {
            Attack();
        }
        //Key Up
        if (Input.GetKeyUp(KeyCode.RightArrow))
        {
            MoveRightReleased();
        }
        if (Input.GetKeyUp(KeyCode.LeftArrow))
        {
            MoveLeftReleased();
        }
        if (Input.GetKeyUp(KeyCode.UpArrow))
        {
            MoveDownReleased();
        }
        if (Input.GetKeyUp(KeyCode.DownArrow))
        {
            MoveUpReleased();
        }
    }

    public void InstantiateSelectedPlayer()
    {
        int currentPlayerIndex = PlayerPrefs.GetInt("CurrentPlayer"); // Default to skin 0 if not set
        Instantiate(playerPrefebs[currentPlayerIndex], playerInstantiatePosition.position, Quaternion.identity);
        print(currentPlayerIndex + "CurrentPlayer Index");
    }

    public void CheckChaperterLocks()
    {
        int currentLevel = PlayerPrefs.GetInt("CurrentLevel");
        if (currentLevel % 10 == 9 && currentLevel <= 89)
        {
            int chapterUnlocked = (currentLevel / 10) + 1;
            PlayerPrefs.SetInt("ChapterUnlocked", chapterUnlocked);
        }
    }


    void UpdateCurrencyText()
    {
        if(CurrencyManager.instance)
        coinsText.text = CurrencyManager.instance.GetCurrentCoins().ToString();        
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
        //if (//UnityAdsManager.instance)
        {
            //UnityAdsManager.instance.ShowIntersitial();
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
        if (UIControls.Instance)
        {
            UIControls.Instance.AttackDescription.SetActive(false);
        }

        if(playerController != null)
        {
            playerController.Attack();
        }
    }

    public void Jump()
    {
        if (UIControls.Instance)
        {
            UIControls.Instance.JumpDescription.SetActive(false);
        }

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
