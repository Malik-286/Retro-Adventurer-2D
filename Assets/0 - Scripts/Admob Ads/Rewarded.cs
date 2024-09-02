using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GoogleMobileAds;
using GoogleMobileAds.Api;
using System;

public class Rewarded : MonoBehaviour
{

    public static Rewarded Instance;


    RewardedAd _rewardedAd;
 
      void Awake()
    {
        if(Instance == null)
        {
            Instance = this;
        }
    }
    void Start()
    {
         MobileAds.Initialize((InitializationStatus initStatus) =>  {});
          LoadRewardedAd();
     }


 #if UNITY_ANDROID
      string _adUnitId = "ca-app-pub-1387627577986386/4685752798";
#elif UNITY_IPHONE
    string _adUnitId = "ca-app-pub-3940256099942544/1712485313";
#else
    string _adUnitId = "unused";
#endif
     

   
    public void LoadRewardedAd()
    {
         if (_rewardedAd != null)
        {
            _rewardedAd.Destroy();
            _rewardedAd = null;
        }

        Debug.Log("Loading the rewarded ad.");

         var adRequest = new AdRequest();

         RewardedAd.Load(_adUnitId, adRequest,
            (RewardedAd ad, LoadAdError error) =>
            {
                 if (error != null || ad == null)
                {
                    Debug.LogError("Rewarded ad failed to load an ad " +
                                   "with error : " + error);
                    return;
                }

                Debug.Log("Rewarded ad loaded with response : "
                          + ad.GetResponseInfo());

                _rewardedAd = ad;
             });
    }

    public void ShowRewardedAd()
    {         
        if (_rewardedAd != null && _rewardedAd.CanShowAd())
        {
            _rewardedAd.Show((Reward reward) =>
            {
                //currencyManager.GetInstance().IncreaseCoins(200);
                //currencyManager.SaveCurrencyData();

                //Add Up reward.
                if (AdmobRewardedVideo.Instance)
                {
                    AdmobRewardedVideo.Instance.RewardAfterAd();
                }

                RegisterEventHandlers(_rewardedAd);
                RegisterReloadHandler(_rewardedAd);

            });
        }
    }

      void RegisterEventHandlers(RewardedAd ad)
    {
         ad.OnAdPaid += (AdValue adValue) =>
        {
            Debug.Log(String.Format("Rewarded ad paid {0} {1}.",
                adValue.Value,
                adValue.CurrencyCode));
        };
         ad.OnAdImpressionRecorded += () =>
        {
            Debug.Log("Rewarded ad recorded an impression.");
        };
         ad.OnAdClicked += () =>
        {
            Debug.Log("Rewarded ad was clicked.");
        };
         ad.OnAdFullScreenContentOpened += () =>
        {
            Debug.Log("Rewarded ad full screen content opened.");
        };
         ad.OnAdFullScreenContentClosed += () =>
        {
            Debug.Log("Rewarded ad full screen content closed.");
        };
         ad.OnAdFullScreenContentFailed += (AdError error) =>
        {
            Debug.LogError("Rewarded ad failed to open full screen content " +
                           "with error : " + error);
        };
    }

      void RegisterReloadHandler(RewardedAd ad)
    {
         ad.OnAdFullScreenContentClosed += () =>
    {
            Debug.Log("Rewarded Ad full screen content closed.");

             LoadRewardedAd();
        };
         ad.OnAdFullScreenContentFailed += (AdError error) =>
        {
            Debug.LogError("Rewarded ad failed to open full screen content " +
                           "with error : " + error);

             LoadRewardedAd();
        };
    }


}
