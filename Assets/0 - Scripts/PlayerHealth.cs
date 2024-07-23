using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{

    [SerializeField] int currentHealth;
    [SerializeField] int maxHealth = 100;
    [SerializeField] AudioClip losehealthSound;
    public bool isAlive = true;
    [SerializeField] ParticleSystem playerSafeGuardParticles;

    [Header("Colors Variables")]
    [SerializeField] Color defaultColor;


 

    AudioManager audioManager;
    SpriteRenderer spriteRenderer;
    GameManager gameManager;
    TimerPanel timerPanel;
    public GameObject deathPanel;
    public GameObject detailsPanel;
    ScreenShake screenShake;
    void Start()
    {
        currentHealth = maxHealth;
        audioManager = FindObjectOfType<AudioManager>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        defaultColor = spriteRenderer.color;
        gameManager = FindObjectOfType<GameManager>();
        timerPanel = FindObjectOfType<TimerPanel>();
        deathPanel.SetActive(false);
        screenShake = FindObjectOfType<ScreenShake>();
    }


    public int GetCurrentHealth()
    {
        return currentHealth;
    }
    public int GetMaxHealth()
    {
        return maxHealth;
    }

    public void IncreaseHealth(int amountToIncrease)
    {
        if (currentHealth >= maxHealth)
        {
            currentHealth = maxHealth;
            return;
        }
        else
        {
            currentHealth += amountToIncrease;
        }
        
    }

    public void DecreaseHealth(int amountToDecrease)
    {
        currentHealth -= amountToDecrease;

        if(screenShake != null)
        {
            screenShake.source.GenerateImpulse();
        }
 
        if (this.currentHealth <= 0)
        {
            currentHealth = 0;
            isAlive = false;
        }
    }
    void FixedUpdate()
    {
        if (!isAlive)
        {
            Time.timeScale = 0;
            deathPanel.SetActive(true);
            if (deathPanel.activeInHierarchy)
            {  
                detailsPanel.SetActive(false);  
                return;
            }
            detailsPanel.SetActive(true);

            Time.timeScale = 1;
            gameManager.ReloadGame();
            timerPanel.RestTime();
            Destroy(gameObject, 1f);

        }
    }

   





    void OnCollisionEnter2D(Collision2D collision)
    {

        if (collision.gameObject.CompareTag("Enemy") && GetComponent<PlayerHealth>().enabled)
        {
            DecreaseHealth(25);
            spriteRenderer.color = Color.red;
            StartCoroutine(ResetPlayerColor());
            audioManager.PlaySingleShotAudio(losehealthSound, 0.7f);
        }
    }


    
    IEnumerator ResetPlayerColor()
    {      
            yield return new WaitForSeconds(0.40f);
            spriteRenderer.color = defaultColor;
        
    }

    IEnumerator EnableAndDisablePlayerHealth()
    {
        GetComponent<PlayerHealth>().enabled = false;
        playerSafeGuardParticles.Play();
        yield return new WaitForSeconds(4f);
        GetComponent<PlayerHealth>().enabled = true;
        playerSafeGuardParticles.Stop();

    }

    public void EnableAndDisablePlayerHealthComponent()
    {
        StartCoroutine(EnableAndDisablePlayerHealth());
    }


}
