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


    [Header("Rewards Array")]
    [SerializeField] GameObject[] rewrdsPrefebs;
 
    SpriteRenderer enemySprite;
    bool isAlive = true;
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        enemySprite = GetComponent<SpriteRenderer>();
        audioManager = FindObjectOfType<AudioManager>();
        enemyHealth = Random.Range(3, 5);
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
        transform.localScale = new Vector3(-0.6f,0.6f,0);
    }


    void FixedUpdate()
    {
        if (!isAlive)
        {
            CreateDeathParticles();
 
            Destroy(gameObject, 0.4f);
        }
       
         rb.velocity = new Vector2(moveSpeed, 0.0f);
    }


    void FlipEnemiesSprite()
    {
        moveSpeed = -moveSpeed;
        if (moveSpeed <= 0)
        {
            enemySprite.flipX = false;
        }
        else if (moveSpeed >= 1)
        {
            enemySprite.flipX = true;
        }
    }


    void CreateDeathParticles()
    {
        GameObject deathParticlesClone = Instantiate(enemyDeathParticles, transform.position, Quaternion.identity);
        Destroy(deathParticlesClone, 0.3f);
    }

    
}
