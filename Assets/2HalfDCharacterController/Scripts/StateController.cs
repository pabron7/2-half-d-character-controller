using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StateController : MonoBehaviour
{
    public StateRenderer stateRenderer;

    [Header("Movement Stats")]
    private bool isDashing;
    private void SetIsDashing(bool value)
    {
        isDashing = value;
    }
    private bool isRolling;
    private void SetIsRolling(bool value)
    {
        isRolling = value;
    }
    private bool isMoving;
    private void SetIsMoving(bool value)
    {
        isMoving = value;
    }

    private bool isRunning;
    private void SetIsRunning(bool value)
    {
        isRunning = value;
    }

    private bool isIdle;
    private void SetIsIdle(bool value)
    {
        isIdle = value;
    }

    private bool isFalling;
    private void SetIsFalling(bool value)
    {
        isFalling = value;
    }

    private bool isJumping;
    private void SetIsJumping(bool value)
    {
        isJumping = value;
    }

    [Header("Rotation Stats")]
    private bool isMovingUp;
    private bool isMovingRight;

    [Header("Ground")]
    private bool isGrounded;

    [Header("Public Stats")]
    public string movementState;
    public string movementRotation;

    /// <summary>
    /// Checks the state of the movement according to the given parameter and returns a boolean. Simply provide a string of the following to see their current state; move, jump, fall, roll, dash, run, idle.
    /// </summary>
    /// <param name="state"></param>
    /// <returns></returns>
    public bool GetMovementState(string state) {

        switch (state)
        {
            case "move":
                return isMoving;
            case "jump":
                return isJumping;
            case "fall":
                return isFalling; 
            case "roll":
                return isRolling;
            case "dash":
                return isDashing;
            case "run":
                return isRunning;
            case "idle":
                return isIdle;
            default:
                return false;
        }
    }

    /// <summary>
    /// Sets movement state according to the given parameters name and status. Simply provide a decision (true or false) and one of the following names; move, jump, fall, roll, dash, run, idle.
    /// </summary>
    /// <param name="name"></param>
    /// <param name="value"></param>
    public void SetMovementState(string name, bool value)
    {
        switch (name)
        {
            case "move":
                SetIsMoving(value);
                break;
            case "jump":
                SetIsJumping(value);
                break;
            case "fall":
                SetIsFalling(value);
                break;
            case "roll":
                SetIsRolling(value);
                break;
            case "dash":
                SetIsDashing(value);
                break;
            case "run":
                SetIsRunning(value);
                break;
            case "idle":
                SetIsIdle(value);
                break;
        }
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
    /// This function requires two booleans. The first is to be written and the second is the desired value.
    /// </summary>
    /// <param name="checkedState"></param>
    /// <param name="decision"></param>
    private void WriteState(bool checkedState, bool decision)
    {
        checkedState = decision;
        AlertStateChange(checkedState, decision);
        stateRenderer.UpdateStateRenderer();
    }

    /// <summary>
    /// This function updates the state changes in the console, can be toggled on and off.
    /// </summary>
    /// <param name="updatedState"></param>
    /// <param name="decision"></param>
    private void AlertStateChange(bool updatedState, bool decision)
    {
        Debug.Log(updatedState.ToString() + " set to " + decision);
        Debug.Log(" TEST");
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
