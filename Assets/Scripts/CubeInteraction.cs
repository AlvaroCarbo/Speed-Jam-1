using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CubeInteraction : MonoBehaviour, IInteractable
{
    public void OnDeselect()
    {
    }

    public void OnSelect()
    {
    }

    public void OnInteract()
    {
        Debug.Log("Interacted");
    }
}
