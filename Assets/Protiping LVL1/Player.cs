using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.Events;

public class Player : MonoBehaviour
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

    //Animator
    private float moveValue;
    private float breakerCount;
    private bool boolarriba = false;
    private bool boolabajo = false;
    private bool boolderecha = false;
    private bool boolizquierda = false;
    private bool boolarribaderecha = false;
    private bool boolarribaizquierda = false;
    private bool boolabajoderecha = false;
    private bool boolabajoizquierda = false;
    private Transform transforminicial;
    public GameObject personajeanim;
    private float timeSinceLastKey = 0f;
    private bool waitingForKey = false;
    public static Player Instance { get; private set; }
    private void Awake()
    {
        Instance = this;
    }
    private void Start()
    {
        transforminicial = personajeanim.transform;
        rb = GetComponent<Rigidbody>();
        rb.freezeRotation = true;

    }

    private void Update()
    {
        BreakerCounter();
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
        if (rb.velocity.magnitude > 1)
        {
            anim.SetBool("walking", true);
            anim.SetTrigger("walk");
        }
        else
        {
            anim.SetBool("walking", false);

        }
  
        direccionpersonaje();
        checkdirectionanim();

       

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
    private float MoveDetector(float x, float y)
    {
        Vector2 movement = new Vector2(x, y);
        float speed = 0;
        speed = movement.magnitude;
        return speed;
    }


    private void direccionpersonaje()
    {
        if(Input.GetKeyDown(KeyCode.W) || Input.GetKeyDown(KeyCode.UpArrow))
        {
            boolarriba = true;
            boolabajo = false;
            boolderecha = false;
            boolizquierda = false;
            boolarribaderecha = false;
            boolarribaizquierda = false;
            boolabajoderecha = false;
            boolabajoizquierda = false;
}
        if (Input.GetKeyDown(KeyCode.S) || Input.GetKeyDown(KeyCode.DownArrow))
        {
            boolarriba = false;
            boolabajo = true;
            boolderecha = false;
            boolizquierda = false;
            boolarribaderecha = false;
            boolarribaizquierda = false;
            boolabajoderecha = false;
            boolabajoizquierda = false;
        }
       
        if (Input.GetKeyDown(KeyCode.D) || Input.GetKeyDown(KeyCode.RightArrow))
        {
            boolarriba = false;
            boolabajo = false;
            boolderecha = true;
            boolizquierda = false;
            boolarribaderecha = false;
            boolarribaizquierda = false;
            boolabajoderecha = false;
            boolabajoizquierda = false;
        }
        if (Input.GetKeyDown(KeyCode.A) || Input.GetKeyDown(KeyCode.LeftArrow))
        {
            boolarriba = false;
            boolabajo = false;
            boolderecha = false;
            boolizquierda = true;
            boolarribaderecha = false;
            boolarribaizquierda = false;
            boolabajoderecha = false;
            boolabajoizquierda = false;
        }

        if ((Input.GetKeyDown(KeyCode.W) && Input.GetKeyDown(KeyCode.D)) || (Input.GetKeyDown(KeyCode.UpArrow) && Input.GetKeyDown(KeyCode.RightArrow)))
        {
            boolarriba = false;
            boolabajo = false;
            boolderecha = false;
            boolizquierda = false;
            boolarribaderecha = true;
            boolarribaizquierda = false;
            boolabajoderecha = false;
            boolabajoizquierda = false;
        }
        if ((Input.GetKeyDown(KeyCode.W) && Input.GetKeyDown(KeyCode.A)) || (Input.GetKeyDown(KeyCode.UpArrow) && Input.GetKeyDown(KeyCode.LeftArrow)))
        {
            boolarriba = false;
            boolabajo = false;
            boolderecha = false;
            boolizquierda = false;
            boolarribaderecha = false;
            boolarribaizquierda = true;
            boolabajoderecha = false;
            boolabajoizquierda = false;
        }
        if ((Input.GetKeyDown(KeyCode.S) && Input.GetKeyDown(KeyCode.D)) || (Input.GetKeyDown(KeyCode.DownArrow) && Input.GetKeyDown(KeyCode.RightArrow)))
        {
            boolarriba = false;
            boolabajo = false;
            boolderecha = false;
            boolizquierda = false;
            boolarribaderecha = false;
            boolarribaizquierda = false;
            boolabajoderecha = true;
            boolabajoizquierda = false;
        }
        if ((Input.GetKeyDown(KeyCode.S) && Input.GetKeyDown(KeyCode.A)) || (Input.GetKeyDown(KeyCode.DownArrow) && Input.GetKeyDown(KeyCode.LeftArrow)))
        {
            boolarriba = false;
            boolabajo = false;
            boolderecha = false;
            boolizquierda = false;
            boolarribaderecha = false;
            boolarribaizquierda = false;
            boolabajoderecha = false;
            boolabajoizquierda = true;
        }


        if(boolarriba==true && (Input.GetKeyDown(KeyCode.D)|| Input.GetKeyDown(KeyCode.RightArrow)))
        {
            boolarriba = false;
            boolabajo = false;
            boolderecha = false;
            boolizquierda = false;
            boolarribaderecha = true;
            boolarribaizquierda = false;
            boolabajoderecha = false;
            boolabajoizquierda = false;
        }
        if (boolarriba == true && (Input.GetKeyDown(KeyCode.A) || Input.GetKeyDown(KeyCode.LeftArrow)))
        {
            boolarriba = false;
            boolabajo = false;
            boolderecha = false;
            boolizquierda = false;
            boolarribaderecha = false;
            boolarribaizquierda = true;
            boolabajoderecha = false;
            boolabajoizquierda = false;
        }

        if (boolabajo == true && (Input.GetKeyDown(KeyCode.D) || Input.GetKeyDown(KeyCode.RightArrow)))
        {
            boolarriba = false;
            boolabajo = false;
            boolderecha = false;
            boolizquierda = false;
            boolarribaderecha = false;
            boolarribaizquierda = false;
            boolabajoderecha = true;
            boolabajoizquierda = false;
        }
        if (boolabajo == true && (Input.GetKeyDown(KeyCode.A) || Input.GetKeyDown(KeyCode.LeftArrow)))
        {
            boolarriba = false;
            boolabajo = false;
            boolderecha = false;
            boolizquierda = false;
            boolarribaderecha = false;
            boolarribaizquierda = false;
            boolabajoderecha = false;
            boolabajoizquierda = true;
        }

        if(boolderecha==true && (Input.GetKeyDown(KeyCode.W) || Input.GetKeyDown(KeyCode.UpArrow)))
            {
            boolarriba = false;
            boolabajo = false;
            boolderecha = false;
            boolizquierda = false;
            boolarribaderecha = true;
            boolarribaizquierda = false;
            boolabajoderecha = false;
            boolabajoizquierda = false;

        }
        if (boolderecha == true && (Input.GetKeyDown(KeyCode.S) || Input.GetKeyDown(KeyCode.DownArrow)))
            {
            boolarriba = false;
            boolabajo = false;
            boolderecha = false;
            boolizquierda = false;
            boolarribaderecha = false;
            boolarribaizquierda = false;
            boolabajoderecha = true;
            boolabajoizquierda = false;

        }
        if (boolizquierda == true && (Input.GetKeyDown(KeyCode.W) || Input.GetKeyDown(KeyCode.UpArrow)))
            {
            boolarriba = false;
            boolabajo = false;
            boolderecha = false;
            boolizquierda = false;
            boolarribaderecha = false;
            boolarribaizquierda = true;
            boolabajoderecha = false;
            boolabajoizquierda = false;

        }
        if (boolizquierda == true && (Input.GetKeyDown(KeyCode.S) || Input.GetKeyDown(KeyCode.DownArrow)))
            {
            boolarriba = false;
            boolabajo = false;
            boolderecha = false;
            boolizquierda = false;
            boolarribaderecha = false;
            boolarribaizquierda = false;
            boolabajoderecha = false;
            boolabajoizquierda = true;

        }
    }


    private void checkdirectionanim()
    {
        if(boolarriba==true)
        {

            Vector3 nuevarotacion =  new Vector3(0, 0, 0);
            personajeanim.transform.rotation = Quaternion.Euler(nuevarotacion);
        }
        if (boolabajo == true)
        {

            Vector3 nuevarotacion = new Vector3(0, 180, 0);
            personajeanim.transform.rotation = Quaternion.Euler(nuevarotacion);
        }

        if (boolderecha == true)
        {

            Vector3 nuevarotacion = new Vector3(0, 90,0 );
            personajeanim.transform.rotation = Quaternion.Euler(nuevarotacion);
        }
        if (boolizquierda == true)
        {

            Vector3 nuevarotacion =  new Vector3(0, 270, 0);
            personajeanim.transform.rotation = Quaternion.Euler(nuevarotacion);
        }

        if (boolarribaderecha==true)
        {

            Vector3 nuevarotacion =  new Vector3(0, 45, 0);
            personajeanim.transform.rotation = Quaternion.Euler(nuevarotacion);
        }
        if (boolarribaizquierda == true )
        {

            Vector3 nuevarotacion =  new Vector3(0, 315,0 );
            personajeanim.transform.rotation = Quaternion.Euler(nuevarotacion);
        }
        if (boolabajoderecha == true )
        {

            Vector3 nuevarotacion =  new Vector3(0, 135, 0);
            personajeanim.transform.rotation = Quaternion.Euler(nuevarotacion);
        }
        if (boolabajoizquierda == true )
        {

            Vector3 nuevarotacion =  new Vector3(0, 225,0 );
            personajeanim.transform.rotation = Quaternion.Euler(nuevarotacion);
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
        if(flatVel.magnitude > moveSpeed)
        {
            Vector3 limitedVel = flatVel.normalized * moveSpeed;
            rb.velocity = new Vector3(limitedVel.x, rb.velocity.y, limitedVel.z);
        }
    }
    private void Jump(float jumpForce)
    {
        anim.SetTrigger("jump");
        rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
    }

    public IEnumerator cortinaJump(float jump)
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