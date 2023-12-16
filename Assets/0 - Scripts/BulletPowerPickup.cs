using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BulletPowerPickup : MonoBehaviour
{

    [SerializeField] Button attackButton;
    [SerializeField] AudioClip powerPickupSFX;
 


    AudioManager audioManager;
      void Start()
    {
        attackButton.interactable = false;
        audioManager = FindObjectOfType<AudioManager>();
    }
    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            audioManager.PlaySingleShotAudio(powerPickupSFX, 1.0f);
            attackButton.interactable = true;
             Destroy(gameObject);
        }
    }
}
