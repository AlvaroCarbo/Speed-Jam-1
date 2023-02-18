using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class SecurityCamera : MonoBehaviour
{
    public float minAngle = -45f; // Minimum angle the camera can rotate to
    public float maxAngle = 45f; // Maximum angle the camera can rotate to
    public float rotationSpeed = 10f; // Speed at which the camera rotates
    public float fieldOfView = 60f; // Field of view of the camera
    public float viewDistance = 10f; // Distance at which the camera can detect the player
    public LayerMask layerMask; // Layer mask used to exclude certain objects from the camera's line of sight

    private Transform player; 
    private bool playerDetected = false; 
    private float currentAngle;
    private bool isMovingTowardsMaxAngle; 

    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform; 
        currentAngle = transform.eulerAngles.y; 
        isMovingTowardsMaxAngle = true; 
    }

    private void Update()
    {
        if (playerDetected)
        {
            // If the player has been detected, rotate the camera towards the player
            Vector3 targetDir = player.position - transform.position;
            float targetAngle = Mathf.Atan2(targetDir.x, targetDir.z) * Mathf.Rad2Deg;
            Quaternion targetRotation = Quaternion.Euler(transform.eulerAngles.x, targetAngle, transform.eulerAngles.z);
            transform.rotation = Quaternion.RotateTowards(transform.rotation, targetRotation, rotationSpeed * Time.deltaTime);
        }
        else
        {
            // If the player has not been detected, move the camera back and forth between the min and max angles
            if (isMovingTowardsMaxAngle)
            {
                currentAngle += rotationSpeed * Time.deltaTime;
                if (currentAngle >= maxAngle)
                {
                    currentAngle = maxAngle;
                    isMovingTowardsMaxAngle = false;
                }
            }
            else
            {
                currentAngle -= rotationSpeed * Time.deltaTime;
                if (currentAngle <= minAngle)
                {
                    currentAngle = minAngle;
                    isMovingTowardsMaxAngle = true;
                }
            }

            // Set the camera's rotation to the current angle
            transform.eulerAngles = new Vector3(transform.eulerAngles.x, currentAngle, transform.eulerAngles.z);
        }

       
        Vector3 directionToPlayer = player.position - transform.position;
        if (Vector3.Angle(transform.forward, directionToPlayer) < fieldOfView / 2 && directionToPlayer.magnitude < viewDistance)
        {
            // If the player is within the camera's field of view and range, set the playerDetected flag to true
            playerDetected = true;
            Debug.Log("Player Detected");
        }
        else
        {
            // If the player is not within the camera's field of view and range, set the playerDetected flag to false
            playerDetected = false;
        }
    }
}