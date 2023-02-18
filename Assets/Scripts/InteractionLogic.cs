using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class InteractionLogic : MonoBehaviour
{
    PlayerInput input;
    IInteractable selected;
    int regularLay;
    int highlightLay;

    private void Awake()
    {
        input = GetComponent<PlayerInput>();
        regularLay = LayerMask.NameToLayer("Default");
        highlightLay = LayerMask.NameToLayer("Highlighted");
    }

    private void Start()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if(selected == null && other.TryGetComponent(out selected))
        {
            ChangeLayer(other.gameObject, highlightLay);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject == selected.gameObject)
        {
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
}
