using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour
{
    public static LevelManager Instance;
    
    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }
    [SerializeField] private bool buttonPressed = false;
    [SerializeField] private bool vaultOpen = false;
    [SerializeField] private bool pizzaDelivered = false;
    [SerializeField] private bool escape = false;

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
        
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
