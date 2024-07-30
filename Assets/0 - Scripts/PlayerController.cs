using System.Collections;
using UnityEngine;
 
public class PlayerController : MonoBehaviour
{

    [Header("Player Movement Variables")]
    [SerializeField] float moveSpeed = 10f;
    [SerializeField] float jumpForce = 5f;
    [SerializeField] float climbForce = 5f;
    [SerializeField] AudioClip jumpSoundEffect;
 

    [Header("Player Particle Effects Variables")]

    [SerializeField] Transform dustParticlesPosition;
    [SerializeField] GameObject dustParticlesPrefeb;
    [SerializeField] GameObject safeZoneParticlesPrefeb;


    [Header("Bullet Variables")]

    [SerializeField] GameObject blueBulletPrefeb;
    [SerializeField] GameObject yellowBulletPrefeb;

    [SerializeField] Transform bulletSpawnPoint;
    [SerializeField] AudioClip bulletShotAudio;
    [SerializeField] float bulletShotVolume;


    [SerializeField] public bool isBlueBulletActive;
    [SerializeField] public bool isYellowBulletActive;



    private bool moveLeftPressed = false;
    private bool moveRightPressed = false;
    private bool moveUpPressed = false;
    private bool moveDownPressed = false;

    public Vector2 movement;
    Rigidbody2D rb;
    BoxCollider2D playerFeetCollider;
    SpriteRenderer spriteRenderer;
    public Animator animator;
    float startingGravity;
 
    bool isAlive = true;


     void Start()
    {
        isBlueBulletActive = false;
        isYellowBulletActive = false;

        rb = GetComponent<Rigidbody2D>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        animator = GetComponent<Animator>();
        playerFeetCollider = GetComponent<BoxCollider2D>();
  
        safeZoneParticlesPrefeb.SetActive(false);

        startingGravity = rb.gravityScale;

    }



    void FixedUpdate()
    {
        if (!isAlive)
        {
            return;
        }

        PlayerMoving();
        FlipPlayerSprite();
        ClimbLadder();
        PlayerMovingUpward();
        PlayerMovingDownward();
    }


    #region Player Movement Methods
    public void StopMoving()
    {
        movement.x = 0f;
    }

    public void MoveLeftPressed()
    {
        moveLeftPressed = true;
    }

    public void MoveLeftReleased()
    {
        moveLeftPressed = false;
        StopMoving();
    }

    public void MoveRightPressed()
    {
        moveRightPressed = true;
    }

    public void MoveRightReleased()
    {
        moveRightPressed = false;
        StopMoving();
    }


    public float GetPlayerLocalScale()
    {
        return transform.localScale.x;
    }


    public void MoveLeft()
    {
        movement.x = -1f;
    }


    public void MoveRight()
    {
        movement.x = 1f;
    }



    public void MoveUpPressed()
    {
        moveUpPressed = true;
    }

    public void MoveUpReleased()
    {
        moveUpPressed = false;
    }


    public void MoveDownPressed()
    {
        moveDownPressed = true;
    }

    public void MoveDownReleased()
    {
        moveDownPressed = false;
    }

    #endregion

    void PlayerMoving()
    {
        // If both buttons are pressed, or neither is pressed, stop moving
        if ((moveLeftPressed && moveRightPressed) || (!moveLeftPressed && !moveRightPressed))
        {
            StopMoving();
            animator.SetBool("isRunning", false);
            animator.SetBool("isJumping", false);
 
            animator.SetBool("isIdeling", true);

        }
        else if (moveLeftPressed)
        {
            MoveLeft();
 
        }
        else if (moveRightPressed)
        {
            MoveRight();
 
        }

        rb.velocity = new Vector2(movement.x * moveSpeed, rb.velocity.y);

        bool isMoving = Mathf.Abs(rb.velocity.x) > Mathf.Epsilon;

 
        animator.SetBool("isRunning", isMoving);      
         
    }


    void PlayerMovingUpward()
    {
        if (playerFeetCollider.IsTouchingLayers(LayerMask.GetMask("Ladder")) && moveUpPressed)
        {

            rb.velocity = new Vector2(rb.velocity.x, climbForce);
            animator.SetBool("isIdeling", false);
            animator.SetBool("isJumping", false);
 

            animator.SetBool("isClimbing", true);
        }
        else
        {
            animator.SetBool("isClimbing", false);
        }
    }
    void PlayerMovingDownward()
    {
        if (playerFeetCollider.IsTouchingLayers(LayerMask.GetMask("Ladder")) && moveDownPressed)
        {
            // Climb down the ladder

            playerFeetCollider.isTrigger = false;
            rb.velocity = new Vector2(rb.velocity.x, -climbForce);
            animator.SetBool("isIdeling", false);
            animator.SetBool("isJumping", false);
 

            animator.SetBool("isClimbing", true);
        }
       
    }
    public void Jump()
    {

        if (CheckIfGrounded())
        {
            animator.SetBool("isClimbing", false);
            animator.SetBool("isIdeling", false);
            animator.SetBool("isRunning", false);

            
            rb.velocity = new Vector2(rb.velocity.x, jumpForce);
            animator.SetBool("isJumping", true);
            CreateDustParticles();
            if (AudioManager.GetInstance())
            {
                AudioManager.GetInstance().PlaySingleShotAudio(jumpSoundEffect, 1.0f);
            }

        }
        else
        {
            animator.SetBool("isJumping", false);

        }
    }


    public void Attack()
    {
        if (isAlive)
        {
            if(isBlueBulletActive == true || isYellowBulletActive == true)
            {
                if(AudioManager.GetInstance())
                {
                    AudioManager.GetInstance().PlaySingleShotAudio(bulletShotAudio, bulletShotVolume);

                }
            }
            else
            {
                return;
            }
             
           
            // instantiate blue bullet
            if(isBlueBulletActive == true)
            {
                GameObject blueBulletClone = Instantiate(blueBulletPrefeb, bulletSpawnPoint.position, Quaternion.identity);
                Destroy(blueBulletClone, 5f);
                return;
            }
            else if (isYellowBulletActive == true)
            {
                // instantiate yellow bullet

                GameObject yellowBulletClone = Instantiate(yellowBulletPrefeb, bulletSpawnPoint.position, Quaternion.identity);
                Destroy(yellowBulletClone, 1f);
                return;
            }
                 

        }
    }
    void ClimbLadder()
    {
        if (playerFeetCollider.IsTouchingLayers(LayerMask.GetMask("Ladder")))
        {

            playerFeetCollider.isTrigger = false;

            Vector2 climbVelocity = new Vector2(rb.velocity.x, movement.y * climbForce);
            rb.velocity = climbVelocity;
            bool onLadder = Mathf.Abs(rb.velocity.y) > Mathf.Epsilon;
            animator.SetBool("isClimbing", onLadder);
            rb.gravityScale = 0;

        }
        else
        {
    
            rb.gravityScale = startingGravity;
            playerFeetCollider.isTrigger = false;

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
        if(isAlive == false)
        {
            // Stop all the other animations
            string[] states = { "isClimbing", "isIdeling", "isRunning", "isJumping", "isRolling" };

            foreach (var state in states)
            {
                animator.SetBool(state, false);
            }

            animator.SetBool("isDead", true);
            isAlive = false;
        }
        else
        {
            return;
        }
         
    }


    void CreateDustParticles()
    {
        
        GameObject dustParticlesClone = Instantiate(dustParticlesPrefeb, dustParticlesPosition.position, Quaternion.identity);
        Destroy(dustParticlesClone, 1f);
    }


    public GameObject  GetSafeZoneParticlesPrefeb()
    {
        return safeZoneParticlesPrefeb;
    }
}
