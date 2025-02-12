using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Purchasing;

public class StorePanel :MonoBehaviour
{


    [SerializeField] GameObject skinsPanel;
    [SerializeField] GameObject coinsPanel;


    [SerializeField] GameObject purchaseFailedPanel;
    [SerializeField] GameObject purchasedSucessPanel;
    [SerializeField] AudioClip coinsPurchaseSFX;
 
  

     const string removeAds_ProductID = "com.agsventures.retroadventurerepicquest.removeads";
     const string coinsPack1000_ProductID = "com.agsventures.retroadventurerepicquest.coins1000";
     const string coinsPack5000_ProductID = "com.agsventures.retroadventurerepicquest.coins5000";
     const string coinsPack10000_ProductID = "com.agsventures.retroadventurerepicquest.coins10000";

    [Header("Ads Status")]

    public string adsStatus;
    public string defaultAdsStatus = "enabled";


    void Awake()
    {
 

        adsStatus = PlayerPrefs.GetString("AdsStatusKey");
        if (adsStatus == string.Empty)
        {
            this.adsStatus = "enabled";
        }
        
        purchaseFailedPanel.SetActive(false);
        purchasedSucessPanel.SetActive(false);
        coinsPanel.SetActive(false);
        skinsPanel.SetActive(true);
  
    }


   

    public void OnPurchaseComplete(Product product)
    {
        if (product.definition.id == removeAds_ProductID)
        {
            adsStatus = "disabled";
            PlayerPrefs.SetString("AdsStatusKey", adsStatus);
        }
         
         
        else if (product.definition.id == coinsPack1000_ProductID && CurrencyManager.instance != null)
        {
            if(AudioManager.GetInstance() != null)
            {
                AudioManager.GetInstance().PlaySingleShotAudio(coinsPurchaseSFX, 1.0f);
            }
            CurrencyManager.instance.IncreaseCoins(1000);
            CurrencyManager.instance.SaveCurrencyData();
            Debug.Log("Coins 1000 has been added to you account with new balance of :" + CurrencyManager.instance.GetCurrentCoins());
            purchasedSucessPanel.SetActive(true);

        }
        else if (product.definition.id == coinsPack5000_ProductID && CurrencyManager.instance != null)
        {
            if (AudioManager.GetInstance() != null)
            {
                AudioManager.GetInstance().PlaySingleShotAudio(coinsPurchaseSFX, 1.0f);
            }
            CurrencyManager.instance.IncreaseCoins(5000);
            CurrencyManager.instance.SaveCurrencyData();
            Debug.Log("Coins 5K has been added to your account with new balance of :" + CurrencyManager.instance.GetCurrentCoins());
            purchasedSucessPanel.SetActive(true);

        }
        else if (product.definition.id == coinsPack10000_ProductID && CurrencyManager.instance != null)
        {
            if (AudioManager.GetInstance() != null)
            {
                AudioManager.GetInstance().PlaySingleShotAudio(coinsPurchaseSFX, 1.0f);
            }
            CurrencyManager.instance.IncreaseCoins(10000);
            CurrencyManager.instance.SaveCurrencyData();
            Debug.Log("Coins 10K has been added to you account with new balance of :" + CurrencyManager.instance.GetCurrentCoins());
            purchasedSucessPanel.SetActive(true);

        }

    }

    public void OnPurchaseFailed(Product product, PurchaseFailureReason reason)
    {
        Debug.Log("Purchase Failed...");

        purchaseFailedPanel.SetActive(true);
    }

    
    

}
