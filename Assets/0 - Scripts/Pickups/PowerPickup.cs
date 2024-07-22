using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerPickup : MonoBehaviour
{


    [SerializeField] AudioClip powerPickupSound;
 
    AudioManager audioManager;
   

    void Start()
    {
         audioManager = FindObjectOfType<AudioManager>();
    }


    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
 
             if (audioManager != null)
            {
                audioManager.PlaySingleShotAudio(powerPickupSound, 0.8f);
                 
            }
            Destroy(gameObject, 0.1f);
        }
    }


 
}
