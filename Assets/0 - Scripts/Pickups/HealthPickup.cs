using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthPickup : MonoBehaviour
{


    PlayerHealth playerHealth;
 
    [SerializeField] AudioClip healthPickupSound;


    void Start()
    {
        playerHealth = FindObjectOfType<PlayerHealth>();
 
    }



    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
         
            gameObject.GetComponent<CircleCollider2D>().enabled = false;
            
            playerHealth.IncreaseHealth(25);
 
            if (AudioManager.GetInstance())
            {
                AudioManager.GetInstance().PlaySingleShotAudio(healthPickupSound, 1.0f);

            }
             Destroy(gameObject, 0.2f);
        }


    }

    
}
