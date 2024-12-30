using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    [Header("Movement Settings")]
    public float moveSpeed = 5.0f;   // Player movement speed
    public float jumpForce = 5.0f;   // Force applied for jumping
    public int maxJumps = 2;         // Maximum number of jumps allowed

    private PlayerInputActions inputActions;  // Reference to generated input actions
    private Rigidbody rb;                     // Reference to the Rigidbody component
    private Vector2 moveInput;                // To store movement input
    private bool isGrounded = true;           // Ground check
    private int jumpCount = 0;                // Track number of jumps since last grounded

    [Header("References")]
    // Make sure this is the same "playerBody" the CameraController is rotating
    public Transform playerBody;

    void Awake()
    {
        // Initialize the Input Actions and Rigidbody
        inputActions = new PlayerInputActions();
        rb = GetComponent<Rigidbody>();
        if (rb == null)
        {
            Debug.LogError("Rigidbody component is missing from the Player GameObject.");
        }
    }

    void OnEnable()
    {
        inputActions.Enable();
        // Register movement and jump actions
        inputActions.Player.Move.performed += OnMove;
        inputActions.Player.Move.canceled += OnMove;
        inputActions.Player.Jump.performed += OnJump;
    }

    void OnDisable()
    {
        // Unregister
        inputActions.Player.Move.performed -= OnMove;
        inputActions.Player.Move.canceled -= OnMove;
        inputActions.Player.Jump.performed -= OnJump;

        inputActions.Disable();
    }

    private void OnMove(InputAction.CallbackContext context)
    {
        // Store the movement input in a Vector2
        moveInput = context.ReadValue<Vector2>();
    }

    private void OnJump(InputAction.CallbackContext context)
    {
        if (jumpCount < maxJumps)
        {
            Debug.Log("Jumping!");
            rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
            jumpCount++;
            isGrounded = false;
        }
    }

    private void FixedUpdate()
    {
        // Log the raw input for debugging
        Debug.Log($"Move Input: {moveInput}");

        // 1) Create a "local" movement vector from input (X, Z)
        Vector3 localMovement = new Vector3(moveInput.x, 0f, moveInput.y);

        // 2) Transform it by the player's orientation (playerBody)
        //    so "forward" is the direction the playerBody is facing.
        Vector3 movement = playerBody.TransformDirection(localMovement)
                           * moveSpeed
                           * Time.fixedDeltaTime;

        // 3) Move the Rigidbody
        rb.MovePosition(rb.position + movement);
    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            isGrounded = true;
            jumpCount = 0;
        }
    }

    void Start()
    {
        // Zero out any leftover velocity on start
        rb.linearVelocity = Vector3.zero;
        rb.angularVelocity = Vector3.zero;
    }
}
