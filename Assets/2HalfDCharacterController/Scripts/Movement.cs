using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    [Header("Attach game objects")]
    public Rigidbody rb;
    public GameObject foot;
    public GameObject sidesCheck;
    public GameObject characterRenderer;

    [Header("Character Sprites")]
    public Sprite characterFront;
    public Sprite characterBack;
    public Sprite characterLeft;
    public Sprite characterRight;

    [Header("CharacterStatues")]
    public bool isDashing;
    public bool isRolling;
    public bool isGrounded;
    public bool isMoving;
    public bool isMovingUp;
    public bool isMovingRight;
    public bool isRunning;
    public int remainingJumpTimes;

    [Header("Movement Stats")]
    public float moveSpeed;
    public float runSpeed;
    public float jumpForce;
    public int maxJumpTimes;

    [Header("Dash")]
    public float dashSpeed;
    public float dashDuration;
    public float dashCooldown;

    [Header("Roll")]
    public float rollSpeed;
    public float rollDuration;
    public float rollCooldown;

    TrailRenderer trailRenderer;

    private Vector2 moveInput;
    void Start()
    {
        remainingJumpTimes = maxJumpTimes;
        trailRenderer = GetComponent<TrailRenderer>();
        characterRenderer.GetComponent<SpriteRenderer>().sprite = characterFront;
    }

    // Update is called once per frame
    void Update()
    {

        //override any other movement action while rolling & dashing
        if (isDashing || isRolling) { return; }

        ReadInput();

        Move();

        Jump();

        DashRoll();
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("Ground"))
        {
            if (isGrounded == false)
            {
                isGrounded = true;

                remainingJumpTimes = maxJumpTimes;

                Debug.Log("isGrounded set to TRUE && Jump Times are refreshed!");
            }
        }
    }

    private IEnumerator Dash()
    {
        isDashing = true;
        trailRenderer.emitting = true;
        rb.velocity = new Vector3(moveInput.x * dashSpeed, rb.velocity.y, moveInput.y * dashSpeed);
        yield return new WaitForSeconds(dashDuration);
        isDashing = false;
        trailRenderer.emitting = false;
    }

    private IEnumerator Roll()
    {
        if (Input.GetButtonDown("Dash"))
        {
            isRolling = true;
            rb.velocity = new Vector3(moveInput.x * rollSpeed, rb.velocity.y, moveInput.y * rollSpeed);
            yield return new WaitForSeconds(rollDuration);
            isRolling = false;
        }
        else if (Input.GetButtonUp("Dash"))
        {
            Debug.Log("reducing roll speed");
            rb.velocity -= new Vector3(moveInput.x * 0.15f, rb.velocity.y, moveInput.y * 0.15f);
        }
    }

    private void Jump()
    {
        if (Input.GetButtonDown("Jump") && remainingJumpTimes > 1)
        {
            Debug.Log("trying to jump");
            rb.velocity += new Vector3(0f, jumpForce, 0f);
            remainingJumpTimes--;
        }
        //reduces jump velocity when button is released
        else if (Input.GetButtonUp("Jump") && isGrounded == false)
        {
            rb.velocity -= new Vector3(0f, jumpForce * 0.55f, 0f); Debug.Log("jump force decreased");
        }
    }

    private void Move()
        
    {
        CheckRun();

        if (isRunning && isGrounded)
        {
            Debug.Log("trying to run");
            Run();
        }
        else
        {
            rb.velocity = new Vector3(moveInput.x * moveSpeed, rb.velocity.y, moveInput.y * moveSpeed);
        }
            checkRotation();
            CheckMovement();   
    }

    private void DashRoll()
    {
        if (Input.GetButtonDown("Dash"))
        {
            if (isGrounded == true)
            {
                Debug.Log("trying to roll");
                StartCoroutine(Roll());
            }
            else
            {
                Debug.Log("trying to dash");
                StartCoroutine(Dash());
            }
        }
    }

    private void ReadInput()
    {
        moveInput.x = Input.GetAxis("Horizontal");
        moveInput.y = Input.GetAxis("Vertical");

        moveInput.Normalize();
    }

    private void checkRotation()
    {
        if (moveInput.y > 0.01 && isMovingUp == false)
        {
            isMovingUp = true;
            characterRenderer.GetComponent<SpriteRenderer>().sprite = characterBack;
        }
        if (moveInput.y < 0 && isMovingUp == true)
        {
            isMovingUp = false;
            characterRenderer.GetComponent<SpriteRenderer>().sprite = characterFront;
        }
        if (moveInput.x > 0.01 && isMovingRight == false)
        {
            isMovingRight = true;
            characterRenderer.GetComponent<SpriteRenderer>().sprite = characterRight;
        }
        if (moveInput.x < 0 && isMovingRight == true)
        {
            isMovingRight = false;
            characterRenderer.GetComponent<SpriteRenderer>().sprite = characterLeft;
        }
    }

    private void CheckMovement()
    {  
        if (moveInput.magnitude > 0)
            {
                if(isMoving == false)
                {
                    isMoving = true;
                    Debug.Log("isMoving set to TRUE!");
                }
            }            
        if( rb.velocity.x == 0 && rb.velocity.z == 0)
        {
            if(isMoving == true)
            {
                isMoving = false;
                Debug.Log("isMoving set to FALSE");
            }
        }
    }

    private void Run()
    {
        rb.velocity = new Vector3(moveInput.x * runSpeed, rb.velocity.y, moveInput.y * runSpeed);
    }

    private void CheckRun()
    {
        if (Input.GetButtonDown("Run") && isRunning ==false)
        {
            isRunning = true;
        }
        if (Input.GetButtonUp("Run") && isRunning == true)
        {
            isRunning = false;
        }
    }
}