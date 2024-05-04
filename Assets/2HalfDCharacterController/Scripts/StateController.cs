using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StateController : MonoBehaviour
{
    public StateRenderer stateRenderer;

    [Header("Movement Stats")]
    private bool isDashing;
    private void setIsDashing(bool value)
    {
        isDashing = value;  
    }
    private bool isRolling;
    private void setIsRolling(bool value)
    {
        isRolling = value; 
    }
    private bool isMoving;
    private void setIsMoving(bool value)
    {
        isMoving = value;
    }
    private bool isRunning;
    private void setIsRunning(bool value)
    {
        isRunning = value; 
    }
    private bool isIdle;
    private void setIsIdle(bool value)
    {
        isIdle = value; 
    }
    private bool isFalling;
    private void setIsFalling(bool value)
    {
        isFalling = value;
    }
    private bool isJumping;
    private void setIsJumping(bool value)
    {
        isJumping = value; 
    }

    [Header("Rotation Stats")]
    private bool isMovingUp;
    /// <summary>
    /// Checks isMovingRight and returns either true or false. True means character is facing right side while false means character is facing the left side.
    /// </summary>
    /// <returns></returns>
    public bool GetVerticalState()
    {
        return isMovingUp;
    }
    /// <summary>
    /// This function sets Vertical Movement state according to the given parameter. Simply provide a true or false as you need.
    /// </summary>
    /// <param name="value"></param>
    public void SetVerticalState(bool value)
    {
        if (value == true) { this.isMovingUp = true; }
        else { this.isMovingUp = false; }
    }

    private bool isMovingRight;
    /// <summary>
    /// Checks isMovingUp and returns either true or false. True means character is facing top side while false means character is facing the bot side. In another saying, true means the player see the back of the character while the other case means the player is seeing the face of the character.
    /// </summary>
    /// <returns></returns>
    public bool GetHorizontalState()
    {
        return isMovingRight;
    }
    /// <summary>
    /// This function sets Horizontal Movement state according to the given parameter. Simply provide a true or false as you need.
    /// </summary>
    /// <param name="value"></param>
    public void SetHorizontalState(bool value)
    {
        if (value == true) { this.isMovingRight = true; }
        else { this.isMovingRight = false; }
    }

    [Header("Ground")]
    private bool isGrounded;
    /// <summary>
    /// This function sets isGrounded state according to the given parameter. Simply provide a true or false as you need.
    /// </summary>
    /// <param name="value"></param>
    public void SetIsGrounded(bool value)
    {
        isGrounded = value;
    }
    /// <summary>
    /// Checks isGrounded and returns either true or false.
    /// </summary>
    /// <returns></returns>
    public bool GetIsGrounded()
    {
        return isGrounded;
    }

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
                setIsMoving(value);
                alertStateChange(value, name);
                break;
            case "jump":
                setIsJumping(value);
                alertStateChange(value, name);
                break;
            case "fall":
                setIsFalling(value);
                alertStateChange(value, name);
                break;
            case "roll":
                setIsRolling(value);
                alertStateChange(value, name);
                break;
            case "dash":
                setIsDashing(value);
                alertStateChange(value, name);
                break;
            case "run":
                setIsRunning(value);
                alertStateChange(value, name);
                break;
            case "idle":
                setIsIdle(value);
                alertStateChange(value, name);
                break;
        }

        stateRenderer.UpdateStateRenderer();
    }

    /// <summary>
    /// This function updates the state changes in the console, can be toggled on and off.
    /// </summary>
    /// <param name="updatedState"></param>
    /// <param name="value"></param>
    private void alertStateChange(bool value, string name)
    {
        Debug.Log("State Controller Update: " + name + " set to " + value);
    }

    private void setCurrentMovement(string _state)
    {
        movementState = _state;
    }

    private void setCurrentRotation(string _rotation)
    {
        movementRotation = _rotation;
    }
}
