using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    [Header("Pause Menu UI")]
    public GameObject pauseMenuPanel;//UI to display when the game is paused

    private bool isPaused = false;//Flag to check if the game is paused


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //toggle the pause menu when the player presses the escape key
        if (Input.GetKeyDown(KeyCode.Escape))
        {
        if (isPaused)
            {
                ResumeGame();
            }
            else
            {
                PauseGame();
            }
        }
    }

    public void PauseGame()
    {
        isPaused = true;
        pauseMenuPanel.SetActive(true);
        Time.timeScale = 0f;//Pause the game
        // Optionally lock the cursor here
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
    }
    public void ResumeGame()
    {
        isPaused = false;
        pauseMenuPanel.SetActive(false);
        Time.timeScale = 1f;//Resume the game
        // Optionally lock the cursor here
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }
    public void RestartLevel()
    {
        Debug.Log("Restart clicked - Implement level restart here!");
        // Example: Reload current level
        // SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        Time.timeScale = 1f;//Resume the game
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
    public void ExitToMainMenu()
    {
        Debug.Log("Exit clicked - Implement main menu transition here!");
        // Example: Load main menu
        // SceneManager.LoadScene(0);
        Time.timeScale = 1f;//Resume the game
        SceneManager.LoadScene(0);
    }

}
