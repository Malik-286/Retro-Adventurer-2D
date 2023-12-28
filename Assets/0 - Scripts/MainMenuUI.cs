using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class MainMenuUI : MonoBehaviour
{
    [Header("Texts")]

    [SerializeField] TextMeshProUGUI gameText;
    [SerializeField] TextMeshProUGUI[] gameVersionTexts;
    [SerializeField] TextMeshProUGUI coinsText;
 


    [Header("MainMenu Panels")]

    [SerializeField] GameObject levelsPanel;
    [SerializeField] GameObject settingsPanel;
    [SerializeField] GameObject updatePanel;





    [SerializeField] int defaultUnLockLevelNo = 0;


    CurrencyManager currencyManager;
    LevelUnLocker levelUnLocker;
    AudioManager audioManager;

    void Start()
    {
        currencyManager = FindObjectOfType<CurrencyManager>();
        levelUnLocker = FindObjectOfType<LevelUnLocker>();
        levelsPanel.SetActive(false);
        settingsPanel.SetActive(false);
        levelUnLocker.UnlockLevel(defaultUnLockLevelNo);
        audioManager = FindObjectOfType<AudioManager>();
        updatePanel.SetActive(false);
        ActiveScreenTime();
    }

    void UpdateGameVersionText()
    {
        for (int i = 0; i < gameVersionTexts.Length; i++)
        {
            gameVersionTexts[i].text = "ver. " + Application.version.ToLower();
        }

    }
    void UpdateCurrencyText()
    {
        if (currencyManager.GetInstance() != null)
        {
            coinsText.text = currencyManager.GetCurrentCoins().ToString();
        }
    }




    void Update()
    {
        UpdateGameVersionText();
        UpdateCurrencyText();
    }

    public void StartGame()
    {
        levelsPanel.SetActive(true);
    }

    void ActiveScreenTime()
    {
        Screen.sleepTimeout = SleepTimeout.NeverSleep;
    }

    public void PlayTouchSoundEffect()
    {
        if (audioManager != null)
        {
            audioManager.GetInstance().PlayTouchSoundEffect();
        }
    }


    public void ActivateUpdatePanel()
    {
        updatePanel.SetActive(true);
    }

   

}


