using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckGround : MonoBehaviour
{
    public Movement _movement;

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Ground"))
        {
            _movement.isGrounded = false;
            Debug.Log("isGrounded set to FALSE for exiting the GroundObject!");
        }
    }
}
