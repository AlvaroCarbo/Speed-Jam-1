using System;
using System.Collections;
using System.Collections.Generic;
using Player;
using UnityEngine;
using UnityEngine.InputSystem;

public class Movement3D : MonoBehaviour, IMovement3D
{
    [Header("MOVEMENT")]
    [SerializeField] float regularSpeed;
    [SerializeField] float sprintSpeed;
    [SerializeField] float rotationSpeed;
    float moveSpeed;
    [Header("JUMPING")]
    [SerializeField] float gravity;
    [SerializeField] float jumpHeight;

    Transform cameraTransform;
    float currentFallSpeed;
    Vector2 currentMoveSpeed;
    Vector2 moveInput;

    bool isMoving;
    // Exposed variables via interface
    public bool isJumping { get; private set; }
    public bool jumpedThisFrame { get; private set; }
    public bool landedThisFrame { get; private set; }
    public Vector3 velocity { get; private set; }

    CharacterController controller;
    PlayerInput input;

    void Awake()
    {
        controller = GetComponent<CharacterController>();
        input = GetComponent<PlayerInput>();
        cameraTransform = Camera.main.transform;

        moveSpeed = regularSpeed;
    }

    void OnEnable()
    {
        input.enabled = true;
    }

    private void OnDisable()
    {
        input.enabled = false;
    }

    void Start()
    {
        input.actions["Move"].started += _ => isMoving = true;
        input.actions["Move"].performed += it => moveInput = it.ReadValue<Vector2>();
        input.actions["Move"].canceled += _ => { isMoving = false; currentMoveSpeed = Vector2.zero; };

        input.actions["Jump"].started += _ => CheckJump();

        input.actions["Sprint"].started += _ => moveSpeed = sprintSpeed;
        input.actions["Sprint"].canceled += _ => moveSpeed = regularSpeed;
    }

    void Update()
    {
        // JUMP
        if (isJumping)
        {
            jumpedThisFrame = false;
        }
        
        if (jumpedThisFrame)
        {
            currentFallSpeed = Mathf.Sqrt(jumpHeight * -2 * gravity);
            isJumping = true;
        }
        else if(controller.isGrounded)
        {
            currentFallSpeed = -2;
            if (isJumping)
            {
                isJumping = false;
                landedThisFrame = true;
            } 
            else if (landedThisFrame)
            {
                landedThisFrame = false;
                PlayerFXManager.Instance.PlayLandFX();
                PlayerAudioManager.Instance.PlayLand();
            }
        }
        else
        {
            currentFallSpeed = currentFallSpeed + gravity * Time.deltaTime;
        }

        // MOVEMENT
        if (isMoving)
        {
            currentMoveSpeed = InputToMoveSpeed(moveInput, cameraTransform);
            RotateTowards(new Vector3(currentMoveSpeed.x, 0, currentMoveSpeed.y));
        }

        velocity = controller.velocity;
        controller.Move(new Vector3(currentMoveSpeed.x, currentFallSpeed, currentMoveSpeed.y) * Time.deltaTime);
    }

    // Takes input and transform of where we're looking at (camera) and turns it into relative move speed
    Vector2 InputToMoveSpeed(Vector2 input, Transform lookTransform = null)
    {
        Vector2 move;
        if(lookTransform == null)
        {
            move = input;
        }
        else
        {
            Vector3 dir = new Vector3(input.x, 0, input.y);
            dir = Quaternion.Euler(0, lookTransform.rotation.eulerAngles.y, 0) * dir;
            move = new Vector2(dir.x, dir.z);
        }
        return move * moveSpeed;
    }

    // Check if we can jump this frame
    void CheckJump()
    {
        if (!isJumping && controller.isGrounded)
        {
            jumpedThisFrame = true;
        }
    }

    void RotateTowards(Vector3 lookDirection)
    {
        Quaternion targetRotation = Quaternion.LookRotation(lookDirection, transform.up);
        transform.rotation = Quaternion.Lerp(transform.rotation, targetRotation, rotationSpeed * Time.deltaTime);
    }
    
    public void EnableMovement(bool enable)
    {
        input.enabled = enable;
    }

    private void OnCollisionEnter(Collision other)
    {
        Debug.Log(other.gameObject.name);
    }
}
