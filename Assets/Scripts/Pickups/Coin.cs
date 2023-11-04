using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coin : MonoBehaviour
{


    [SerializeField] AudioClip coinCollectionSound;
    [SerializeField] int amountToIncrease;
 
    AudioManager audioManager;
    CurrencyManager currencyManager;


      void Start()
    {
        audioManager = FindObjectOfType<AudioManager>();    
        currencyManager = FindObjectOfType<CurrencyManager>();
    }
    void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.CompareTag("Player"))
        {
             if(audioManager != null)
            {
                audioManager.PlaySingleShotAudio(coinCollectionSound, 0.8f);
                if(currencyManager != null)
                {
                    if(this.gameObject.tag == "GoldBox")
                    {
                        amountToIncrease = Random.Range(10, 50);
                    }
                    currencyManager.IncreaseCoins(amountToIncrease);
                    currencyManager.SaveCurrencyData();
                }           
            }
                 Destroy(gameObject);
        }
    }
}
