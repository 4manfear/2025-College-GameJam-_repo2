using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fpp_movement : MonoBehaviour
{
    [Header("Movement Settings")]
    public float moveSpeed = 5f;           // Player movement speed
    //public float jumpForce = 7f;           // Jump strength
    public float gravityMultiplier = 2f;   // Custom gravity

    [Header("Camera Settings")]
    public Transform cameraHolder;         // Assign the empty GameObject holding the camera
    public float mouseSensitivity = 2f;    // Sensitivity of mouse look

    private Rigidbody rb;
    private float horizontalInput;
    private float verticalInput;
    private bool isGrounded;
    private float xRotation = 0f;

    public LayerMask groundMask;  // Layer mask for ground detection

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        rb.freezeRotation = true; // Prevent physics rotation
        Cursor.lockState = CursorLockMode.Locked; // Hide cursor for FPS control
        Cursor.visible = false;
    }

    void Update()
    {
        ProcessInput();
        CheckGround();
        RotateCamera();
    }

    private void FixedUpdate()
    {
        MovePlayer();
        ApplyCustomGravity();
    }

    void ProcessInput()
    {
        horizontalInput = Input.GetAxis("Horizontal");
        verticalInput = Input.GetAxis("Vertical");

        //if (Input.GetKeyDown(KeyCode.Space) && isGrounded)
        //{
        //    Jump();
        //}
    }

    void MovePlayer()
    {
        // Move in the direction the camera is facing
        Vector3 moveDirection = cameraHolder.forward * verticalInput + cameraHolder.right * horizontalInput;
        moveDirection.y = 0; // Prevent unwanted vertical movement

        rb.velocity = new Vector3(moveDirection.x * moveSpeed, rb.velocity.y, moveDirection.z * moveSpeed);
    }

    void Jump()
    {
        //rb.velocity = new Vector3(rb.velocity.x, jumpForce, rb.velocity.z);
    }

    void CheckGround()
    {
        isGrounded = Physics.Raycast(transform.position, Vector3.down, 1.1f, groundMask);
    }

    void ApplyCustomGravity()
    {
        if (!isGrounded)
        {
            rb.velocity += Vector3.down * gravityMultiplier * Time.fixedDeltaTime;
        }
    }

    void RotateCamera()
    {
        float mouseX = Input.GetAxis("Mouse X") * mouseSensitivity;
        float mouseY = Input.GetAxis("Mouse Y") * mouseSensitivity;

        // Rotate player horizontally (left/right)
        transform.Rotate(Vector3.up * mouseX);

        // Rotate camera vertically (up/down) with clamping
        xRotation -= mouseY;
        xRotation = Mathf.Clamp(xRotation, -90f, 90f); // Prevent flipping

        cameraHolder.localRotation = Quaternion.Euler(xRotation, 0f, 0f);
    }
}
