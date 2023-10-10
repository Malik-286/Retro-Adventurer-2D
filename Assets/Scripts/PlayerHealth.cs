using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{

    [SerializeField] int currentHealth;
    [SerializeField] AudioClip losehealthSound;
     int maxHealth = 100;
 
     public bool isAlive = true;
    AudioManager audioManager;
      void Start()
    {
        currentHealth = maxHealth;
        audioManager = FindObjectOfType<AudioManager>();
    }


    public float GetCurrentHealth()
    {
        return currentHealth;
    }

    public void IncreaseHealth(int amountToIncrease)
    {
          currentHealth += amountToIncrease;
    }

    public void DecreaseHealth(int amountToDecrease)
    {        
        currentHealth -= amountToDecrease;


        if(currentHealth <= 0)
        {
            isAlive = false;
        }
    }
     void Update()
    {
        if(!isAlive)
        {
            Destroy(gameObject);
            // play player death audio
        }
    }



    void OnCollisionEnter2D(Collision2D collision)
    {
        
        if (collision.gameObject.CompareTag("Enemy")  )
        {
              DecreaseHealth(25);
              audioManager.PlaySingleShotAudio(losehealthSound, 0.7f);
        }
    }

   
}
