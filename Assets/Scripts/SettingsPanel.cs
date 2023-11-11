using System.Collections;
using System.Collections.Generic;
using TMPro;
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

    public void OpenSocialChannelURL(string link)
    {
        Application.OpenURL(link);
        Debug.Log(link);
    }

    public void ResetGame()
    {
        if(currencyManager != null )
        {
            PlayerPrefs.DeleteAll();
            PlayerPrefs.Save();
            currencyManager.ResetCurrency(); 
           
        }
       

    }


}
