using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fpp_movement : MonoBehaviour
{
    [Header("Movement Settings")]
    public float moveSpeed ;            // Player movement speed
    public float gravityMultiplier ;    // Custom gravity
    public float maxSlopeAngle ;       // Maximum walkable slope angle

    [Header("Camera Settings")]
    public Transform cameraHolder;          // Assign the empty GameObject holding the camera
    public float mouseSensitivity ;     // Sensitivity of mouse look

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
        //Cursor.lockState = CursorLockMode.Locked; // Hide cursor for FPS control
        //Cursor.visible = false;
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
    }

    void MovePlayer()
    {
        // Get movement direction based on camera rotation
        Vector3 moveDirection = cameraHolder.forward * verticalInput + cameraHolder.right * horizontalInput;
        moveDirection.y = 0; // Prevent unwanted vertical movement

        if (OnSlope(out RaycastHit slopeHit))
        {
            moveDirection = Vector3.ProjectOnPlane(moveDirection, slopeHit.normal);
        }

        Vector3 targetVelocity = moveDirection.normalized * moveSpeed;
        rb.velocity = new Vector3(targetVelocity.x, rb.velocity.y, targetVelocity.z);
    }

    void CheckGround()
    {
        isGrounded = Physics.Raycast(transform.position, Vector3.down, 1.1f, groundMask);
    }

    void ApplyCustomGravity()
    {
        if (!isGrounded)
        {
            rb.AddForce(Vector3.down * gravityMultiplier, ForceMode.Acceleration);
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

    bool OnSlope(out RaycastHit slopeHit)
    {
        if (Physics.Raycast(transform.position, Vector3.down, out slopeHit, 1.5f, groundMask))
        {
            float slopeAngle = Vector3.Angle(Vector3.up, slopeHit.normal);
            return slopeAngle > 0 && slopeAngle <= maxSlopeAngle;
        }
        return false;
    }
}
