using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class MainMenuUI : MonoBehaviour
{
    [Header("Texts")]

    [SerializeField] TextMeshProUGUI gameText;
    [SerializeField] TextMeshProUGUI coinsText;
 


    [Header("MainMenu Panels")]

    [SerializeField] GameObject levelsPanel;
    [SerializeField] GameObject settingsPanel;
    [SerializeField] GameObject storePanel;
    [SerializeField] GameObject spinPanel;



    [Header("Default Unlock Level No ")]

    [SerializeField] int defaultUnLockLevelNo = 0;





    CurrencyManager currencyManager;
    LevelUnLocker levelUnLocker;
 
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


    void UpdateCurrencyText()
    {
        if (currencyManager.GetInstance() != null)
        {
            coinsText.text = currencyManager.GetCurrentCoins().ToString();
        }
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
        if (AudioManager.GetInstance() != null)
        {
            AudioManager.GetInstance().PlayTouchSoundEffect();  
        }
    }

 

}


