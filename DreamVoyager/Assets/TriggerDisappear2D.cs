using UnityEngine;

public class TriggerDisappear2D : MonoBehaviour
{
 
    public float delayBeforeDisappear = 1f;
    public float reappearDelay = 5f;
    public string playerTag = "Player";
    public Animator animator;

    private SpriteRenderer spriteRenderer;
    private BoxCollider2D boxCollider;
    private bool playerOnTop = false;
    private float timer = 0f;
    private bool animationResumed = false;
    private bool hasDisappeared = false;

    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        boxCollider = GetComponent<BoxCollider2D>();

        if (animator != null)
        {
            animator.speed = 0f; // Pause animation at start
        }
    }

    void Update()
    {
        if (playerOnTop && !animationResumed && !hasDisappeared)
        {
            timer += Time.deltaTime;

            if (timer >= delayBeforeDisappear && !animationResumed)
            {
                // if (animator != null)
                 // {
                    animator.speed = 2f; // Resume animation
                // }

                animationResumed = true;
            }
        }
    }

    void OnCollisionStay2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag(playerTag))
        {
            playerOnTop = true;
        }
    }

    void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag(playerTag))
        {
            playerOnTop = false;
            timer = 0f;

            if (!animationResumed)
            {
                animator.speed = 0f; // Pause again if animation hasn't started
            }
        }
    }

    // Called by Animation Event at the end of the animation
    public void Disappear()
    {
        spriteRenderer.enabled = false;
        boxCollider.enabled = false;
        hasDisappeared = true; 

        Invoke(nameof(Reappear), reappearDelay);
    }

    void Reappear()
    {
        spriteRenderer.enabled = true;
        boxCollider.enabled = true;
        hasDisappeared = false; 

        animator.Play("Crumble", 0, 0f);
        animator.speed = 0f;

        // Reset for next interaction
        timer = 0f;
        animationResumed = false;
        
    }
}
