using UnityEngine;
using UnityEngine.SceneManagement;


public class SplashScreen : MonoBehaviour
{

    [Header("Settings")]    
    [SerializeField] private float displayTime = 3.0f;
    [SerializeField] private string nextSceneName;

    void Start()
    {
        Invoke("LoadNextScene", displayTime);
    }


    private void LoadNextScene()
    {
        if (!string.IsNullOrEmpty(nextSceneName))
        {
            SceneManager.LoadScene(nextSceneName);
        }
        else
        {
            Debug.LogError("Next Scene Name is not set in the Inspector");
        }
    }




    void Update()
    {
        
    }
}
