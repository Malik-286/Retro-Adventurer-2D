using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class LevelCompletionPanel : MonoBehaviour
{

    [SerializeField] GameObject[] otherPanels;
    [SerializeField] TextMeshProUGUI levelCompletedText;
    [SerializeField] TextMeshProUGUI totalKillsText;
    [SerializeField] string nextSceneToLoad;





    GameManager gameManager;
    CurrencyManager currencyManager;
    KillsCounter killsCounter;
    AudioManager audioManager;


      void Start()
    {
        gameManager = FindObjectOfType<GameManager>();
        currencyManager = FindObjectOfType<CurrencyManager>();
        killsCounter = FindObjectOfType<KillsCounter>();
        audioManager = FindObjectOfType<AudioManager>();
    }
    void Update()
    {
        UpdateTexts();

        foreach (GameObject panels in otherPanels)
        {
            panels.SetActive(false);
        }

    }


    void UpdateTexts()
    {
        levelCompletedText.text = gameManager.GetActiveSceneName() + " Completed !";
        totalKillsText.text = "Total Kills:  " + killsCounter.GetCurrentSceneKills().ToString("0");
    }

    public void PressHomeButton()
    {

        if (audioManager.GetInstance() != null)
        {
            audioManager.PlayTouchSoundEffect();
        }
        if (gameManager.GetInstance() != null)
        {
             gameManager.LoadNextScene("Main Menu");
        }
    }

    public void PressNextLevelButton()
    {

        if (audioManager.GetInstance() != null)
        {
            audioManager.PlayTouchSoundEffect();
        }
        if (gameManager.GetInstance() != null)
        {
              gameManager.LoadNextScene(nextSceneToLoad);

        }
    }
}
