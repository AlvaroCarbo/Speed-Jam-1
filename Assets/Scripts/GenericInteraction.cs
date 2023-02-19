using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class GenericInteraction : MonoBehaviour, IInteractable
{
    [SerializeField] UnityEvent evento;

    public void OnDeselect()
    {
    }

    public void OnInteract()
    {
        evento.Invoke();
    }

    public void OnSelect()
    {
    }
}
