using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Enemy : MonoBehaviour
{
    [SerializeField] float moveSpeed = 5f;
     Rigidbody2D rb;
    AudioManager audioManager;
    [SerializeField] AudioClip enemyDeathSound;
    [SerializeField] float enemyHealth = 3;
    [SerializeField] GameObject enemyDeathParticles;
    [SerializeField] float bulletForce;
    public bool bigRoar;

    public HealthFiller EnemyHealthFiller;


    SpriteRenderer enemySprite;
    bool isAlive = true;
    bool isParticlesCreated = false;

    KillsCounter killsCounter;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        enemySprite = GetComponent<SpriteRenderer>();
        audioManager = FindObjectOfType<AudioManager>();
        enemyHealth = Random.Range(3, 5);
        EnemyHealthFiller.setMAXHealth(enemyHealth);
        killsCounter = FindObjectOfType<KillsCounter>();
    }


    public float GetEnemyHealth()
    {
        return enemyHealth;
    }


    

    void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.CompareTag("Ground"))
        {
            FlipEnemiesSprite();
        }
        if(collision.gameObject.CompareTag("Bullet"))
        {
            enemyHealth--;
            rb.AddForce(new Vector2(transform.position.x * bulletForce,0));

            EnemyHealthFiller.SetHealth(enemyHealth);

            if(audioManager != null)
            {
                audioManager.PlaySingleShotAudio(enemyDeathSound, 0.5f);
            } 
            if(enemyHealth <= 0)
            {
                isAlive = false;

            }    
        }
    }




    void OnTriggerExit2D(Collider2D collision)
    {
        FlipEnemiesSprite();
        //transform.localScale = new Vector3(-0.6f,0.6f,0);
    }


    void FixedUpdate()
    {
        if (!isAlive)
        {
            CreateDeathParticles();
 
            Destroy(gameObject, 0.4f);
        }
       
         rb.linearVelocity = new Vector2(moveSpeed, 0.0f);
    }


    void FlipEnemiesSprite()
    {
        moveSpeed = -moveSpeed;

        if (bigRoar)
        {
            if (moveSpeed <= 0)
            {
                enemySprite.flipX = true;
            }
            else if (moveSpeed >= 1)
            {
                enemySprite.flipX = false;
            }
        }
        else
        {
            if (moveSpeed <= 0)
            {
                enemySprite.flipX = false;
            }
            else if (moveSpeed >= 1)
            {
                enemySprite.flipX = true;
            }

        }
    }


    void CreateDeathParticles()
    {
        if(isParticlesCreated == true)
        {          
            return;
        }
        GameObject deathParticlesClone = Instantiate(enemyDeathParticles, transform.position, Quaternion.identity);
        killsCounter.IncreaseKillsCount();
        isParticlesCreated = true;
        if (PlayerLevelManager.instance)
        {
            PlayerLevelManager.instance.IncreasePlayerXp(5);
        }
        Destroy(deathParticlesClone, 0.3f);
    }

    
}
