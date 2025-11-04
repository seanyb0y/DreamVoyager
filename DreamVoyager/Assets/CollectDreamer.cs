using UnityEngine;

public class CollectDreamer : MonoBehaviour
{
    public float fadeDuration = 2f; // Time it takes to fade out
    public KeyCode fadeKey = KeyCode.E; // Key to trigger fading
    public float proximityDistance = 3f; // Distance to check proximity

    private Renderer objectRenderer;
    private Color originalColor;
    private bool isFading = false;
    private float fadeTimer = 0f;
    private bool hasBeenCollected = false;

    void Start()
    {
        // Get the Renderer component and store the original color
        objectRenderer = GetComponent<Renderer>();
        originalColor = objectRenderer.material.color;
    }

    void Update()
    {
        // Check if the player is within proximity and presses the fade key
        if (!hasBeenCollected && IsPlayerInProximity() && Input.GetKeyDown(fadeKey))
        {
            isFading = true;
            hasBeenCollected = true;
        }

        // Handle fading logic
        if (isFading)
        {
            fadeTimer += Time.deltaTime;
            float alpha = Mathf.Lerp(1f, 0f, fadeTimer / fadeDuration);
            objectRenderer.material.color = new Color(originalColor.r, originalColor.g, originalColor.b, alpha);

            // Destroy the object after fading is complete
            if (fadeTimer >= fadeDuration)
            {
                GameManager.Instance.RegisterCollectible();
                Destroy(gameObject);
            }
        }
    }

    public void StartFading()
    {
        if (!isFading)
        {
            isFading = true;
        }
    }

    private bool IsPlayerInProximity()
    {
        GameObject player = GameObject.FindGameObjectWithTag("Player");
        if (player != null)
        {
            float distance = Vector3.Distance(player.transform.position, transform.position);
            return distance <= proximityDistance;
        }
        return false;
    }
}