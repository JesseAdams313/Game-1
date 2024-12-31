using UnityEngine;
using UnityEngine.UI;


public class GameManager : MonoBehaviour
{
    [Header("Collectible Settings")]
    public int totalCollectibles = 3;//Total number of collectibles in the scene
    public int collectedCollectibles = 0;//Number of collectibles collected by the player

    [Header("UI References")]
    public Text ProgressText;//Text to display the progress of the player
    public GameObject levelCompletePanel;//UI to display when the player completes the level


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        //Initialize the UI
        UpdateProgressUI();
        levelCompletePanel.SetActive(false);

    }

    public void CollectItem()
    {
        collectedCollectibles++;
        UpdateProgressUI();

        //Check if the player has collected all the collectibles
        if (collectedCollectibles >= totalCollectibles)
        {
            //Display the level complete panel
            ShowLevelCompleteUI();
        }
    }
    private void UpdateProgressUI()
    {
        ProgressText.text = $"Collectibles: {collectedCollectibles}/{totalCollectibles}";
    }

    private void ShowLevelCompleteUI()
    {
        levelCompletePanel.SetActive(true);
        // Optionally lock the cursor here
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
    }
    // Button Functions
    public void ContinueLevel()
    {
        Debug.Log("Continue clicked - Implement level transition here!");
        // Example: Load next level
        // SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    public void RestartLevel()
    {
        Debug.Log("Restart clicked - Implement level restart here!");
        // Example: Reload current level
        // SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }


    // Update is called once per frame
    void Update()
    {
        
    }
}
