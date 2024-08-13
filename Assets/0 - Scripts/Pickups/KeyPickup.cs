using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeyPickup : MonoBehaviour
{


    [SerializeField] AudioClip keyCollectionSound;
 
   
     public bool isKeyCollected = false;

     [SerializeField] GameObject exitCheckPoint;
     [SerializeField] GameObject particles;

    
    SpriteRenderer spriteRenderer;
    CircleCollider2D circleCollider;

 
    void Start()
    {
         exitCheckPoint.SetActive(false);
         isKeyCollected = false;
        spriteRenderer = GetComponent<SpriteRenderer>();
        circleCollider = GetComponent<CircleCollider2D>();
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
            
            circleCollider.enabled = false;
            spriteRenderer.enabled = false;         
             Destroy(particles);
            Destroy(gameObject, 1.0f);
        }
    }
 

}
