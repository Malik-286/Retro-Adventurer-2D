using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coin : MonoBehaviour
{


    [SerializeField] AudioClip coinCollectionSound;
    [SerializeField] int amountToIncrease;
  
    AudioManager audioManager;
    CurrencyManager currencyManager;
    CurrencyPanelAnimation currencyPanelAnimation;

    [Header("Coin Move Animation")]
    public bool moveCoin = false;
    [SerializeField] float moveSpeed = 5.0f;
    [SerializeField] GameObject moveTargetPosition;

      void Start()
    {
        moveCoin = false;
        audioManager = FindObjectOfType<AudioManager>();
        currencyManager = FindObjectOfType<CurrencyManager>();
        currencyPanelAnimation = FindObjectOfType<CurrencyPanelAnimation>();
      }
   
  
    void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.CompareTag("Player"))
        {
            moveCoin = true;
            currencyPanelAnimation.PlayCoinIconAnimation();

            gameObject.GetComponent<CircleCollider2D>().enabled = false;
             if(audioManager != null)
            {
                audioManager.PlaySingleShotAudio(coinCollectionSound, 0.8f);
                if(currencyManager != null)
                {
                     
                    currencyManager.IncreaseCoins(amountToIncrease);
                    currencyManager.SaveCurrencyData();
                }           
            }
                 Destroy(gameObject, 0.5f);
        }
    }


    void Update()
    {
        MoveCoin();
    }
    void MoveCoin()
    {
        if (moveCoin == true)
        {
            transform.position = Vector3.Lerp(transform.position, moveTargetPosition.transform.position, moveSpeed * Time.deltaTime);
            
        }
    }




}
