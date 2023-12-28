using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Purchasing;
using UnityEngine.UI;

public class RemoveAds : MonoBehaviour
{

  
    InterstitialAd interstitialAd;

    [SerializeField] GameObject  removeAdsButton;

      void Start()
    {
        interstitialAd = FindObjectOfType<InterstitialAd>();
        EnableDisableRemoveAdsButton();
    }

     
    public void OnPurchaseComplete(Product product)
    {
        if(product.definition.id == "com.aspireplay.retroadventurer.removeads")
        {
             Debug.Log("Ads has been removed");
            interstitialAd.areAdsEnabled = false;
            PlayerPrefs.SetInt("AdsStatus", interstitialAd.areAdsEnabled ? 1 : 0);
            PlayerPrefs.Save();
            EnableDisableRemoveAdsButton();
        }
    }


    public void OnPurchaseFailed(Product product, PurchaseFailureReason reason)
    {
        Debug.LogWarning("Failed to purchase the " + product.definition.id + " due to " + reason);
        interstitialAd.areAdsEnabled = true;
        EnableDisableRemoveAdsButton();

    }


    void EnableDisableRemoveAdsButton()
    {
        if(interstitialAd.Instance != null)
        {
            if (interstitialAd.areAdsEnabled == true)
            {
                removeAdsButton.SetActive(true);
            }
            else if ((interstitialAd.areAdsEnabled == false))
            {
                removeAdsButton.SetActive(false);

            }

        }

    }
}
