using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Purchasing;

public class StorePanel :MonoBehaviour
{
 

    [SerializeField] GameObject purchaseFailedPanel;
    [SerializeField] GameObject purchasedSucessPanel;

  

     const string removeAds_ProductID = "com.aspiregamesstudio.retroadventurer.removeads";
     const string coinsPack1000_ProductID = "com.aspiregamesstudio.retroadventurer.coins1000";
     const string coinsPack5000_ProductID = "com.aspiregamesstudio.retroadventurer.coins5000";
     const string coinsPack10000_ProductID = "com.aspiregamesstudio.retroadventurer.coins10000";

    [Header("Ads Status")]

    public string adsStatus;
    public string defaultAdsStatus = "enabled";




    CurrencyManager currencyManager;


    void Awake()
    {
        currencyManager = FindObjectOfType<CurrencyManager>();


        adsStatus = PlayerPrefs.GetString("AdsStatusKey");
        if (adsStatus == string.Empty)
        {
            this.adsStatus = "enabled";
        }
        
        purchaseFailedPanel.SetActive(false);
        purchasedSucessPanel.SetActive(false);
 
    }


   

    public void OnPurchaseComplete(Product product)
    {
        if (product.definition.id == removeAds_ProductID)
        {
            adsStatus = "disabled";
            PlayerPrefs.SetString("AdsStatusKey", adsStatus);
        }
         
         
        else if (product.definition.id == coinsPack1000_ProductID && currencyManager != null)
        {
            currencyManager.IncreaseCoins(1000);
            currencyManager.SaveCurrencyData();
            Debug.Log("Coins 1000 has been added to you account with new balance of :" + currencyManager.GetCurrentCoins());
            purchasedSucessPanel.SetActive(true);

        }
        else if (product.definition.id == coinsPack5000_ProductID && currencyManager != null)
        {

            currencyManager.IncreaseCoins(5000);
            currencyManager.SaveCurrencyData();
            Debug.Log("Coins 5K has been added to your account with new balance of :" + currencyManager.GetCurrentCoins());
            purchasedSucessPanel.SetActive(true);

        }
        else if (product.definition.id == coinsPack10000_ProductID && currencyManager != null)
        {
            currencyManager.IncreaseCoins(10000);
            currencyManager.SaveCurrencyData();
            Debug.Log("Coins 10K has been added to you account with new balance of :" + currencyManager.GetCurrentCoins());
            purchasedSucessPanel.SetActive(true);

        }

    }

    public void OnPurchaseFailed(Product product, PurchaseFailureReason reason)
    {
        purchaseFailedPanel.SetActive(true);
    }
    

}
