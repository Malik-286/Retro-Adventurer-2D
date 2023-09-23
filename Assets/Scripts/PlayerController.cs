using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class PlayerController : MonoBehaviour
{

    [SerializeField] float moveSpeed = 10f;
    [SerializeField] float jumpForce = 5f;
    public Vector2 movement;
    Rigidbody2D rb;
    CapsuleCollider2D capsuleCollider;
 
    [SerializeField] FixedJoystick joystick;


     void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        capsuleCollider = GetComponent<CapsuleCollider2D>();
    }

     void Update()
    {
        PlayerMovement();
    }

    void PlayerMovement()
    {
        movement.x = joystick.Horizontal;
       
        transform.Translate(movement * moveSpeed * Time.deltaTime);
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

    }


    bool CheckIfGrounded()
    { 
         if(capsuleCollider.IsTouchingLayers(LayerMask.GetMask("Ground")))
        {
            return true;
        }else
        {
            return false;
        }
            


    }
}
