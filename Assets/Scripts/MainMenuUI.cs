using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class MainMenuUI : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI gameText;
    [SerializeField] TextMeshProUGUI [] gameVersionTexts;
 

    [SerializeField] TextMeshProUGUI coinsText;
    [SerializeField] GameObject levelsPanel;
    [SerializeField] GameObject settingsPanel;
 
    [SerializeField] int defaultUnLockLevelNo = 0;
 

    CurrencyManager currencyManager;
    LevelUnLocker levelUnLocker;

    void Start()
    {
        currencyManager = FindObjectOfType<CurrencyManager>();
        levelUnLocker = FindObjectOfType<LevelUnLocker>();
        levelsPanel.SetActive(false);
        settingsPanel.SetActive(false);
         levelUnLocker.UnlockLevel(defaultUnLockLevelNo);
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
        if(currencyManager.GetInstance() != null)
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
}
