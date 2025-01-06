using UnityEngine;
using UnityEngine.InputSystem;

public class CameraController : MonoBehaviour
{
    // Reference to the generated input actions
    private PlayerInputActions inputActions;

    [Header("References")]
    public Transform playerBody; // The player transform for yaw rotation

    [Header("Settings")]
    [Range(0.1f, 3f)]
    public float mouseSensitivity = 2f;

    [Header("Camera Pitch")]
    [Range(-60f, 60f)][SerializeField] private float minPitch = -60f;
    [Range(-60f, 60f)][SerializeField] private float maxPitch = 60f;

    private float pitch = 0f; // Track camera pitch (x-rotation)

    private void Awake()
    {

        // Instantiate and enable the input actions
        inputActions = new PlayerInputActions();
        inputActions.Enable();


        // Optionally lock the cursor for an FPS-like feel
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    private void OnEnable()
    {
        // Subscribe to the Look action
        inputActions.Player.Look.performed += OnLook;
        inputActions.Player.Look.canceled += OnLook;
    }

    private void OnDisable()
    {
        // Unsubscribe
        inputActions.Player.Look.performed -= OnLook;
        inputActions.Player.Look.canceled -= OnLook;
        //disable the input actions
        inputActions.Disable();
    }

    private void OnLook(InputAction.CallbackContext context)
    {
        //skip processing if the game is paused
        if (Time.timeScale == 0f)
        {
            return;
        }

        // Read the mouse delta (Vector2)
        Vector2 lookDelta = context.ReadValue<Vector2>();

        // Separate out the X (yaw) and Y (pitch)
        float mouseX = lookDelta.x * mouseSensitivity;
        float mouseY = lookDelta.y * mouseSensitivity;

        // Adjust camera pitch (looking up/down). We invert mouseY 
        // so moving mouse up rotates pitch negatively.
        pitch -= mouseY;
        pitch = Mathf.Clamp(pitch, minPitch, maxPitch); // limit pitch to avoid flipping

        // Apply pitch to the camera’s local rotation
        transform.localRotation = Quaternion.Euler(pitch, 0f, 0f);

        // Rotate the player body around its Y-axis for left/right yaw
        playerBody.Rotate(Vector3.up * mouseX);
    }
}
