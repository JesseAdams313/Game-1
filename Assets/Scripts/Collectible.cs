using UnityEngine;

public class Collectible : MonoBehaviour
{

    private bool isCollected = false;

    [Header("UI Tooltip")]
    public GameObject tooltipUI;

    private void Start()
    {
        if (tooltipUI != null)
        {
            tooltipUI.SetActive(false);
        }
    }

    public void Interact()
    {
        if (!isCollected) {
            isCollected = true;

            //Find the GameManager and notify it that an item was collected
            var gameManager = Object.FindFirstObjectByType<GameManager>();
            if (gameManager != null) {
                gameManager.CollectItem();
            }
            else
            {
                Debug.LogError("GameManager not found in the scene.");
            }
            Destroy(gameObject);
        }
    }

    public void ShowTooltip(bool show)
    {
        if (tooltipUI != null)
        {
            tooltipUI.SetActive(show);
        }
    }



    //private bool isCollected = false;

    //private void OnTriggerEnter(Collider other)
    //{
    //    if (!isCollected && other.CompareTag("Player"))
    //    {
    //        isCollected = true;

    //        // Use the new method to find the GameManager
    //        var gameManager = Object.FindFirstObjectByType<GameManager>();

    //        if (gameManager != null)
    //        {
    //            gameManager.CollectItem();
    //        }
    //        else
    //        {
    //            Debug.LogError("GameManager not found in the scene.");
    //        }

    //        Destroy(gameObject); // Remove collectible after collection
    //    }
    //}
}
