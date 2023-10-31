using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class MainMenuUI : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI gameText;
    [SerializeField] TextMeshProUGUI gameVersionText;
    [SerializeField] TextMeshProUGUI coinsText;

    CurrencyManager currencyManager;
    void Start()
    {
        currencyManager = FindObjectOfType<CurrencyManager>();
    }

    void UpdateGameVersionText()
    {
        gameVersionText.text = "version "+ Application.version;
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
}
