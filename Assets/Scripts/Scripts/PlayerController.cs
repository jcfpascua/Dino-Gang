using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

[RequireComponent(typeof(Rigidbody2D))]
public class PlayerController : MonoBehaviour
{
    public float walkSpeed = 5f;
    public float runSpeed = 8f;
    public float jumpForce = 10f;  // Force applied when jumping
    Vector2 moveInput;
    private bool isGrounded;        // Check if the player is on the ground

    public float CurrentMoveSpeed 
    {
        get
        {
            if (isMoving)
            {
                if (isRunning)
                {
                    return runSpeed;
                }
                else
                {
                    return walkSpeed;
                }
            }
            else
            {
                return 0;
            }
        }
    }

    [SerializeField]
    private bool _isMoving = false;
    public bool isMoving
    {
        get
        {
            return _isMoving;
        }
        private set
        {
            _isMoving = value;
            animator.SetBool(AnimationStrings.isMoving, value);
        }
    }

    [SerializeField]
    private bool _isRunning = false;
    public bool isRunning
    {
        get
        {
            return _isRunning;
        }
        private set
        {
            _isRunning = value;
            animator.SetBool(AnimationStrings.isRunning, value);
        }
    }

    public bool _isFacingRight = true;
    public bool IsFacingRight 
    {
        get 
        {
            return _isFacingRight;
        }
        private set 
        {
            if (_isFacingRight != value)
            {
                // flip
                transform.localScale *= new Vector2(-1, 1);
            }
            _isFacingRight = value;
        } 
    }

    Rigidbody2D rb;
    Animator animator;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Start()
    {
        // Initially hide the settings panel
    }

    void Update()
    {
        // Check for jump input
        if (Keyboard.current.spaceKey.wasPressedThisFrame && isGrounded)
        {
            Jump(); // Call jump method if on ground
        }
    }

    private void FixedUpdate()
    {
        rb.velocity = new Vector2(moveInput.x * CurrentMoveSpeed, rb.velocity.y);
        animator = GetComponent<Animator>();
    }

    public void OnMove(InputAction.CallbackContext context)
    {
        moveInput = context.ReadValue<Vector2>();

        isMoving = moveInput != Vector2.zero;

        SetFacingDirection(moveInput);
    }

    private void SetFacingDirection(Vector2 moveInput)
    {
        // right
        if (moveInput.x > 0 && !IsFacingRight)
        {
            IsFacingRight = true;
        }
        // left
        else if (moveInput.x < 0 && IsFacingRight)
        {
            IsFacingRight = false;
        }
    }

    public void OnRun(InputAction.CallbackContext context)
    {
        if (context.started)
        {
            isRunning = true;
        }
        else if (context.canceled)
        {
            isRunning = false;
        }
    }

    // Jump mechanic
    void Jump()
    {
        rb.velocity = new Vector2(rb.velocity.x, jumpForce); // Apply jump force
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            isGrounded = true;  // Player is on the ground
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            isGrounded = false; // Player is not on the ground
        }
    }
}
