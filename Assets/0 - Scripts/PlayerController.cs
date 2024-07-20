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



    private bool moveLeftPressed = false;
    private bool moveRightPressed = false;
    private bool moveUpPressed = false;
    private bool moveDownPressed = false;

    public Vector2 movement;
    Rigidbody2D rb;
    BoxCollider2D playerFeetCollider;
    SpriteRenderer spriteRenderer;
    Animator animator;
    float startingGravity;

    bool isAlive = true;


    AudioManager audioManager;
    void Start()
    {

        rb = GetComponent<Rigidbody2D>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        animator = GetComponent<Animator>();
        playerFeetCollider = GetComponent<BoxCollider2D>();
        audioManager = FindObjectOfType<AudioManager>();

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

            playerFeetCollider.isTrigger = true;
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
            audioManager.PlaySingleShotAudio(bulletShotAudio, bulletShotVolume);
            Instantiate(bulletPrefeb, bulletSpawnPoint.position, Quaternion.identity);

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
            animator.SetBool("isClimbing", false);
            animator.SetBool("isJumping", false);

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
        // Stop all the other animations
        animator.SetBool("isClimbing",false);
        animator.SetBool("isIdeling", false);
        animator.SetBool("isRunning", false);
        animator.SetBool("isJumping", false);
        animator.SetBool("isRolling", false);



        animator.SetTrigger("isDead");
        isAlive = false;
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
       //  rb.velocity = new Vector2(0f, rb.velocity.y);
    }


    public void RollingMovement()
    {
        animator.SetBool("isClimbing", false);
        animator.SetBool("isIdeling", false);
        animator.SetBool("isRunning", false);
        animator.SetBool("isJumping", false);
        animator.SetBool("isRolling", true);
        
        StartCoroutine(DeActivateRollingAnimation());
        
    }


    IEnumerator DeActivateRollingAnimation()
    {
         yield return new WaitForSeconds(0.1f);
         animator.SetBool("isRolling", false);
         Debug.Log("Rolling Animation Stopped");

    }




}
