using UnityEngine;
using UnityEngine.UI;
using TMPro; // If you're using TextMeshPro

public class DialogueTarget : MonoBehaviour
{
    [Header("Dialogue UI References")]
    [SerializeField] private GameObject dialoguePanel;
    [SerializeField] private TMP_Text dialogueUIText;   
    [SerializeField] private Button yesButton;
    [SerializeField] private Button noButton;

    private int dialogueStep = 0;
    private bool isDialogueActive = false;

    private void Start()
    {
        dialoguePanel.SetActive(false);

        yesButton.onClick.AddListener(OnYesClicked);
        noButton.onClick.AddListener(OnNoClicked);
    }

    /// <summary>
    /// Called when player presses E and raycast hits this object.
    /// </summary>
    public void StartDialogue()
    {
        if (!isDialogueActive)
        {
            isDialogueActive = true;
            dialogueStep = 0;
            dialoguePanel.SetActive(true);
            dialogueUIText.text = "Would you like to keep talking?";

            // ---- Unlock the cursor so we can click buttons ----
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;

        }
        else
        {
            EndDialogue();
        }
    }

    /// <summary>
    /// Called by YesButton.
    /// </summary>
    private void OnYesClicked()
    {
        dialogueStep++;

        if (dialogueStep == 1)
        {
            dialogueUIText.text = "Great! Let’s continue talking...";
        }
        else
        {
            // After second step, just end
            EndDialogue();
        }
    }

    /// <summary>
    /// Called by NoButton.
    /// </summary>
    private void OnNoClicked()
    {
        EndDialogue();
    }

    /// <summary>
    /// Closes the dialogue UI panel.
    /// </summary>
    private void EndDialogue()
    {
        dialoguePanel.SetActive(false);
        isDialogueActive = false;
        dialogueStep = 0;

        // ---- Lock the cursor again for camera movement ----
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }
}
