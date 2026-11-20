using UnityEngine;
using UnityEngine.InputSystem;

            /////////////// INFORMATION ///////////////
// SETUP:
// Add the script to the object you want the player to control

// TIPS:
// - The Rigidbody2D component should (probably) have some constraints: Freeze Rotation Z
// - Adjust the CapsuleCollider2D to fit the object appropriately
// - Objects that should be used as platforms needs to have a collider (non-trigger)

// LIMITATIONS:
// This script enables very limited platformer movement, but with minimal setup required.
// The available movement consists of: a jump with a fixed height (based on jumpForce), and moving side to side (based on maxSpeed).
// It will NOT easily enable you to add animations or sound or similar effects.

// This script automatically adds a PlayerInput, Rigidbody2D and a CapsuleCollider2D component in the inspector.
[RequireComponent(typeof(PlayerInput), typeof(Rigidbody2D), typeof(CapsuleCollider2D))]
public class LimitedPlatformerMovement : MonoBehaviour
{
    [SerializeField] private float maxSpeed = 10f;
    [SerializeField] private float jumpForce = 10f;
    
    private Vector2 moveInput;
    private bool jumpInput;
    private bool _isJumping;

    
    private Rigidbody2D rb;
    private CapsuleCollider2D groundCheckCollider; 

    [SerializeField] private GameObject runAnimation;
    [SerializeField] private SpriteRenderer runSprite;
    [SerializeField] private GameObject idleAnimation;
    [SerializeField] private SpriteRenderer idleSprite;
    
    void Awake()
    {
        runAnimation.SetActive(false);
        rb = GetComponent<Rigidbody2D>();
        groundCheckCollider = GetComponent<CapsuleCollider2D>();
    }
    
    void Update()
    {
        // Apply horizontal velocity from input
        rb.linearVelocityX = moveInput.x * maxSpeed;
        
        // Apply vertical velocity from jump
        if (jumpInput && IsGrounded())
        {
            rb.linearVelocityY = jumpForce;
        }

        if (moveInput.x < 0 && !runSprite.flipX)
        {
            runSprite.flipX = true;
            idleSprite.flipX = true;
        }
        if (moveInput.x > 0 && runSprite.flipX)
        {
            runSprite.flipX = false;
            idleSprite.flipX = false;
        }

        if (IsGrounded() && moveInput == Vector2.zero )
        {
            idleAnimation.SetActive(true);
            runAnimation.SetActive(false);
        }

        if (IsGrounded() && moveInput != Vector2.zero )
        {
            runAnimation.SetActive(true);
            idleAnimation.SetActive(false);
        }
        jumpInput = false; // only jump once for each press of the jump-button
    }

    private bool IsGrounded()
    {
        // Is our groundCheckCollider touching the groundLayer? If so, return the value "true"
        if (groundCheckCollider.IsTouchingLayers(~0)) // ~0 is referring to EVERY layer.
        {
            return true;
        }
        else
        {
            return false;
        }
    }
    
    public void OnMove(InputValue input)
    {
        moveInput = input.Get<Vector2>();
    }
    
    public void OnJump(InputValue input)
    {
        jumpInput = true;
    }
}
