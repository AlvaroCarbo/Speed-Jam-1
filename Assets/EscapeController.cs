using UnityEngine;

public class EscapeController : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            LevelManager.Instance.Escape();
        }
    }
}
