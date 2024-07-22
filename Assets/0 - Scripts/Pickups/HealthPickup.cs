using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthPickup : MonoBehaviour
{


    PlayerHealth playerHealth;
    AudioManager audioManager;

    [SerializeField] AudioClip healthPickupSound;
 

    void Start()
    {
        playerHealth = FindObjectOfType<PlayerHealth>();
        audioManager = FindObjectOfType<AudioManager>();

    }



    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
         
            gameObject.GetComponent<CircleCollider2D>().enabled = false;
            
            playerHealth.IncreaseHealth(25);
 
            if (audioManager != null)
            {
                audioManager.PlaySingleShotAudio(healthPickupSound, 1.0f);

            }
             Destroy(gameObject, 0.2f);
        }


    }

    
}
