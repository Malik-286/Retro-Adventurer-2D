using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public  class RewardsPanel : MonoBehaviour
{
  

    CurrencyManager currencyManager;
    [SerializeField] TextMeshProUGUI fiftyfreeCoinsText;
    [SerializeField] float rewardTimeCount = 120;


      bool isTimeCompleted;

    [Header("Panel Positions")]
    [SerializeField] float visibleYPosition = 0f;
    [SerializeField] float inVisibleYPosition = 1200f;
    [SerializeField] RectTransform rewardPanel;


    AudioManager audioManager;

     void Start()
    {
        isTimeCompleted = false;  
        currencyManager = FindObjectOfType<CurrencyManager>();
        InVisibleRewardPanel();
        audioManager = FindObjectOfType<AudioManager>();
    }

    void Update()
    {
        if (rewardTimeCount < 1.0f)
        {
            fiftyfreeCoinsText.text = "50 Free Coins";
            return;
        }

         if (!isTimeCompleted)
        {
            StartTimeCountDown();
        }
    }

    public void Give50FreeCoins()
    {

        PlayTouchAudio();
        if (rewardTimeCount >= 1)
        {
            return;
        }
        if (currencyManager != null && !isTimeCompleted)
        {
            currencyManager.IncreaseCoins(50);
            currencyManager.SaveCurrencyData();
            fiftyfreeCoinsText.text = "50 Free Coins";
            rewardTimeCount = 120f;
            isTimeCompleted = false;  
        }
            
        
    }

    void StartTimeCountDown()
    {
        rewardTimeCount -= Time.smoothDeltaTime;
        fiftyfreeCoinsText.text = rewardTimeCount.ToString("00:00");
    }


    public void  VisibleRewardPanel()
    {
        
        rewardPanel.anchoredPosition = new Vector2(0, visibleYPosition);
      
    }
    public void InVisibleRewardPanel()
    { 
        rewardPanel.anchoredPosition = new Vector2(0, inVisibleYPosition);
      
    }

    public void PlayTouchAudio()
    {
        if (audioManager != null)
        {
            audioManager.PlayTouchSoundEffect();

        }
    }
}

