using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class GenericInteraction : MonoBehaviour, IInteractable
{
    [SerializeField] UnityEvent evento;

    [SerializeField] private UnityEvent onSelect;
    [SerializeField] private UnityEvent onDeselect;

    public void OnDeselect()
    {
        onDeselect.Invoke();
    }

    public void OnInteract()
    {
        evento.Invoke();
    }

    public void OnSelect()
    {
        onSelect.Invoke();
    }
}
