using UnityEngine;

public class Collectible : MonoBehaviour
{
    private bool isCollected = false;

    private void OnTriggerEnter(Collider other)
    {
        if (!isCollected && other.CompareTag("Player"))
        {
            isCollected = true;

            // Use the new method to find the GameManager
            var gameManager = Object.FindFirstObjectByType<GameManager>();

            if (gameManager != null)
            {
                gameManager.CollectItem();
            }
            else
            {
                Debug.LogError("GameManager not found in the scene.");
            }

            Destroy(gameObject); // Remove collectible after collection
        }
    }
}
