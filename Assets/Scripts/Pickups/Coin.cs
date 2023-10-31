using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coin : MonoBehaviour
{


    [SerializeField] AudioClip coinCollectionSound;
 
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
            Debug.Log("Coin Collected");
            if(audioManager != null)
            {
                audioManager.PlaySingleShotAudio(coinCollectionSound, 0.8f);
                if(currencyManager != null)
                {
                    currencyManager.IncreaseCoins(1);
                    currencyManager.SaveCurrencyData();
                }           
            }
                 Destroy(gameObject, 0.1f);
        }
    }
}
