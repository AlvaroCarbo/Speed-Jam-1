using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuController : MonoBehaviour
{
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
