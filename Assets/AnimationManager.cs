using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationManager : MonoBehaviour
{
    Animator animator;
    IMovement3D movementInterface;

    private void Awake()
    {
        animator = GetComponent<Animator>();
        movementInterface = GetComponentInParent<IMovement3D>();
    }

    // Update is called once per frame
    void Update()
    {
        float speed = new Vector2(movementInterface.velocity.x, movementInterface.velocity.z).magnitude;
        animator.SetFloat("Speed", speed);
    }
}
