//using GoogleMobileAds.Api;
using UnityEngine;
using UnityEngine.UI;
using System.Collections;
public class AdmobRewardedVideo : MonoBehaviour
{
    public static AdmobRewardedVideo Instance;
    public int Index = 0;

    CurrencyManager currencyManager;

    private void Awake()
    {
        if(Instance == null)
        {
            Instance = this;
        }
    }

    #region Give Reward

    public void RewardAfterAd()
    {
        if (Index == 0)
        {
            currencyManager.GetInstance().IncreaseCoins(200);
            currencyManager.SaveCurrencyData();
        }
        if(Index == 1)
        {
            currencyManager.GetInstance().IncreaseCoins(PlayerPrefs.GetInt("CollectedCurrency"));
            currencyManager.SaveCurrencyData();
        }
    }
    #endregion

    public void ShowRewardedVideo()
    {
        if(Rewarded.Instance)
        Rewarded.Instance.ShowRewardedAd();
    }

}