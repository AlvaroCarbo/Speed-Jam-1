using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DetectedController : MonoBehaviour
{
    public static DetectedController Instance;
    
    [SerializeField] private GameObject detectedText;
    
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
    
    
    public void OnDetected()
    {
        detectedText.SetActive(true);
        
        StartCoroutine(ReloadScene());
    }
    
    private IEnumerator ReloadScene()
    {
        yield return new WaitForSeconds(3);
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
