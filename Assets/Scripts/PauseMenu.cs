using UnityEngine;
using Mirror;

public class PauseMenu : MonoBehaviour
{
    [SerializeField]
    public static bool IsOn = false;

    private NetworkManager networkManager;

    void Start()
    {
        networkManager = NetworkManager.singleton;
    }
}
