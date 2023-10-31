using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using static UnityEditor.Timeline.TimelinePlaybackControls;

public class GamePlayUI : MonoBehaviour
{



    [SerializeField] Slider healthSlider;
    [SerializeField] GameObject silderFillArea;
    [SerializeField] TextMeshProUGUI coinsText;
 


    PlayerHealth playerHealth;
    CurrencyManager currencyManager;    

    void Start()
    {
        playerHealth = FindObjectOfType<PlayerHealth>();
        healthSlider.maxValue = playerHealth.GetMaxHealth();
        currencyManager = FindObjectOfType<CurrencyManager>();  

    }

    void Update()
    {

        UpdateHealthSlider();
        UpdateCurrencyText();
 
    }

    

    void UpdateHealthSlider()
    {
        if (playerHealth != null)
        {
            healthSlider.value = playerHealth.GetCurrentHealth();
            if (playerHealth.GetCurrentHealth() <= 0)
            {
                silderFillArea.SetActive(false);
            }
            else if (playerHealth.GetCurrentHealth() >= 1)
            {
                silderFillArea.SetActive(true);
            }

        }

    }

    void UpdateCurrencyText()
    {
        if (currencyManager.GetInstance() != null)
        {
            coinsText.text = currencyManager.GetCurrentCoins().ToString();
        }
    }
}
