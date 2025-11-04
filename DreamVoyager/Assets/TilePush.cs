using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class TilePush : MonoBehaviour
{
    public Rigidbody2D rb;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();

        // Allow physics interactions
        rb.isKinematic = false;

        // Prevent unwanted rotation
        rb.freezeRotation = true;
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            Debug.Log("Player collided with pushable object!");
        }
    }
}
