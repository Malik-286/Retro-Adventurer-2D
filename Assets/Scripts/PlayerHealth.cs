using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{

    [SerializeField] int currentHealth;
    [SerializeField] int maxHealth = 100;
    [SerializeField] AudioClip losehealthSound;
    public bool isAlive = true;


    [Header("Colors Variables")]
    [SerializeField] Color defaultColor;
 

    
 
      
    AudioManager audioManager;
    SpriteRenderer spriteRenderer;
    GameManager gameManager;
    TimerPanel timerPanel;
    void Start()
    {
        currentHealth = maxHealth;
        audioManager = FindObjectOfType<AudioManager>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        defaultColor = spriteRenderer.color;
        gameManager = FindObjectOfType<GameManager>();
        timerPanel = FindObjectOfType<TimerPanel>();    

    }


    public int  GetCurrentHealth()
    {
        return currentHealth;
    }
    public int GetMaxHealth()
    {
        return maxHealth;
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
            gameManager.ReloadGame();
            timerPanel.RestTime();
            Destroy(gameObject, 1f);
            
            // play player death audio and animation
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
