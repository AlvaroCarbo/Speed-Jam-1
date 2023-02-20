using System.Collections;
using Api;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using Button = UnityEngine.UI.Button;

public class ScoreController : MonoBehaviour
{
    [SerializeField] private TimerController timerController;
    
    [SerializeField] private TMP_Text scoreText;
    
    [SerializeField] private TMP_InputField nameInputField;
    
    [SerializeField] private GameObject warning;
    
    [SerializeField] private ApiRequest apiRequest;
    
    [SerializeField] private Button saveButton;
    
    [SerializeField] private GameObject scorePanel;
    
    [SerializeField] private float timeToWait = 3f;

    private void Start()
    {
        scorePanel.SetActive(false);
        
        saveButton.onClick.AddListener(SaveScore);
    }
    
    public void EnableScorePanel()
    {        
        timerController.isFinished = true;

        scorePanel.SetActive(true);
        
        SetScoreText();
        
        Cursor.lockState = CursorLockMode.None;
    }
    
    private void SetScoreText()
    {
        string time = timerController.formatFloatToTime(timerController.GetTime());
        scoreText.text = time;
    }

    private void SaveScore()
    {
        string text = nameInputField.text;
        
        if (text == "")
        {
            warning.SetActive(true);
            return;
        }

        saveButton.interactable = false;
        
        string time = timerController.formatFloatToTime(timerController.GetTime());
        
        apiRequest.StartPostRequest(text, time);

        StartCoroutine(Wait());
    }
    
    private IEnumerator Wait()
    {
        yield return new WaitForSeconds(timeToWait);

        SceneManager.LoadScene("Menu", LoadSceneMode.Single);
    }
}
