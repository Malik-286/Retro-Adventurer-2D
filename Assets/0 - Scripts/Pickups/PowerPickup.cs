using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerPickup : MonoBehaviour
{


    [SerializeField] AudioClip powerPickupSound;
 
    AudioManager audioManager;

    PlayerController playerController;

     

    void Start()
    {
         audioManager = FindObjectOfType<AudioManager>();
         playerController = FindObjectOfType<PlayerController>();
    }


    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
              if (audioManager != null)
            {
                audioManager.PlaySingleShotAudio(powerPickupSound, 0.8f);
                 
            }


            if (this.gameObject.CompareTag("PowerPickupGreen"))
            {
                // enable safezone here
                if(playerController != null)
                {
                    playerController.GetSafeZoneParticlesPrefeb().SetActive(true);

                }
            }
            else if (this.gameObject.CompareTag("PowerPickupYellow"))
            {

                // enable fireball here
                if (playerController != null)
                {
                    playerController.isBlueBulletActive = false;

                    playerController.isYellowBulletActive = true;


                }
            }
            else if (this.gameObject.CompareTag("PowerPickupBlue"))
            {
                // enable blue bullet here
                if (playerController != null)
                {
                    playerController.isYellowBulletActive = false;

                    playerController.isBlueBulletActive = true;

                }
            }

            Destroy(gameObject, 0.1f);
        }
    }


 



}
