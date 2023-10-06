using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class PlayerController : MonoBehaviour
{

    [SerializeField] float moveSpeed = 10f;
    [SerializeField] float jumpForce = 5f;
    [SerializeField] float climbForce = 5f;

    public Vector2 movement;
    Rigidbody2D rb;
    CapsuleCollider2D playerBodyCollider;
    BoxCollider2D playerFeetCollider;
    SpriteRenderer spriteRenderer;
    Animator animator;
    float startingGravity;

    bool isAlive = true;

    [SerializeField] FixedJoystick joystick;


    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        playerBodyCollider = GetComponent<CapsuleCollider2D>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        animator = GetComponent<Animator>();
        playerFeetCollider = GetComponent<BoxCollider2D>();


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

        if (Input.GetKeyDown(KeyCode.Space))
        {
            Jump();
        }
        if (Input.GetKeyDown(KeyCode.J))
        {
            PlayDeathAnimation();
        }

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

        Debug.Log("Attacking");

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

    
 
   
}
