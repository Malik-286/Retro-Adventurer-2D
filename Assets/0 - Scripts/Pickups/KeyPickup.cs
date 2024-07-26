using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeyPickup : MonoBehaviour
{


    [SerializeField] AudioClip keyCollectionSound;
 
   
     public bool isKeyCollected = false;

     [SerializeField] GameObject exitCheckPoint;

    void Start()
    {
         exitCheckPoint.SetActive(false);
         isKeyCollected = false;
 
    }


    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            isKeyCollected = true;
            exitCheckPoint.SetActive(isKeyCollected);
            gameObject.GetComponent<CircleCollider2D>().enabled = false;
            if (AudioManager.GetInstance() != null)
            {
                AudioManager.GetInstance().PlaySingleShotAudio(keyCollectionSound, 1.0f);
              
            }
             Destroy(gameObject);
        }
    }
 

}
