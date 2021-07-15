using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using Mirror;

public class GameOverUI : NetworkBehaviour
{
    public void DisconnectGame()
    {
        if (!isLocalPlayer)
        {
            NetworkManager.singleton.StopHost();
        }

        if (isLocalPlayer)
        {
            NetworkManager.singleton.StopClient();
        }
    }

    public void ReturnMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }
}
