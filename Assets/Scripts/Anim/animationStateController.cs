using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Mirror;

public class animationStateController : NetworkBehaviour
{
    [SerializeField]
    Animator animator;

    int isRunningHash;
    int isBackwardHash;
    int isJumpingHash;
    
    void Start()
    {
        isRunningHash = Animator.StringToHash("isRunning");
        isBackwardHash = Animator.StringToHash("isBackward");
        isJumpingHash = Animator.StringToHash("isJumping");
    }

    [ClientCallback]
    private void Update()
    {
        if(!hasAuthority) { return; }
        
        bool isRunning = animator.GetBool(isRunningHash);
        bool isBackward = animator.GetBool(isBackwardHash);
        bool isJumping = animator.GetBool(isJumpingHash);

        bool forwardPressed = Input.GetKey("w") || Input.GetKey ("a") || Input.GetKey("d");
        bool backwardPressed = Input.GetKey("s");
        bool jumpPressed = Input.GetKeyDown("space");

        //if player presses w key
        if (!isRunning && forwardPressed)
        {
            animator.SetBool(isRunningHash, true);
        }

        //if player is not pressing w key
        if (isRunning && !forwardPressed)
        {
            animator.SetBool(isRunningHash, false);
        }

        if (!isBackward && backwardPressed)
        {
            animator.SetBool(isBackwardHash, true);
        }

        if (isBackward && !backwardPressed)
        {
            animator.SetBool(isBackwardHash, false);
        }

        if (!isJumping && jumpPressed)
        {
            animator.SetBool(isJumpingHash, true);
        }

        if (isJumping && !jumpPressed)
        {
            animator.SetBool(isJumpingHash, false);
        }
    }
}
