using UnityEngine;
using static UnityEngine.SceneManagement.SceneManager;

public class SceneController : MonoBehaviour
{
    public void ReloadScene()
    {
        LoadScene(GetActiveScene().buildIndex);
    }

}
