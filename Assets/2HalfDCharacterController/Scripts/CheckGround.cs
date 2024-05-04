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
            state.SetIsGrounded(false);

            if (state.GetIsGrounded() == true)
            {
                state.SetIsGrounded(false);
                Debug.Log("isGrounded set to FALSE for exiting the GroundObject!");
            }
            
        }
    }
}
