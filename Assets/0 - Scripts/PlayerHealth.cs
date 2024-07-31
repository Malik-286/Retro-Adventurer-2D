using hardartcore.CasualGUI;
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

    [Header("Player Health Damage Variables")]
    [SerializeField] float damageCooldown = 3.0f; // 3 to 4 seconds delay
    private bool canTakeDamage = true; // Flag to control damage cooldown

    SpriteRenderer spriteRenderer;
    GameManager gameManager;
    TimerPanel timerPanel;
    public GameObject deathPanel;
    public GameObject detailsPanel;
    ScreenShake screenShake;

    public bool isDeathPanelActive;


    bool isGamePaused = false;

    void Start()
    {
        currentHealth = maxHealth;
        spriteRenderer = GetComponent<SpriteRenderer>();
        defaultColor = spriteRenderer.color;
        gameManager = FindObjectOfType<GameManager>();
        timerPanel = FindObjectOfType<TimerPanel>();
        deathPanel.SetActive(false);
        screenShake = FindObjectOfType<ScreenShake>();
        isDeathPanelActive = false;
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

            gameObject.GetComponent<Animator>().SetBool("isRunning", false);
            gameObject.GetComponent<Animator>().SetBool("isJumping", false);
            gameObject.GetComponent<Animator>().SetBool("isIdeling", true);
        }
    }
    void Update()
    {

        if (!isAlive && !isDeathPanelActive)
        {
            isDeathPanelActive = true;
            gameObject.GetComponent<Animator>().SetBool("isDead", true);

            deathPanel.GetComponent<Dialog>().ShowDialog();

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
        else if (isAlive && isDeathPanelActive)
        {
            // Revive logic
            isDeathPanelActive = false;
            gameObject.GetComponent<Animator>().SetBool("isDead", false);

            // Ensure all other animations are reset
            gameObject.GetComponent<Animator>().SetBool("isRunning", false);
            gameObject.GetComponent<Animator>().SetBool("isJumping", false);

            // Set idle state
            gameObject.GetComponent<Animator>().SetBool("isIdeling", true);

            // Optionally, reset player position or other states
        }

    }


 

    void OnCollisionEnter2D(Collision2D collision)
    {

        if (collision.gameObject.CompareTag("Enemy") && GetComponent<PlayerHealth>().enabled && canTakeDamage)
        {
            DecreaseHealth(25);
            spriteRenderer.color = Color.red;
            StartCoroutine(ResetPlayerColor());

            if (isAlive)
            {
                AudioManager.GetInstance().PlaySingleShotAudio(losehealthSound, 0.6f);
            }

            // Start cooldown
            StartCoroutine(DamageCooldown());
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

    IEnumerator DamageCooldown()
    {
        canTakeDamage = false;
        yield return new WaitForSeconds(damageCooldown);
        canTakeDamage = true;
    }

}
