using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class MainMenuUI : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI gameText;
    [SerializeField] TextMeshProUGUI gameVersionText;
    [SerializeField] TextMeshProUGUI coinsText;
    [SerializeField] GameObject levelsPanel;
    [SerializeField] GameObject settingsPanel;


    CurrencyManager currencyManager;
    void Start()
    {
        currencyManager = FindObjectOfType<CurrencyManager>();
        levelsPanel.SetActive(false);
        settingsPanel.SetActive(false); 
    }

    void UpdateGameVersionText()
    {
        gameVersionText.text = "v. "+ Application.version;
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
