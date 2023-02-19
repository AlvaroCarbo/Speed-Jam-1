using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class InteractionLogic : MonoBehaviour, IInteractonLogic
{
    PlayerInput input;
    GameObject selectedObject;
    IInteractable selected;
    int regularLay;
    int highlightLay;
    
    public bool isInteracting { get; set; }

    private void Awake()
    {
        input = GetComponent<PlayerInput>();
        regularLay = LayerMask.NameToLayer("Default");
        highlightLay = LayerMask.NameToLayer("Highlighted");
    }

    private void Start()
    {
        input.actions["Interact"].started += _ => Interact();
    }

    void Interact()
    {
        if (!isInteracting)
        {
            isInteracting = true;
            if (selected != null)
                selected.OnInteract();
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if(selected == null && other.TryGetComponent(out selected))
        {
            selected.OnSelect();
            selectedObject = other.gameObject;
            ChangeLayer(other.gameObject, highlightLay);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject == selectedObject)
        {
            selected.OnDeselect();
            selected = null;
            ChangeLayer(other.gameObject, regularLay);
        }
    }

    void ChangeLayer(GameObject target, int layer)
    {
        target.layer = layer;
        foreach (Transform child in target.transform)
            child.gameObject.layer = layer;
    }

    public void RemoveSelected()
    {
        selected = null;
    }
}
