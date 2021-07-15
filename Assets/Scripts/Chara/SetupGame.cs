using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Mirror;

public class SetupGame : NetworkBehaviour
{
    [SerializeField]
    Behaviour[] componentToDisable;

    [SerializeField]
    string remoteLayerName = "RemotePlayer";

    [SerializeField]
    GameObject playerUIPrefab;
    private GameObject playerUIInstance;

    [SerializeField] GameObject timerPrefab;

    void Start()
    {
        //Create PlayerUI
        playerUIInstance = Instantiate(playerUIPrefab);
        playerUIInstance.name = playerUIPrefab.name;

        //Configure PlayerUI
        PlayerUI ui = playerUIInstance.GetComponent<PlayerUI>();
        if (ui == null)
            Debug.LogError("No PlayerUI component on PlayerUI prefab.");
        ui.SetPlayer(GetComponent<Player>());

        GameObject go = (GameObject)Instantiate(timerPrefab, ui.transform);

        string _username = "Loading...";
        if (UserAccountManager.IsLoggedIn)
            _username = UserAccountManager.PlayerUsername;
        else
            _username = transform.name;

        CmdSetUsername(transform.name, _username);

        //GetComponent<Player>().SetupPlayer();
    }

    [Command]
    void CmdSetUsername(string playerID, string username)
    {
        Player player = GameManager.GetPlayer(playerID);
        if (player != null)
        {
            Debug.Log(username + " has joined!");
            player.username = username;
        }
    }

    public override void OnStartClient()
    {
        base.OnStartClient();

        Debug.Log("Client connected");

        string _netID = GetComponent<NetworkIdentity>().netId.ToString();
        Player _player = GetComponent<Player>();

        GameManager.RegisterPlayer(_netID, _player);
    }

    void AssignRemoteLayer()
    {
        gameObject.layer = LayerMask.NameToLayer(remoteLayerName);
    }

    void DisableComponents()
    {
        for (int i = 0; i < componentToDisable.Length; i++)
        {
            componentToDisable[i].enabled = false;
        }
    }

    void OnDisable()
    {
        Destroy(playerUIInstance);

        if (isLocalPlayer)
        {
            GameManager.instance.SetSceneCameraActive(true);
            GameManager.instance.SetMinimapCamActive(false);
        }

        GameManager.UnRegisterPlayer(transform.name);
    }
}
