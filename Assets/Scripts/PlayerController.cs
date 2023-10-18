using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class PlayerController : MonoBehaviour
{

    [Header("Player Movement Variables")]
    [SerializeField] float moveSpeed = 10f;
    [SerializeField] float jumpForce = 5f;
    [SerializeField] float climbForce = 5f;

    [Header("Bullet Variables")]
    [SerializeField] GameObject bulletPrefeb;
    [SerializeField] Transform bulletSpawnPoint;
    [SerializeField] AudioClip bulletShotAudio;
    [SerializeField] float bulletShotVolume;

 



    public Vector2 movement;
    Rigidbody2D rb;
    CapsuleCollider2D playerBodyCollider;
    BoxCollider2D playerFeetCollider;
    SpriteRenderer spriteRenderer;
    Animator animator;
    float startingGravity;
     
    bool isAlive = true;

    [SerializeField] FloatingJoystick joystick;

    AudioManager audioManager;
    GamePlayUI gamePlayUI;
    void Start()
    {

        rb = GetComponent<Rigidbody2D>();
        playerBodyCollider = GetComponent<CapsuleCollider2D>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        animator = GetComponent<Animator>();
        playerFeetCollider = GetComponent<BoxCollider2D>();
        audioManager =FindObjectOfType<AudioManager>();
        gamePlayUI = FindObjectOfType<GamePlayUI>();
 
        startingGravity = rb.gravityScale;
    }

   

    void Update()
    {

        if (!isAlive)
        {
            return;
        }

        PlayerRunning();
        FlipPlayerSprite();
        ClimbLadder();
 
    }


    public float GetPlayerLocalScale()
    {
        return transform.localScale.x;
    }
    void PlayerRunning()
    {
        movement.x = joystick.Horizontal;          //Input.GetAxis("Horizontal");
        movement.y = joystick.Vertical;           //Input.GetAxis("Vertical");



        rb.velocity = new Vector2(movement.x * moveSpeed, rb.velocity.y);

        bool isMoving = Mathf.Abs(rb.velocity.x) > Mathf.Epsilon;
        animator.SetBool("isRunning", isMoving);

    }

    public void Jump()
    {
        if (CheckIfGrounded())
        {
            rb.velocity = new Vector2(rb.velocity.x, jumpForce);

        }
    }


    public void Attack()
    {
        if(isAlive)
        {
            audioManager.PlaySingleShotAudio(bulletShotAudio, bulletShotVolume);
            Instantiate(bulletPrefeb, bulletSpawnPoint.position, Quaternion.identity);       
                    
        }
    }
    void ClimbLadder()
    {
        if (playerFeetCollider.IsTouchingLayers(LayerMask.GetMask("Ladder")))
        {

            Vector2 climbVelocity = new Vector2(rb.velocity.x, movement.y * climbForce);
            rb.velocity = climbVelocity;
            bool onLadder = Mathf.Abs(rb.velocity.y) > Mathf.Epsilon;
            animator.SetBool("isClimbing", onLadder);
            rb.gravityScale = 0;

        }
        else
        {
            animator.SetBool("isClimbing", false);
            rb.gravityScale = startingGravity;
        }
    }

    bool CheckIfGrounded()
    {
        if (playerFeetCollider.IsTouchingLayers(LayerMask.GetMask("Ground")))
        {
             return true;
        }
        else
        {
            return false;
        }
           

    }

    void FlipPlayerSprite()
    {
        if(movement.x > 0)
        {
             spriteRenderer.flipX = false;
        }
        else if(movement.x < 0) 
        {
             spriteRenderer.flipX = true;
        }

    }

    public void PlayDeathAnimation()
    {
        animator.SetTrigger("isDead");
        isAlive = false;
    }


    void PlayerHealthLoseColor()
    {


    }
    
 
   
}
