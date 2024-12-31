using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;

public class GameManager : MonoBehaviour
{
    [Header("Player Stats")]
    public int maxHealth = 100; // Max player health
    public int currentHealth;   // Current player health

    [Header("Level Stats")]
    public float levelTimer = 0f; // Time spent in the level
    public int keysCollected = 0; // Number of keys collected

    [Header("Collectible Settings")]
    public int totalCollectibles = 3; // Total number of collectibles in the scene
    public int collectedCollectibles = 0; // Number of collectibles collected by the player

    [Header("UI References")]
    public TMP_Text progressText;       // Text to display collectible progress
    public TMP_Text healthText;         // Text to display player health
    public TMP_Text timerText;          // Text to display level timer
    public TMP_Text keysText;           // Text to display keys collected
    public GameObject levelCompletePanel; // UI to display when the player completes the level

    void Start()
    {
        // Initialize health
        currentHealth = maxHealth;

        // Initialize UI
        UpdateHUD();
        levelCompletePanel.SetActive(false);
    }

    void Update()
    {
        // Update the level timer
        levelTimer += Time.deltaTime;
        UpdateHUD();
    }

    public void CollectItem()
    {
        collectedCollectibles++;
        UpdateHUD();

        // Check if the player has collected all the collectibles
        if (collectedCollectibles >= totalCollectibles)
        {
            ShowLevelCompleteUI();
        }
    }

    public void CollectKey()
    {
        keysCollected++;
        UpdateHUD();
    }

    public void TakeDamage(int damage)
    {
        currentHealth -= damage;
        if (currentHealth <= 0)
        {
            currentHealth = 0;
            Debug.Log("Player has died.");
            // Handle player death logic here
        }
        UpdateHUD();
    }

    private void UpdateHUD()
    {
        // Update the HUD elements
        if (progressText) progressText.text = $"Collectibles: {collectedCollectibles}/{totalCollectibles}";
        if (healthText) healthText.text = $"Health: {currentHealth}/{maxHealth}";
        if (timerText) timerText.text = $"Time: {levelTimer:F2}";
        if (keysText) keysText.text = $"Keys: {keysCollected}";
    }

    private void ShowLevelCompleteUI()
    {
        levelCompletePanel.SetActive(true);
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
    }

    public void ContinueLevel()
    {
        Debug.Log("Continue clicked - Implement level transition here!");
        // Example: Load next level
        // SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    public void RestartLevel()
    {
        Debug.Log("Restart clicked - Implement level restart here!");
        Time.timeScale = 1f; // Resume the game
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
