using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StateController : MonoBehaviour
{
    public StateRenderer renderer;

    [Header("Movement Stats")]
    private bool isDashing;
    private bool isRolling;
    private bool isMoving;
    private bool isRunning;
    private bool isIdle;
    private bool isFalling;
    private bool isJumping;

    [Header("Rotation Stats")]
    private bool isMovingUp;
    private bool isMovingRight;

    [Header("Ground")]
    private bool isGrounded;

    [Header("Public Stats")]
    public string movementState;
    public string movementRotation;

    private void Start()
    {
        renderer.UpdateStateRenderer();
    }

    /// <summary>
    /// Checks the state of the movement according to the given parameter and returns a boolean. Simply provide a string of the following to see their current state; move, jump, fall, roll, dash, run, idle.
    /// </summary>
    /// <param name="_state"></param>
    /// <returns></returns>
    public bool GetMovementState(string _state) {

        bool askedState = false;

        switch (_state)
        {
            case "move":
                CheckState(isMoving);
                break;
            case "jump":
                CheckState(isJumping);
                break;
            case "fall":
                CheckState(isFalling);
                break;
            case "roll":
                CheckState(isRolling);
                break;
            case "dash":
                CheckState(isDashing);
                break;
            case "run":
                CheckState(isRunning);
                break;
            case "idle":
                CheckState(isIdle);
                break;
        }
        return askedState;
    }

    /// <summary>
    /// Sets movement state according to the given parameters name and status. Simply provide a decision (true or false) and one of the following names; move, jump, fall, roll, dash, run, idle.
    /// </summary>
    /// <param name="name"></param>
    /// <param name="status"></param>
    public void SetMovementState(string name, bool status)
    {
        
        switch (name)
        {
            case "move":
                WriteState(isMoving, status);
                break;
            case "jump":
                WriteState(isJumping, status);
                break;
            case "fall":
                WriteState(isFalling, status);
                break;
            case "roll":
                WriteState(isRolling, status);
                break;
            case "dash":
                WriteState(isDashing, status);
                break;
            case "run":
                WriteState(isRunning, status);
                break;
            case "idle":
                WriteState(isIdle, status);
                break;
        }

        // <---LOGIC--->
        // This function determines the current state by using the local Setter function WriteState()
        // <---END LOGIC--->
    }

    /// <summary>
    /// Checks isGrounded and returns either true or false.
    /// </summary>
    /// <returns></returns>
    public bool GetGroundState() {
        if (this.isGrounded == true) { return true; }
        else { return false; }
    }

    /// <summary>
    /// Checks isMovingUp and returns either true or false. True means character is facing top side while false means character is facing the bot side. In another saying, true means the player see the back of the character while the other case means the player is seeing the face of the character.
    /// </summary>
    /// <returns></returns>
    public bool GetHorizontalState() {
        if (this.isMovingUp == true) { return true; }
        else { return false; }
    }

    /// <summary>
    /// Checks isMovingRight and returns either true or false. True means character is facing right side while false means character is facing the left side.
    /// </summary>
    /// <returns></returns>
    public bool GetVerticalState() {
        if (this.isMovingRight == true) { return true; }
        else { return false; }
    }

    /// <summary>
    /// This function sets isGrounded state according to the given parameter. Simply provide a true or false as you need.
    /// </summary>
    /// <param name="decision"></param>
    public void SetGroundState(bool decision)
    {
        if (decision == true) { this.isGrounded = true; }
        else { this.isGrounded = false; }
    }

    /// <summary>
    /// This function sets Horizontal Movement state according to the given parameter. Simply provide a true or false as you need.
    /// </summary>
    /// <param name="decision"></param>
    public void SetHorizontalState(bool decision)
    {
        if (decision == true) { this.isMovingRight = true; }
        else { this.isMovingRight = false; }
    }

    /// <summary>
    /// This function sets Vertical Movement state according to the given parameter. Simply provide a true or false as you need.
    /// </summary>
    /// <param name="decision"></param>
    public void SetVerticalState(bool decision)
    {
        if (decision == true) { this.isMovingUp = true; }
        else { this.isMovingUp = false; }
    }

    /// <summary>
    /// This function requires a boolean and returns it's current state.
    /// </summary>
    /// <param name="checkedState"></param>
    /// <returns></returns>
    private bool CheckState(bool checkedState)
    {
        bool askedState;

        if (checkedState == true) {
            askedState = true;
        }
        else {
            askedState = false;
        }

        return askedState;
    }

    /// <summary>
    /// This function requires two booleans. The first is to be written and the second is the desired value.
    /// </summary>
    /// <param name="checkedState"></param>
    /// <param name="decision"></param>
    private void WriteState(bool checkedState, bool decision)
    {
        checkedState = decision;
        AlertStateChange(checkedState, decision);
    }

    /// <summary>
    /// This function updates the state changes in the console, can be toggled on and off.
    /// </summary>
    /// <param name="updatedState"></param>
    /// <param name="decision"></param>
    private void AlertStateChange(bool updatedState, bool decision)
    {
        Debug.Log(updatedState.ToString() + " set to " + decision);
    }

    private void SetCurrentMovement(string _state)
    {
        movementState = _state;
    }

    private void SetCurrentRotation(string _rotation)
    {
        movementRotation = _rotation;
    }

    public bool CheckCurrentMovementState(string name, bool status)
    {
        bool askedState = status;

        switch (name)
        {
            case "move":
                WriteState(isMoving, status);
                break;
            case "jump":
                WriteState(isJumping, status);
                break;
            case "fall":
                WriteState(isFalling, status);
                break;
            case "roll":
                WriteState(isRolling, status);
                break;
            case "dash":
                WriteState(isDashing, status);
                break;
            case "run":
                WriteState(isRunning, status);
                break;
            case "idle":
                WriteState(isIdle, status);
                break;
        }
        return askedState;

        // <---LOGIC--->

        // This function returns a boolean

        // <---END LOGIC--->
    }
}
