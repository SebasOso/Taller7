using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class LobbyMove : MonoBehaviour
{
    [Header("Movement")]
    public float moveSpeed;
    public float groundDrag;
    public float airMultiplier;
    public bool isMoving;
    public float gravityForce = 1.8f;
    [HideInInspector] public float walkSpeed;
    [HideInInspector] public float sprintSpeed;

    [Header("Ground Check")]
    public LayerMask whatIsGround;

    public Transform orientation;
    private float threshold = 0.9f;

    float horizontalInput;
    float verticalInput;
    public float idlebreakerTime;
    Vector3 moveDirection;
    private Vector2 wetInputVector;
    Rigidbody rb;
    [Header("Jump")]
    public bool canJump = true;
    public float jumpForce = 10f;
    public float doubleJumpForce = 5f;
    public float jumpDelay = 0.25f;
    private bool isGrounded = true;
    private Vector3 gravityDirection = new Vector3(0, -1, 0);
    private bool canDoubleJump = false;
    private float jumpDelayTimer;
    public LayerMask groundMask;
    public Transform groundCheck;
    public float groundDistance = 0.4f;
    //Events
    public UnityEvent OnPlayerMove;
    public Animator anim;
    private float animationTime;
    //Animator
    private float moveValue;
    private float breakerCount;
    public GameObject personajeanim;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
        rb.freezeRotation = true;
    }

    private void Update()
    {
        BreakerCounter();
        JumpSystem();
        MyInput();
        SpeedControl();

        // handle drag
        if (isGrounded)
            rb.drag = groundDrag;
        else
            rb.drag = 0;

        if (transform.hasChanged)
        {
            OnPlayerMove.Invoke();
            transform.hasChanged = false;
        }

        // Check if player is grounded and not jumping
        if (isGrounded)
        {
            // Check if player is walking
            if (rb.velocity.magnitude > 1)
            {
                anim.SetBool("walking", true);
                anim.SetTrigger("walk");
            }
            else
            {
                anim.SetBool("walking", false);
            }
        }
        else // Player is not grounded
        {
            anim.SetBool("walking", false); // Set walking parameter to false
        }
    }
    private void FixedUpdate()
    {
        MovePlayer();
    }
    private void MyInput()
    {
        horizontalInput = Input.GetAxisRaw("Horizontal");
        verticalInput = Input.GetAxisRaw("Vertical");
    }

    private void BreakerCounter()
    {
        if (moveValue != 0) breakerCount = 0;
        breakerCount += Time.deltaTime;
        if (breakerCount >= idlebreakerTime)
        {
            anim.SetTrigger("breaker");
            breakerCount = -idlebreakerTime;
        }
    }
    private void MovePlayer()
    {

        // calculate movement direction
        moveDirection = orientation.forward * verticalInput + orientation.right * horizontalInput;

        // on ground
        if (isGrounded)
        {
            rb.AddForce(moveDirection.normalized * moveSpeed * 10f, ForceMode.Force);
        }
        // in air
        else if (!isGrounded)
            rb.AddForce(moveDirection.normalized * moveSpeed * 10f * airMultiplier, ForceMode.Force);
        rb.AddForce(gravityDirection * gravityForce, ForceMode.Acceleration);
    }

    private void SpeedControl()
    {
        Vector3 flatVel = new Vector3(rb.velocity.x, 0f, rb.velocity.z);

        // limit velocity if needed
        if (flatVel.magnitude > moveSpeed)
        {
            Vector3 limitedVel = flatVel.normalized * moveSpeed;
            rb.velocity = new Vector3(limitedVel.x, rb.velocity.y, limitedVel.z);
        }
    }
    private void Jump(float jumpForce)
    {
        rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
    }

    public IEnumerator CortinaJump(float jump)
    {
        yield return new WaitForSeconds(0.8f);
        Jump(jump);
    }

    private void JumpSystem()
    {
        if (canJump)
        {
            isGrounded = Physics.CheckSphere(groundCheck.position, groundDistance, groundMask);
            if (isGrounded)
            {
                canDoubleJump = true;
            }
            if (Input.GetKeyDown(KeyCode.Space))
            {
                if (isGrounded)
                {
                    anim.SetTrigger("jump");
                    Jump(jumpForce);
                    canDoubleJump = true;
                    jumpDelayTimer = jumpDelay;
                }
                else if (canDoubleJump)
                {
                    anim.SetTrigger("jump");
                    Jump(doubleJumpForce);
                    canDoubleJump = false;
                }
            }
            if (jumpDelayTimer > 0f && !isGrounded)
            {
                jumpDelayTimer -= Time.deltaTime;
            }
        }
    }
}