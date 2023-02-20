using UnityEngine;
using static UnityEngine.SceneManagement.SceneManager;

public class SceneController : MonoBehaviour
{
    public static void ReloadScene()
    {
        LoadScene(GetActiveScene().buildIndex);
    }

}
