using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelManager : MonoBehaviour
{
    [SerializeField] private bool buttonPressed = false;
    [SerializeField] private bool vaultOpen = false;
    [SerializeField] private bool pizzaDelivered = false;
    [SerializeField] private bool escape = false;
    
    [SerializeField] private List<bool> levelMainProgress = new List<bool>();
    [SerializeField] private List<bool> levelSideProgress = new List<bool>();

    // Getters
    public bool GetButtonPressed()
    {
        return buttonPressed;
    }
    
    public bool GetVaultOpen()
    {
        return vaultOpen;
    }
    
    public bool GetPizzaDelivered()
    {
        return pizzaDelivered;
    }
    
    public bool GetEscape()
    {
        return escape;
    }
    
    public void ButtonPressed()
    {
        buttonPressed = true;
    }
    
    public void VaultOpen()
    {
        vaultOpen = true;
    }
    
    public void PizzaDelivered()
    {
        pizzaDelivered = true;
    }
    
    public void Escape()
    {
        escape = true;
    }
}
