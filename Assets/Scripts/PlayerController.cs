using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class PlayerController : MonoBehaviour
{

    [SerializeField] float moveSpeed = 10f;
    [SerializeField] float jumpForce = 20f;
    public Vector2 movement;
    Rigidbody2D rb;

    [SerializeField] FixedJoystick joystick;


     void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

     void Update()
    {
        PlayerMovement();
    }

    void PlayerMovement()
    {
        movement.x = joystick.Horizontal;
        movement.y = joystick.Vertical;

         transform.Translate(movement * moveSpeed * Time.deltaTime);
    }

    public void Jump()
    {
          rb.MovePosition(rb.position + new Vector2(0f,10f) * (jumpForce * Time.fixedDeltaTime));
    }
    public void Attack()
    {

     }
}
