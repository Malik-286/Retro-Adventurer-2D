using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GoogleMobileAds.Sample;

public class Adsmanager : MonoBehaviour
{
    [Header("Instance")]
    public static Adsmanager Instance;

    [Space(10f)]
    public Banner Banner;
    public Interstitial Interstitial;
    public RewardedAdController Rewarded;

    private void Awake()
    {
        if(Instance == null)
        {
            Instance = this;
        }
    }
    void Start()
    {
        DontDestroyOnLoad(this);


        ShowBanner();

    }

    #region Callings


    public void ShowBanner()
    {
        if (PlayerPrefs.GetString("AdsStatusKey") == "disabled")
        {
            return;

        }
        else
        {
            Banner.LoadAd();
            Banner.CreateBannerView();
        }
        
    }
    public void ShowIntersitial()
    {
        if (PlayerPrefs.GetString("AdsStatusKey") == "disabled")
        {
            return;

        }
        else
        {
             Interstitial.ShowInterstitialAd();

        }
    }
    public void ShowRewardedVideoAd()
    {
        Rewarded.ShowAd();
    }
    #endregion


  
}
