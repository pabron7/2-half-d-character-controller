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

    [Header("Dash, Roll")]
    public float dashSpeed;
    public float dashDuration;
    public float dashCooldown;
    bool isDashing;


    private Vector2 moveInput;
    void Start()
    {
        remainingJumpTimes = maxJumpTimes;
    }

    // Update is called once per frame
    void Update()
    {
        if (isDashing)
        {
            return;
        }

        moveInput.x = Input.GetAxis("Horizontal");
        moveInput.y = Input.GetAxis("Vertical");

        //moveInput.Normalize();

        rb.velocity = new Vector3(moveInput.x * moveSpeed, rb.velocity.y, moveInput.y * moveSpeed);

        if (Input.GetButtonDown("Jump") && remainingJumpTimes > 1)
        {
            Debug.Log("trying to jump");
            rb.velocity += new Vector3(0f, jumpForce, 0f);
            remainingJumpTimes--;
        }
        //reduces jump velocity when button is released
        else if (Input.GetButtonUp("Jump")){ 
            rb.velocity -= new Vector3(0f, jumpForce * 0.55f, 0f); Debug.Log("jump force decreased");
        }

        if (Input.GetButtonDown("Dash"))
        {
            Debug.Log("trying to dash");
            StartCoroutine(Dash());
        }
      
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("Ground"))
        {
            isGrounded = true;
            remainingJumpTimes = maxJumpTimes;      //refreshes jump times upon landing
            Debug.Log("isGrounded set to TRUE");
        }
        else
        {
            isGrounded = false;
            Debug.Log("isGrounded returned to FALSE");
        }
        
    }

    private IEnumerator Dash()
    {
        isDashing = true;
        rb.velocity = new Vector3(moveInput.x * dashSpeed, rb.velocity.y, moveInput.y * dashSpeed);
        yield return new WaitForSeconds(dashDuration);
        isDashing = false;
    }


}
