using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckAnimation : MonoBehaviour
{
    Animation anim;
    Movement movement;

    public AnimationClip charAnimFrontIdle;
    public AnimationClip charAnimFrontRun;

    void Start()
    {
        anim = GetComponent<Animation>();
    }

    // Update is called once per frame
    void Update()
    {
        if (movement.isIdle)
        {
            anim.clip = charAnimFrontIdle;
        }
        else if(movement.isMoving)
        {
            anim.clip = charAnimFrontRun;
        }
    }
}
