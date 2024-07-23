//using GoogleMobileAds.Api;
using UnityEngine;
using UnityEngine.UI;
using System.Collections;
public class AdmobRewardedVideo : MonoBehaviour
{
    public static AdmobRewardedVideo Instance;
    public int Index = 0;


    private void Awake()
    {
        if(Instance == null)
        {
            Instance = this;
        }
    }

    private void Start()
    {
        //currencyManager = FindObjectOfType("")
    }


    #region Give Reward

    public void RewardAfterAd()
    {
        if (Index == 0)
        {
            if (CurrencyManager.instance)
            {
                CurrencyManager.instance.IncreaseCoins(200);
                CurrencyManager.instance.SaveCurrencyData();
            }
        }
        if (Index == 1)
        {
            if (CurrencyManager.instance)
            {
                CurrencyManager.instance.IncreaseCoins(ScrollBarMovement.Instance.Value);
                print("Awarded Coins are: " + ScrollBarMovement.Instance.Value);
            }
        }
    }
    #endregion

    public void ShowRewardedVideo()
    {
        if(Adsmanager.Instance)
        Adsmanager.Instance.ShowRewardedVideoAd();
    }

}