using UnityEngine;

public class Disappear : MonoBehaviour
{
    public float interactionRange = 2f;         // Distance to trigger interaction
    public KeyCode interactKey = KeyCode.E;     // Key to press
    public Transform player;                    // Assign your player transform in Inspector

    private SpriteRenderer spriteRenderer;
    private Collider2D objectCollider;

    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        objectCollider = GetComponent<Collider2D>();
    }

    void Update()
    {
        if (player == null) return;

        float distance = Vector2.Distance(transform.position, player.position);

        if (distance <= interactionRange && Input.GetKeyDown(interactKey))
        {
            spriteRenderer.enabled = false;
            objectCollider.enabled = false;
        }
    }
}
