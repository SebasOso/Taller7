using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class PlayerMovementTutorial : MonoBehaviour
{
    [Header("Damage")]
    public float damage = 10f;
    public float stayDamage = 20f;
    public float attackRange = 2f;
    public float attackRadius = 0.5f;
    [Header("Enemy")]
    public bool enemyIsDead = false;
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

    float horizontalInput;
    float verticalInput;

    Vector3 moveDirection;

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
    public static PlayerMovementTutorial Instance { get; private set; }
    private void Awake()
    {
        Instance = this;
    }
    private void Start()
    {
        rb = GetComponent<Rigidbody>();
        rb.freezeRotation = true;
    }

    private void Update()
    {
        JumpSystem();
        MovingCheck();
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

    private void MovePlayer()
    {
        // calculate movement direction
        moveDirection = orientation.forward * verticalInput + orientation.right * horizontalInput;

        // on ground
        if (isGrounded)
            rb.AddForce(moveDirection.normalized * moveSpeed * 10f, ForceMode.Force);

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
                    Jump(jumpForce);
                    canDoubleJump = true;
                    jumpDelayTimer = jumpDelay;
                }
                else if (canDoubleJump)
                {
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
    private void MovingCheck()
    {
        isMoving = horizontalInput != 0 || verticalInput != 0;

        if (isMoving)
        {
            //Debug.Log("Player start to move");
        }
        else if (!isMoving)
        {
            // Debug.Log("Player stop moving");
        }
    }
}
