using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorControl : MonoBehaviour
{
    [SerializeField] float angleOpen;
    [SerializeField] float time;
    bool rotating = false;

    public void OpenDoor()
    {
        Quaternion rotation = Quaternion.Euler(new Vector3(0, angleOpen, 0));
        StartCoroutine(Rotate(rotation, time));
    }

    public void CloseDoor()
    {
        Quaternion rotation = Quaternion.Euler(new Vector3(0, 0, 0));
        StartCoroutine(Rotate(rotation, time));
    }

    IEnumerator Rotate(Quaternion newRot, float duration)
    {
        if (rotating)
        {
            yield break;
        }
        rotating = true;

        Quaternion currentRot = transform.rotation;

        float counter = 0;
        while (counter < duration)
        {
            counter += Time.deltaTime;
            transform.rotation = Quaternion.Lerp(currentRot, newRot, counter / duration);
            yield return null;
        }
        rotating = false;
    }
}
