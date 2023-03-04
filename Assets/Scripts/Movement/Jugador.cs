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
    public float speed = 5f;
    public float rotationSpeed = 50f;
    public Rigidbody rb;


    private bool isGrounded = true;
    private bool canDoubleJump = false;
    private float jumpDelayTimer;



    public SpawnEnemy spawnEnemy;
    public UnityEvent OnPlayerMove;
    private bool enemySpawn;
    // Update is called once per frame
    void Update()
    {
        JumpSystem();

        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");

        Vector3 movementDirection = new Vector3(horizontalInput, 0, verticalInput);
        movementDirection.Normalize();

        transform.position = transform.position + movementDirection * speed * Time.deltaTime;

        if (movementDirection != Vector3.zero) transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(movementDirection), rotationSpeed * Time.deltaTime);

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
