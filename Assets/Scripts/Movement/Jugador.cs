using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Jugador : MonoBehaviour
{
    public float jumpForce = 10f;
    public float doubleJumpForce = 5f;
    public float jumpDelay = 0.25f;
    public float groundDistance = 0.4f;
    public LayerMask groundMask;
    public Transform groundCheck;
    public float speed = 5;
    public float rotationSpeed = 50f;
    public Rigidbody rb;
    public float damage = 10f;
    public float stayDamage = 20f;
    public float attackRange = 2f;
    public float attackRadius = 0.5f;

    private bool isGrounded = true;
    private bool canDoubleJump = false;
    private float jumpDelayTimer;
    private Vector3 cameraForward;
    private Vector3 movementDirection;

    public SpawnEnemy spawnEnemy;
    public UnityEvent OnPlayerMove;
    private bool enemySpawn;
    public bool isMoving;
    public bool enemyIsDead = false;
    public bool canJump = true;
    public static Jugador instance { get; private set; }
    

    private void Awake()
    {
        instance = this;
    }

    void Update()
    {
        JumpSystem();

        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");
        isMoving = horizontalInput != 0 || verticalInput != 0;

        if (isMoving)
        {
            Debug.Log("Player start to move");
        }
        else if (!isMoving)
        {
            Debug.Log("Player stop moving");
        }

        // Get the forward direction of the camera without the vertical component
        cameraForward = Camera.main.transform.forward;
        cameraForward.y = 0;
        cameraForward.Normalize();

        // Calculate the movement direction based on the input and the camera direction
        movementDirection = horizontalInput * Camera.main.transform.right.normalized + verticalInput * cameraForward.normalized;

        movementDirection.Normalize();
        // Lock camera rotation on vertical axis
       

        transform.position = transform.position + movementDirection * speed * Time.deltaTime;

        if (movementDirection != Vector3.zero)
        {
            // Rotate the player towards the movement direction
            transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(movementDirection), rotationSpeed * Time.deltaTime);
        }


        if (transform.hasChanged)
        {
            OnPlayerMove.Invoke();
            transform.hasChanged = false;
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "CombatZone" && !enemySpawn)
        {
            spawnEnemy.Spawn();
            enemySpawn = true;
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
}
