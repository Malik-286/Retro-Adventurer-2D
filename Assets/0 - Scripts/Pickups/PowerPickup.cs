using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerPickup : MonoBehaviour
{


    [SerializeField] AudioClip powerPickupSound;
 
 
    PlayerController playerController;

     

    void Start()
    {
        StartCoroutine(PassPlayerControllerRefrence());
    }


    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
              if (AudioManager.GetInstance())
            {
                AudioManager.GetInstance().PlaySingleShotAudio(powerPickupSound, 0.8f);
                 
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

    IEnumerator PassPlayerControllerRefrence()
    {
        yield return new WaitForSeconds(0.1f);
        playerController = FindObjectOfType<PlayerController>();
        if (playerController == null)
        {
            Debug.LogError("Player Controller not found in the scene.");
        }
    }






}
