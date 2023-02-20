using Player;
using TMPro;
using UnityEngine;

public class UIHealth : MonoBehaviour
{
    [SerializeField] private TMP_Text healthText;
    [SerializeField] private HealthManager healthManager;
    
    void Start()
    {
        UpdateHealthText();
    }

    void Update()
    {
        UpdateHealthText();
    }

    private void UpdateHealthText()
    {
        healthText.text = healthManager.currentHealth.ToString();
    }
}
