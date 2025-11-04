using UnityEngine;

public class PlayerCollision : MonoBehaviour
{
    public Transform respawnPoint;
    public LayerMask groundLayer;

    void OnCollisionStay2D(Collision2D collision)
{
    if (collision.gameObject.CompareTag("CrushingBlock"))
    {
        Vector2 playerPos = transform.position;
        Vector2 blockPos = collision.transform.position;

        bool isBelowBlock = playerPos.y < blockPos.y - 0.5f;

        CrushingBlock blockScript = collision.gameObject.GetComponent<CrushingBlock>();
        bool blockIsMovingDown = blockScript != null && blockScript.isMovingDown;

        bool isTouchingGround = Physics2D.Raycast(transform.position, Vector2.down, 0.2f, groundLayer);

        if (isBelowBlock && blockIsMovingDown && isTouchingGround)
        {
            Debug.Log("Squished! Respawning...");
            transform.position = respawnPoint.position;
        }
    }
    }
}
