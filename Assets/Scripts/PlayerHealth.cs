using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{

    [SerializeField] int currentHealth;
    [SerializeField] int maxHealth = 125;
    [SerializeField] AudioClip losehealthSound;
    public bool isAlive = true;


    [Header("Colors Variables")]
    [SerializeField] Color defaultColor;
 

    
 
      
    AudioManager audioManager;
    SpriteRenderer spriteRenderer;
      void Start()
    {
        currentHealth = maxHealth;
        audioManager = FindObjectOfType<AudioManager>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        defaultColor = spriteRenderer.color;

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
              spriteRenderer.color = Color.red;
              StartCoroutine(ResetPlayerColor());
              audioManager.PlaySingleShotAudio(losehealthSound, 0.7f);
        }
    }

  

    IEnumerator ResetPlayerColor()
    {
        if (isAlive)
        {
            yield return new WaitForSeconds(0.50f);
            spriteRenderer.color = defaultColor;
        }
    }


}
