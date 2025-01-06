using UnityEngine;
using UnityEngine.InputSystem;

public class CameraInteraction : MonoBehaviour
{
    // Reference to the generated input actions
    private PlayerInputActions inputActions;

    [Header("Interaction Settings")]
    [Tooltip("How far the player can interact with objects in front of them.")]
    public float interactDistance = 5f;  // Exposed distance so you can tweak in Inspector

    private Collectible currentCollectible = null; // Track the current collectible being hovered



    private void Awake()
    {
        // Create and enable the input actions
        inputActions = new PlayerInputActions();
        inputActions.Enable();
    }

    private void OnEnable()
    {
        // Subscribe to the Interact action (make sure you have added it to your InputActions)
        inputActions.Player.Interact.performed += OnInteract;
    }

    private void OnDisable()
    {
        // Unsubscribe when disabled to avoid leaks
        inputActions.Player.Interact.performed -= OnInteract;
        // Disable the input actions
        inputActions.Disable();
    }

    private void Update()
    {
        // Draw a debug ray in Scene View so you can visualize where the camera is pointing
        Debug.DrawRay(transform.position, transform.forward * interactDistance, Color.red);

        // Raycast for hover detection
        Ray ray = new Ray(transform.position, transform.forward);
        if (Physics.Raycast(ray, out RaycastHit hit, interactDistance))
        {
            Collectible collectible = hit.collider.GetComponent<Collectible>();

            if (collectible != currentCollectible) 
            {
                if (currentCollectible != null)
                {
                    currentCollectible.ShowTooltip(false);
                }
                if (collectible != null)
                {
                    collectible.ShowTooltip(true);
                }
                currentCollectible = collectible;
            }

    }
        else
        {
            if (currentCollectible != null)
            {
                currentCollectible.ShowTooltip(false);
                currentCollectible = null;
            }
        }
    }

    private void OnInteract(InputAction.CallbackContext context)
    {
        // Raycast from the camera forward
        Ray ray = new Ray(transform.position, transform.forward);
        if (Physics.Raycast(ray, out RaycastHit hit, interactDistance))
        {
            // Check if we hit a DialogueTarget
            DialogueTarget dialogueTarget = hit.collider.GetComponent<DialogueTarget>();
            if (dialogueTarget != null)
            {
                dialogueTarget.StartDialogue();
                return; // If it was a dialogue object, we're done
            }

            // Otherwise, check if it's a SpinTarget
            SpinTarget spinTarget = hit.collider.GetComponent<SpinTarget>();
            if (spinTarget != null)
            {
                spinTarget.ToggleSpin();
                return;
            }
            Collectible collectible = hit.collider.GetComponent<Collectible>();
            if (collectible != null)
            {
                collectible.Interact();
                return;
            }

            // If neither, log or do something else
            Debug.Log($"Hit {hit.collider.name}, but no DialogueTarget or SpinTarget attached.");
        }
        else
        {
            Debug.Log("Nothing hit within interact distance.");
        }
    }
}
