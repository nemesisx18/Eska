using UnityEngine;
using UnityEngine.SceneManagement;
using Mirror;

public class DeathMode : NetworkBehaviour
{
    public int gameGoals;
    public int playerStat;

    public GameObject winPopUp;

    [SerializeField]
    private GameObject[] disableGameObject;

    [SerializeField]
    private Behaviour[] disableScript;

    public bool spawned = false;

    Player player;

    void Start()
    {
        player = GetComponent<Player>();
    }

    void Update()
    {
        FinishGame();

        if (isLocalPlayer)
        {
            playerStat = player.kills;
        }

        if (!isLocalPlayer)
        {
            playerStat = player.kills;
        }
    }

    [Client]
    void FinishGame()
    {
        CmdSetupGame();
    }

    [Command]
    void CmdSetupGame()
    {
        RpcFinalGame();
    }

    [ClientRpc]
    void RpcFinalGame()
    {
        if (playerStat == gameGoals && spawned == false)
        {
            spawned = true;

            for (int i = 0; i < disableScript.Length; i++)
            {
                disableScript[i].enabled = false;
            }

            for (int i = 0; i < disableGameObject.Length; i++)
            {
                disableGameObject[i].SetActive(false);
            }

            GameManager.instance.SetSceneCameraActive(true);

            Instantiate(winPopUp);

            Debug.Log("Game Finished!!!!");
        }
    }

}
