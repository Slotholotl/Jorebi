using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationStateController : MonoBehaviour
{
    Animator animator;
    int isWalkingHash;
    void Start()
    {
        animator = GetComponent<Animator>();
        isWalkingHash = Animator.StringToHash("isWalking");
    }

    // Update is called once per frame
    void Update()
    {
        // if player presses w key
        bool isWalking = animator.GetBool("isWalkingHash");
        bool forwardPress = Input.GetKey("w");

        if (!isWalking && forwardPress)
        {
            // sets isWalking bool to true
            animator.SetBool("isWalkingHash", true);
        }
        // if player does not pres w key
        if (isWalking && !forwardPress)
        {
            // sets isWalking bool to false
            animator.SetBool("isWalkingHash", false);
        }
    }
}
