using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SettingsPanel : MonoBehaviour
{

    [SerializeField] string privacyPolicyURL;



    GameManager gameManager;
    CurrencyManager currencyManager;



      void Start()
    {
        currencyManager = FindObjectOfType<CurrencyManager>(); 
        gameManager = FindObjectOfType<GameManager>();
    }

    public void ViewPrivacyPolicy()
    {
        Application.OpenURL(privacyPolicyURL);
        Debug.Log("Opening Privacy Policy URL...");

    }

    public void ResetGame()
    {
        if(currencyManager != null && gameManager != null)
        {
            currencyManager.ResetCurrency(); 
          //  gameManager.ResetLevel();
        }
       

    }


}
