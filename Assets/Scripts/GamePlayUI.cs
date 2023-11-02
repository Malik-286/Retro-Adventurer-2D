using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
public class GamePlayUI : MonoBehaviour
{



      [SerializeField] TextMeshProUGUI coinsText;
      [SerializeField] TextMeshProUGUI levelNoText;




    CurrencyManager currencyManager;
    GameManager gameManager;

    void Start()
    {
          currencyManager = FindObjectOfType<CurrencyManager>(); 
          gameManager = FindObjectOfType<GameManager>();

    }

    void Update()
    {

        UpdateCurrencyText();
        UpdateLevelNoText();    
 
    }

    

    

    void UpdateCurrencyText()
    {
        if (currencyManager.GetInstance() != null)
        {
            coinsText.text = currencyManager.GetCurrentCoins().ToString();
        }
    }

    void UpdateLevelNoText()
    {
        if (gameManager.GetInstance() != null)
        {
            levelNoText.text = gameManager.GetActiveSceneName();
        }
    }
         
}
