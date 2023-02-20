using Api;
using UnityEngine;

public class LeaderboardManager : MonoBehaviour
{
    [SerializeField] private ApiRequest apiRequest;

    private void Start()
    {
        apiRequest.StartGetRequest();
    }
}