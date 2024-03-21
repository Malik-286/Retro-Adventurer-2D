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
            rb.velocity = new Vector2(rb.velocity.x, -climbForce);
            animator.SetBool("isClimbing", true);
        }
        else
        {
            // Stop climbing and maintain current vertical velocity
            animator.SetBool("isClimbing", false);
        }
    }
    public void Jump()
    {
        if (CheckIfGrounded())
        {
            animator.SetBool("isClimbing", false);
            rb.velocity = new Vector2(rb.velocity.x, jumpForce);

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

    void OnCollisionEnter2D(Collision2D collision)
    {
         rb.velocity = new Vector2(0f, rb.velocity.y);
    }





}
