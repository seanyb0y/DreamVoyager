using UnityEngine;

public class PortalTrigger : MonoBehaviour
{
    public GameObject endGameScreen; // Assign in Inspector

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            endGameScreen.SetActive(true); // Show the end game screen
            Time.timeScale = 0f; // Optional: pause the game
        }
    }
}