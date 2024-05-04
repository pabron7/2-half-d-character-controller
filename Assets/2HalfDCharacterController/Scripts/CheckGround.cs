using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckGround : MonoBehaviour
{
    public Movement movement;
    public StateController state;
    

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Ground"))
        {
            state.SetGroundState(false);

            if (state.GetGroundState() == true)
            {
                state.SetGroundState(false);
                Debug.Log("isGrounded set to FALSE for exiting the GroundObject!");
            }
            
        }
    }
}
