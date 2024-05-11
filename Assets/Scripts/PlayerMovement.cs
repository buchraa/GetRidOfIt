using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float moveSpeed;
    public Rigidbody2D rb;
    public float jumpForce;
    private Vector3 velocity = Vector3.zero;
    private float horizontalMovement;
    private float verticalMovement;
    private bool isJumping;
    private bool isGrounded;
    [HideInInspector]
    public bool isClimbing;
    public Animator animator; 
    public SpriteRenderer spriteRenderer;
    public Transform groundCheckRight;
    public Transform groundCheckLeft;
    // Update is called once per frame
    void Update()
    {
        isGrounded = Physics2D.OverlapArea(groundCheckLeft.position, groundCheckRight.position);
        horizontalMovement = Input.GetAxis("Horizontal") * moveSpeed * Time.deltaTime;
         
        if (Input.GetKey(KeyCode.RightShift))
        {
            horizontalMovement *= 2;
        }
        
        if (Input.GetButtonDown("Jump") && isGrounded)
        {
            isJumping = true;
        }

        Flip(rb.velocity.x);
    }

    void FixedUpdate()
    {
        MovePlayer(horizontalMovement);
        float characterVelocity = Mathf.Abs(rb.velocity.x);
        animator.SetFloat("speed", characterVelocity);
    }

//change the position 
    void MovePlayer(float _horizontalMovement)
    {
        Vector3 targetVelocity = new Vector2(_horizontalMovement, rb.velocity.y);
        rb.velocity = Vector3.SmoothDamp(rb.velocity, targetVelocity, ref velocity, .05f);
        if(isJumping == true)
        {
            rb.AddForce(new Vector2(0f, jumpForce));
            isJumping = false;
        }
    }

//render frame depending on whether the value of velocity > 0 or not
     void Flip(float _velocity)
    {
        if (_velocity > 0.1f)
        {
            spriteRenderer.flipX = false;
        }else if(_velocity < -0.1f)
        {
            spriteRenderer.flipX = true;
        }
    }
}
