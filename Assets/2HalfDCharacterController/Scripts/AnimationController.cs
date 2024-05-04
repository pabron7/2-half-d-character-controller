using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationController : MonoBehaviour
{
    Animation anim;
    Movement movement;
    StateController state;

    public AnimationClip charAnimFrontIdle;
    public AnimationClip charAnimFrontRun;

    void Start()
    {
        anim = GetComponent<Animation>();
    }

    // Update is called once per frame
    void Update()
    {
        UpdateAnimation();

    }

    public void UpdateAnimation()
    {
        switch (state.movementState)
        {
            case "moving":
                SetAnimation(charAnimFrontRun);
                break;
            case "jumping":

                break;
            case "falling":

                break;
            case "rolling":

                break;
            case "dashing":

                break;
            case "running":

                break;
            case "idle":
                SetAnimation(charAnimFrontIdle);
                break;
            default:

                break;
        }
    }

    private void SetAnimation(AnimationClip _animClip)
    {
        anim.clip = _animClip;
    }

}
