//using GoogleMobileAds.Api;
using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using CoppraGames;
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
        print("Reward Adding up");

        if (Index == 0)
        {
            if (CurrencyManager.instance)
            {
                CurrencyManager.instance.IncreaseCoins(PlayerPrefs.GetInt("CollectedCurrency") * 2);
                print(PlayerPrefs.GetInt("CollectedCurrency") + " Collected coins Value");
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
        if (Index == 2)
        {
            if (CurrencyManager.instance)
            {
                SpinWheelController.Instance.TurnWheel();
                print("Spinner Wheel Admob Reward Generated");
                this.gameObject.GetComponent<Button>().interactable = false;
                Invoke(nameof(EnableAgaino), 10f);
            }
        }
    }
    #endregion

    public void EnableAgaino()
    {
        this.gameObject.GetComponent<Button>().interactable = true;
    }

    public void ShowRewardedVideo()
    {
        if(Adsmanager.Instance)
        Adsmanager.Instance.ShowRewardedVideoAd();
    }

}