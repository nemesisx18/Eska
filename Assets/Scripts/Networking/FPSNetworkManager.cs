using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using Mirror;

public class FPSNetworkManager : NetworkManager
{
    public GameObject arachne;
    public GameObject aragog;
    public GameObject blackHawk;
    public GameObject viperSting;
    public GameObject webster;

    public override void OnStartServer()
    {
        base.OnStartServer();

        NetworkServer.RegisterHandler<CreateFPSCharacterMessage>(OnCreateCharacter);
    }

    public override void OnClientConnect(NetworkConnection conn)
    {
        base.OnClientConnect(conn);

        CreateFPSCharacterMessage characterMessage = new CreateFPSCharacterMessage
        {
            team = Team.Shadow_Company
        };

        conn.Send(characterMessage);
    }

    void OnCreateCharacter(NetworkConnection conn, CreateFPSCharacterMessage message)
    {
        GameObject gameobject = Instantiate(aragog);
        Player player = gameobject.GetComponent<Player>();
        NetworkServer.AddPlayerForConnection(conn, gameobject);
    }
}

public struct CreateFPSCharacterMessage : NetworkMessage
{
    public Team team;
}

public enum Team
{
    Shadow_Company,
    Wolfhound
}
