using System.Collections;
using System.Collections.Generic;
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
    bool isJumping;

    // Exposed variables via interface
    public bool jumpedThisFrame { get; private set; }
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

        input.actions["Jump"].started += _ => jumpedThisFrame = CheckJump();

        input.actions["Sprint"].started += _ => moveSpeed = sprintSpeed;
        input.actions["Sprint"].canceled += _ => moveSpeed = regularSpeed;
    }

    void Update()
    {
        if (jumpedThisFrame)
        {
            currentFallSpeed = Mathf.Sqrt(jumpHeight * -2 * gravity);
            jumpedThisFrame = false;
        }
        else if(controller.isGrounded)
        {
            currentFallSpeed = -2;
            isJumping = false;
        }
        else
        {
            currentFallSpeed = currentFallSpeed + gravity * Time.deltaTime;
        }

        if (isMoving)
        {
            currentMoveSpeed = InputToMoveSpeed(moveInput, cameraTransform);
            RotateTowards(cameraTransform);
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
    bool CheckJump()
    {
        bool jumpedThisFrame = false;
        if (!isJumping && controller.isGrounded)
        {
            isJumping = true;
            jumpedThisFrame = true;
        }
        return jumpedThisFrame;
    }

    void RotateTowards(Transform lookTransform)
    {
        Quaternion targetRotation = Quaternion.Euler(0, lookTransform.eulerAngles.y, 0);
        transform.rotation = Quaternion.Lerp(transform.rotation, targetRotation, rotationSpeed * Time.deltaTime);
    }
}
