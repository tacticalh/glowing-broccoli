using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public CharacterController controller;

    public float speed = 12f;
    public float gravity = -9.81f;
    public float jumpHeight = 3f;

    public Transform groundCheck;
    public Transform orientation;
    public float groundDistance = 0.4f;
    public LayerMask groundMask;

    float horizontalInput;
    float verticalInput;

    Vector3 velocity;

    bool isGrounded;

    void Update()
    {
        isGrounded = Physics.CheckSphere(groundCheck.position, groundDistance, groundMask);

        if(isGrounded && velocity.y <0)
        {
            velocity.y = -2f;
        }

        horizontalInput = Input.GetAxis("Horizontal");
        verticalInput = Input.GetAxis("Vertical");

       

        Vector3 move = transform.right * horizontalInput + transform.forward *verticalInput;
        move = orientation.forward * verticalInput + orientation.right * horizontalInput;

        controller.Move(move* speed * Time.deltaTime);

        if(Input.GetButtonDown("Jump") && isGrounded)
        {
            velocity.y = Mathf.Sqrt(jumpHeight * -2f * gravity);
        }

        velocity.y += gravity *Time.deltaTime;
        // Debug.Log(1/Time.deltaTime); --framerate
        controller.Move(velocity * Time.deltaTime);

        if(Input.GetKeyDown(KeyCode.LeftShift))
        {
            speed = speed*2;
        }
        if(Input.GetKeyUp(KeyCode.LeftShift))
        {
            speed = speed/2;
        }
        

    }
}
