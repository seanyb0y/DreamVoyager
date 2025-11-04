using UnityEngine;

public class PlayerMovement : MonoBehaviour {

    public CharacterController2D controller; 
    public Animator animator; 
    public Rigidbody2D rb; 
    public LayerMask groundLayer;
   

    public float runSpeed = 40f; 

    float horizontalMove = 0f; 

    bool jump = false; 
   
    void Update() {
        
       horizontalMove = Input.GetAxisRaw("Horizontal") * runSpeed;
       animator.SetFloat("Speed", Mathf.Abs(horizontalMove));

       if (Input.GetButtonDown("Jump")) {

        jump = true;
        animator.SetBool("IsJumping", true);

       }

       //animator.SetFloat("yVelocity", rb.linearVelocity.y);
       Vector2 rayOrigin = new Vector2(transform.position.x, transform.position.y - 0.1f);
      bool isGrounded = Physics2D.Raycast(transform.position, Vector2.down, 0.3f, groundLayer);

        // Fall detection
        bool isFalling = rb.linearVelocity.y < -0.1f && !isGrounded;
        animator.SetBool("isFalling", isFalling);
    }

    public void OnLanding() {
        
        animator.SetBool("IsJumping", false);
        animator.SetBool("isFalling", false);
    }   


    void FixedUpdate () {

        controller.Move(horizontalMove * Time.fixedDeltaTime, false, jump);
        jump = false; 
    }
}
