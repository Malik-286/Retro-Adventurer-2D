using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coin : MonoBehaviour
{


    [SerializeField] AudioClip coinCollectionSound;
    [SerializeField] int amountToIncrease;
  
    CurrencyPanelAnimation currencyPanelAnimation;

    [Header("Coin Move Animation")]
    public bool moveCoin = false;
    [SerializeField] float moveSpeed = 5.0f;
    [SerializeField] GameObject moveTargetPosition;

      void Start()
    {
        moveCoin = false;
        currencyPanelAnimation = FindObjectOfType<CurrencyPanelAnimation>();
      }
   
  
    void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.CompareTag("Player"))
        {
            moveCoin = true;
            currencyPanelAnimation.PlayCoinIconAnimation();

            gameObject.GetComponent<CircleCollider2D>().enabled = false;
             if(AudioManager.GetInstance() != null)
            {
                AudioManager.GetInstance().PlaySingleShotAudio(coinCollectionSound, 0.8f);
                if(CurrencyManager.instance)
                {
                    CurrencyManager.instance.IncreaseCoins(amountToIncrease);
                    CurrencyManager.instance.SaveCurrencyData();
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
