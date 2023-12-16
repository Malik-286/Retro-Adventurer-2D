using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    [SerializeField] float bulletSpeed = 20f;
    [SerializeField] GameObject bulletParticles;
     PlayerController player;
    Rigidbody2D rb;
    SpriteRenderer spriteRenderer;
    float bulletDirection  = 1;
    bool isCreated = false;


    AudioManager audioManager;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        player = FindObjectOfType<PlayerController>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        audioManager = FindObjectOfType<AudioManager>();
        SetBulletDirection();
 

    }

    void Update()
    {
        rb.velocity = new Vector2(bulletDirection * bulletSpeed, 0);


    }

    void SetBulletDirection()
    {
        if (player.GetComponent<SpriteRenderer>().flipX == false)
        {
            bulletDirection = bulletDirection * bulletSpeed;
            spriteRenderer.flipX = true;
        }
        else if (player.GetComponent<SpriteRenderer>().flipX == true)
        {
            bulletDirection = -bulletDirection * bulletSpeed;
            spriteRenderer.flipX = false;
        }
    }


    void OnCollisionEnter2D(Collision2D collision)
    {
        CreateDestroyParticles();      
         Destroy(gameObject, 0.1f);
    }

    void CreateDestroyParticles()
    {
        if(isCreated == false)
        {
            GameObject deathParticlesClone = Instantiate(bulletParticles, transform.position, Quaternion.identity);
            isCreated = true;
            Destroy(deathParticlesClone, 0.2f);
        } 
    }


    




}
