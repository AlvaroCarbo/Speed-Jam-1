using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationManager : MonoBehaviour
{
    Animator animator;
    IMovement3D movementInterface;
    IInteractonLogic interactionInterface;

    private void Awake()
    {
        animator = GetComponent<Animator>();
        movementInterface = GetComponentInParent<IMovement3D>();
        interactionInterface = GetComponentInParent<IInteractonLogic>();
    }

    // Update is called once per frame
    void Update()
    {
        float speed = new Vector2(movementInterface.velocity.x, movementInterface.velocity.z).magnitude;
        animator.SetFloat("Speed", speed);

        animator.SetBool("Jumping", movementInterface.isJumping);

        if (interactionInterface.isInteracting)
            animator.SetTrigger("Interacted");
        
        if (interactionInterface.isInteracting && !animator.GetCurrentAnimatorStateInfo(0).IsName("Interact"))
            interactionInterface.isInteracting = false;
    }
}
