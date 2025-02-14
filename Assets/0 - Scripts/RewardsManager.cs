using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using CoppraGames;
public class RewardsManager : MonoBehaviour
{
    public static RewardsManager Instance;
    public int Index = 0;

    DeathPanel deathPanel;


    void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
    }

    void Start()
    {
        deathPanel = FindObjectOfType<DeathPanel>();
    }



    #region Give Reward

    public void RewardAfterAd()
    {
        print("Reward Adding up");

        if (Index == 0)
        {
            if (CurrencyManager.instance)
            {
                CurrencyManager.instance.IncreaseCoins(PlayerPrefs.GetInt("CollectedCurrency"));
                print(PlayerPrefs.GetInt("CollectedCurrency") + "Collected coins Value");
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

        }
        if (Index == 3)
        {

        }
        if (Index == 4)
        {
            if (TimerPanel.Instance)
            {
                TimerPanel.Instance.ResetTime();
                print("Death Panel Admob Reward Generated");
                this.gameObject.transform.parent.gameObject.SetActive(false);
            }
        }
    }
    #endregion

    public void EnableAgain()
    {
        this.gameObject.GetComponent<Button>().interactable = true;
    }

    public void SpinWheelPrice()
    {
        if (CurrencyManager.instance)
        {
            if(CurrencyManager.instance.GetCurrentCoins() >= 50)
            {
                CurrencyManager.instance.DecreaseCoins(50);
                SpinWheelController.Instance.TurnWheel();
                print("Spinner Wheel Admob Reward Generated");
                this.gameObject.GetComponent<Button>().interactable = false;
                Invoke(nameof(EnableAgain), 10f);
            }
            else
            {
                this.gameObject.GetComponent<Button>().interactable = false;
                Invoke(nameof(EnableAgain), 10f);
            }
        }
    }

    public void RevivewithCoins()
    {
        if (CurrencyManager.instance)
        {
            if (CurrencyManager.instance.GetCurrentCoins() >= 100)
            {
                CurrencyManager.instance.DecreaseCoins(100);
                Time.timeScale = 1.0f;

                // Ensure all other animations are reset before reviving the player
                Animator playerAnimator = PlayerHealth.Instance.GetComponent<Animator>();
                playerAnimator.SetBool("isDead", false);
                playerAnimator.SetBool("isRunning", false);
                playerAnimator.SetBool("isClimbing", false);
                playerAnimator.SetBool("isJumping", false);

                // Set idle animation as default
                playerAnimator.SetBool("isIdeling", true);
                if (TimerPanel.Instance)
                {
                    TimerPanel.Instance.ResetTime();
                }
                transform.parent.gameObject.SetActive(false);
            }
        }
    }
    public void ShowRewardedVideo()
    {
        //if(//UnityAdsManager.instance)
        {
             //UnityAdsManager.instance.ShowRewardedVideoAd();
        }
        
    }

}