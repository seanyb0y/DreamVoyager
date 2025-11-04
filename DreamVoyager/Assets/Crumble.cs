using UnityEngine;
using System.Collections;

public class Crumble : MonoBehaviour
{
    public Animator animator;           // Assign your Animator component
    public float disappearDuration = 3f; // Time to stay hidden

    private Renderer objectRenderer;
    private Collider objectCollider;

    void Start()
    {
        objectRenderer = GetComponent<Renderer>();
        objectCollider = GetComponent<Collider>();
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            StartCoroutine(HandleDisappear());
        }
    }

    private IEnumerator HandleDisappear()
    {
        // Play animation
        if (animator != null)
        {
            animator.SetTrigger("Disappear"); // Make sure you have a "Disappear" trigger in Animator
        }

        // Disable collider and renderer
        objectCollider.enabled = false;
        objectRenderer.enabled = false;

        // Wait for a few seconds
        yield return new WaitForSeconds(disappearDuration);

        // Re-enable collider and renderer
        objectCollider.enabled = true;
        objectRenderer.enabled = true;
    }
}
