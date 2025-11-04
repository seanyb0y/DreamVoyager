using UnityEngine;

public class Drop : MonoBehaviour
{
    public string playerTag = "Player";
    private Rigidbody2D rb;
    private bool hasFallen = false;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        rb.bodyType = RigidbodyType2D.Kinematic; // Start frozen in place
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (!hasFallen && collision.gameObject.CompareTag(playerTag))
        {
            // Optional: check if player is on top
            Vector2 contactPoint = collision.GetContact(0).point;
            if (contactPoint.y > transform.position.y)
            {
                rb.bodyType = RigidbodyType2D.Dynamic; // Enable gravity
                hasFallen = true;
            }
        }
    }
}
