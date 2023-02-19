using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightController : MonoBehaviour
{
    [SerializeField] private Transform startPoint;
    [SerializeField] private Transform endPoint;
    
    [SerializeField] private float speed = 1f;
    
    [SerializeField] private float timeInLight = 0f;
    [SerializeField] private float limitTimeToStayInLight = 5f;
    
    [SerializeField] private bool isPlayerInLight = false;
    
    [SerializeField] private Quaternion startRotation;
    
    [SerializeField] private float rotationSpeed = 1f;
    
    [SerializeField] private float movingTime = 0f;
    
    private void Start()
    {
        startRotation = transform.rotation;
    }
    
    private void Update()
    {
        MoveFromOnePointToAnother();
    }
    
    private void MoveFromOnePointToAnother()
    {
        if (!isPlayerInLight)
        {
            movingTime += Time.deltaTime;
            transform.position =
                Vector3.Lerp(startPoint.position, endPoint.position, Mathf.PingPong(movingTime * speed, 1f));
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {

            Debug.Log("Player entered the light");
        }
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            StopCoroutine(ReturnToStartRotation());

            isPlayerInLight = true;

            timeInLight += Time.deltaTime;
            // Debug.Log($"Player is in the light for {timeInLight} seconds");
            
            // transform.LookAt(other.transform); but slowly
            transform.rotation = Quaternion.Lerp(transform.rotation, Quaternion.LookRotation(other.transform.position - transform.position), Time.deltaTime * rotationSpeed);

            if (timeInLight >= limitTimeToStayInLight)
            {
                Debug.Log("Player is dead");
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            Debug.Log("Player exited the light");
            timeInLight = 0f;
            
            // destroy all coroutines

            StartCoroutine(ReturnToStartRotation());
            
            isPlayerInLight = false;
        }
    }
    
    private IEnumerator ReturnToStartRotation()
    {
        yield return new WaitForSeconds(1f);
        // lerp to start rotation
        while (transform.rotation != startRotation)
        {
            Debug.Log("Lerping to start rotation");
            transform.rotation = Quaternion.Lerp(transform.rotation, startRotation, Time.deltaTime * rotationSpeed);    
            yield return null;
            if (isPlayerInLight)
            {
                yield break;
            }
        }
        
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        var position = startPoint.position;
        Gizmos.DrawSphere(position, 0.5f);
        Gizmos.color = Color.green;
        var position1 = endPoint.position;
        Gizmos.DrawSphere(position1, 0.5f);
        Gizmos.color = Color.blue;
        Gizmos.DrawLine(position, position1);
    }
}
