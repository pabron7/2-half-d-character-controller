using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    [Header("Attach game objects")]
    public Rigidbody rb;
    public GameObject foot;
    public GameObject characterRenderer;
    public Animator characterAnimator;
    public StateController state;

    [Header("Character Sprites")]
    public Sprite characterFront;
    public Sprite characterBack;
    public Sprite characterLeft;
    public Sprite characterRight;

    [Header("CharacterStatues")]
    public int remainingJumpTimes;

    [Header("CharacterAnimations")]
    public AnimationClip charAnimFrontIdle;
    public AnimationClip charAnimFrontRun;

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
   
    }

    void Update()
    {

        //override any other movement action while rolling & dashing
        if (state.GetMovementState("dash") == true || state.GetMovementState("roll") == true) { return; }

        ReadInput();

        Move();

        Jump();

        DashRoll();

    }

    private void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("Ground"))
        {
            if (state.GetIsGrounded() == false)
            {
                state.SetIsGrounded(true);
                state.SetMovementState("jump", false);
                state.SetMovementState("fall", false);

                remainingJumpTimes = maxJumpTimes;
                Debug.Log("Successfuly landed & Jump Times are refreshed!");
            }
            CheckIdle();
        }
    }

    private IEnumerator Dash()
    {
        state.SetMovementState("dash", true);
        state.SetMovementState("move", false);
        state.SetMovementState("idle", false);
        trailRenderer.emitting = true;
        rb.velocity = new Vector3(moveInput.x * dashSpeed, rb.velocity.y, moveInput.y * dashSpeed);
        yield return new WaitForSeconds(dashDuration);
        state.SetMovementState("dash", false);
        trailRenderer.emitting = false;
    }

    private IEnumerator Roll()
    {
        if (Input.GetButtonDown("Dash"))
        {
            state.SetMovementState("roll", true);
            state.SetMovementState("move", false);
            state.SetMovementState("idle", false);
            rb.velocity = new Vector3(moveInput.x * rollSpeed, rb.velocity.y, moveInput.y * rollSpeed);
            yield return new WaitForSeconds(rollDuration);
            state.SetMovementState("roll", false);
        }
    }

    private void Jump()
    {
        if (Input.GetButtonDown("Jump") && remainingJumpTimes > 1)
        {
            
            state.SetMovementState("jump", true);
            state.SetMovementState("fall", false);
            state.SetMovementState("idle", false);
            rb.velocity += new Vector3(0f, jumpForce, 0f);
            remainingJumpTimes--;
        }
        //reduces jump velocity when button is released
        else if (Input.GetButtonUp("Jump") && state.GetIsGrounded() == false)
        {
            rb.velocity -= new Vector3(0f, jumpForce * 0.55f, 0f); Debug.Log("jump force decreased");
            state.SetMovementState("jump", false);
            state.SetMovementState("fall", true);
        }
    }

    private void Move()
        
    {
        CheckRun();

        if (state.GetMovementState("run") == true && state.GetIsGrounded() == true)
        {
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
            if (state.GetIsGrounded() == true)
            {
                StartCoroutine(Roll());
            }
            else
            {
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
        if (moveInput.y > 0.01 && state.GetVerticalState()==false)
        {
            state.SetVerticalState(true);
           // characterRenderer.GetComponent<SpriteRenderer>().sprite = characterBack;
        }
        if (moveInput.y < 0 && state.GetVerticalState() == true)
        {
            state.SetVerticalState(false);
            // characterRenderer.GetComponent<SpriteRenderer>().sprite = characterFront;
        }
        if (moveInput.x > 0.01 && state.GetHorizontalState() == false)
        {
            state.SetHorizontalState(true);
            // characterRenderer.GetComponent<SpriteRenderer>().sprite = characterRight;
        }
        if (moveInput.x < 0 && state.GetHorizontalState() == true)
        {
            state.SetHorizontalState(false);
            // characterRenderer.GetComponent<SpriteRenderer>().sprite = characterLeft;
        }
    }

    private void CheckMovement()
    {  
        if (moveInput.magnitude > 0)
            {
                if(state.GetMovementState("move") == false && state.GetIsGrounded() == true)
                {
                    state.SetMovementState("move", true);
                    state.SetMovementState("idle", false);
                    SetAnimation("orange-front-run");                   
                }
            }            

        if (rb.velocity.x == 0 && rb.velocity.z == 0)
        {
            if(state.GetMovementState("move") == true)
            {
                state.SetMovementState("move", false);
                state.SetMovementState("idle", true);
                SetAnimation("orange-front-idle");
            }
        }
        if (state.GetIsGrounded()==false && state.GetMovementState("move") == true)
        {
            state.SetMovementState("move", false);
        }
    }

    private void Run()
    {
        rb.velocity = new Vector3(moveInput.x * runSpeed, rb.velocity.y, moveInput.y * runSpeed);
    }

    private void CheckRun()
    {
        if (Input.GetButtonDown("Run") && state.GetMovementState("run") == false)
        {
            state.SetMovementState("run", true);
        }
        if (Input.GetButtonUp("Run") && state.GetMovementState("run") == true)
        {
            state.SetMovementState("run", false);
        }
    }

    private void CheckIdle()
    {
        if(state.GetIsGrounded() == true && state.GetMovementState("idle") == false)
        {
            if(state.GetMovementState("move") == false && state.GetMovementState("run") == false)
            {
                if(state.GetIsGrounded() == true)
                {
                    state.SetIsGrounded(true);                   
                }    
            }
        }
    }

   private void SetAnimation(string animName)
    {
        characterAnimator.Play(animName);
    }
}