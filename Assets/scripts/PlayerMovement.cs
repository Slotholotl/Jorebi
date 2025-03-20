using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [Header("Movement Settings")]
    public float walkSpeed = 4f;
    public float sprintSpeed = 7f;
    public float crouchSpeed = 2f;
    private float moveSpeed;

    [Header("Jump & Gravity")]
    public float jumpHeight = 2.5f;
    public float gravity = -9.81f;
    private Vector3 velocity;
    private bool isGrounded;

    [Header("Crouching")]
    public float crouchHeight = 1f;
    public float standingHeight = 2f;
    public bool isCrouching = false;

    [Header("References")]
    public CharacterController controller;
    public Transform groundCheck;
    public LayerMask groundMask;
    public Transform cameraReference; // New: Use a reference for movement direction

    private float groundDistance = 0.4f;

    void Start()
    {
        moveSpeed = walkSpeed;
    }

    void Update()
    {
        HandleMovement();
        HandleJumping();
        HandleCrouching();
        ApplyGravity();
    }

    void HandleMovement()
    {
        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");

        // Move relative to the camera’s forward direction
        Vector3 move = cameraReference.forward * z + cameraReference.right * x;
        move.y = 0; // Prevent unwanted vertical movement

        controller.Move(move.normalized * moveSpeed * Time.deltaTime);

        if (Input.GetKey(KeyCode.LeftShift) && !isCrouching)
        {
            moveSpeed = sprintSpeed;
        }
        else if (isCrouching)
        {
            moveSpeed = crouchSpeed;
        }
        else
        {
            moveSpeed = walkSpeed;
        }
    }

    void HandleJumping()
    {
        isGrounded = Physics.CheckSphere(groundCheck.position, groundDistance, groundMask);

        if (isGrounded && velocity.y < 0)
        {
            velocity.y = -2f;
        }

        if (Input.GetKeyDown(KeyCode.Space) && isGrounded && !isCrouching)
        {
            velocity.y = Mathf.Sqrt(jumpHeight * -2f * gravity);
        }
    }

    void HandleCrouching()
    {
        if (Input.GetKeyDown(KeyCode.LeftControl))
        {
            isCrouching = true;
            controller.height = crouchHeight;
        }
        else if (Input.GetKeyUp(KeyCode.LeftControl))
        {
            isCrouching = false;
            controller.height = standingHeight;
        }
    }

    void ApplyGravity()
    {
        velocity.y += gravity * Time.deltaTime;
        controller.Move(velocity * Time.deltaTime);
    }
}
