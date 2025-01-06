using UnityEngine;

public class SceneLoader : MonoBehaviour
{
    public void LoadScene(string sceneName)
    {
        // ensure the game is unpaused
        Time.timeScale = 1f;

        // Load the scene
        UnityEngine.SceneManagement.SceneManager.LoadScene(sceneName);
    

    }


}

