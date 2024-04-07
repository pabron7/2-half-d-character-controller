using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    [Header("Attach game objects")]
    public Rigidbody rb;
    public GameObject foot;

    [Header("Movement Stats")]
    public float moveSpeed;
    public float jumpForce;
    public int maxJumpTimes;
    int remainingJumpTimes;
    bool isGrounded;

    [Header("Dash")]
    public float dashSpeed;
    public float dashDuration;
    public float dashCooldown;
    bool isDashing;

    [Header("Roll")]
    public float rollSpeed;
    public float rollDuration;
    public float rollCooldown;
    bool isRolling;

    private Vector2 moveInput;
    void Start()
    {
        remainingJumpTimes = maxJumpTimes;
    }

    // Update is called once per frame
    void Update()
    {

        //override any other movement action while rolling&dashing
        if (isDashing || isRolling){ return;}  

        ReadInput();

        moveInput.Normalize();

        Move();

        Jump();

        DashRoll();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Ground"))
        {
            isGrounded = true;
            remainingJumpTimes = maxJumpTimes;      //refreshes jump times upon landing
            Debug.Log("isGrounded set to TRUE");
        }
    }
        
    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Ground"))
        {
            isGrounded = false;     
            Debug.Log("isGrounded set to FALSE");
        }
    }

    private IEnumerator Dash()
    {
        isDashing = true;
        rb.velocity = new Vector3(moveInput.x * dashSpeed, rb.velocity.y, moveInput.y * dashSpeed);
        yield return new WaitForSeconds(dashDuration);
        isDashing = false;
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
        else if (Input.GetButtonUp("Jump")  && isGrounded ==false)
        {
            rb.velocity -= new Vector3(0f, jumpForce * 0.55f, 0f); Debug.Log("jump force decreased");
        }
    }

    private void Move()
    {
        rb.velocity = new Vector3(moveInput.x * moveSpeed, rb.velocity.y, moveInput.y * moveSpeed);
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
    }
}
