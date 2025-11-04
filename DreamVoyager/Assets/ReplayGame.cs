using UnityEngine;
using UnityEngine.SceneManagement;

public class ReplayGame : MonoBehaviour
{
    public void Replay()
    {
        // Reload the current scene
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        Time.timeScale = 1f; // Resume time if it was paused
    }
}
