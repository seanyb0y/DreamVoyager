using UnityEngine;
using TMPro; 

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    public Transform respawnPoint;
    public GameObject portal;
    public TextMeshProUGUI collectibleText;

    private int totalCollectibles = 6;
    private int collectedCount = 0;

    void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }

        portal.SetActive(false); // Hide portal at start
        totalCollectibles = GameObject.FindGameObjectsWithTag("Collectible").Length;
    }

    void Start()
    {
        UpdateCollectibleUI();
    }

    public void RegisterCollectible()
    {
        collectedCount++;
        UpdateCollectibleUI();
        Debug.Log($"Collected {collectedCount} of {totalCollectibles}");
        if (collectedCount >= totalCollectibles)
        {
            ActivatePortal();
        }
    }

    public void ActivatePortal()
    {
        if (portal != null)
        {
            portal.SetActive(true);
            Debug.Log("All collectibles gathered — portal activated!");
        }
    }

    public void UpdateRespawnPoint(Transform newPoint)
    {
        respawnPoint = newPoint;
    }

    public void RespawnPlayer(GameObject player)
    {
        if (respawnPoint != null)
            player.transform.position = respawnPoint.position;
    }

    void UpdateCollectibleUI()
    {
        if (collectibleText != null)
        {
        collectibleText.text = collectedCount + " / " + totalCollectibles;
        }
    }
}
