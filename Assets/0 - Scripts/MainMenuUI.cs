using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class MainMenuUI : MonoBehaviour
{
    public static MainMenuUI instance;

    [Header("Texts")]

    [SerializeField] TextMeshProUGUI coinsText;

    [Header("Audio")]

    [SerializeField] AudioClip playButtonSoundEffect;


    [Header("MainMenu Panels")]

    [SerializeField] GameObject levelsPanel;
    [SerializeField] GameObject settingsPanel;
    [SerializeField] GameObject storePanel;
    [SerializeField] GameObject spinPanel;
    public GameObject TapToContinuePanel;
    public GameObject MainMenuPanel;

    [Header("Default Unlock Level No ")]

    [SerializeField] int defaultUnLockLevelNo = 0;
    [SerializeField] CurrencyManager currencyManager;
    [SerializeField] LevelUnLocker levelUnLocker;


    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        if(PlayerPrefs.GetInt("GameplayStarted") == 0)
        {
           MainMenuPanel.SetActive(false);
           TapToContinuePanel.SetActive(true);
            PlayerPrefs.SetInt("GameplayStarted", 1);
        }
        else
        {
            MainMenuPanel.SetActive(true);
            TapToContinuePanel.SetActive(false);
        }

    }
    void Start()
    {
        storePanel.SetActive(false);
        currencyManager = FindObjectOfType<CurrencyManager>();
        levelUnLocker = FindObjectOfType<LevelUnLocker>();
        levelsPanel.SetActive(false);
        settingsPanel.SetActive(false);
        spinPanel.SetActive(false);
        levelUnLocker.UnlockLevel(defaultUnLockLevelNo);
        ActiveScreenTime();
    }

    void Update()
    {
        UpdateCurrencyText();
    }
    private void OnApplicationQuit()
    {
        PlayerPrefs.SetInt("GameplayStarted", 0);
    }
    void UpdateCurrencyText()
    {
        if (currencyManager.GetInstance() != null)
        {
            coinsText.text = currencyManager.GetCurrentCoins().ToString();
        }
    }

 
    public void StartGame()
    {
        PlayClickSoundEffect();
        levelsPanel.SetActive(true);
        PlayerPrefs.SetInt("CurrencybeforePlay", currencyManager.GetCurrentCoins());
    }

    void ActiveScreenTime()
    {
        Screen.sleepTimeout = SleepTimeout.NeverSleep;
    }

    public void PlayTouchSoundEffect()
    {
        if (AudioManager.GetInstance() != null)
        {
            AudioManager.GetInstance().PlayTouchSoundEffect();  
        }
    }

    public void PlayClickSoundEffect()
    {
        if (AudioManager.GetInstance() != null)
        {
            AudioManager.GetInstance().PlaySingleShotAudio(playButtonSoundEffect, 1.0f);
        }
    }

   


}


