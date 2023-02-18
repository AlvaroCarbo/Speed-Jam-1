using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuController : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void PlayLoader()
    {
        SceneManager.LoadScene("Test", LoadSceneMode.Single);
    }
    public void ScoreBoardLoader()
    {
        SceneManager.LoadScene("LeaderboardScene", LoadSceneMode.Single);
    }
    public void OptionsLoader()
    {
        SceneManager.LoadScene("Options", LoadSceneMode.Single);
    }
}
