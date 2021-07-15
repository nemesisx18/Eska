using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Mirror;

public class TurnManager : NetworkBehaviour
{
    List<PlayerSet> players = new List<PlayerSet>();

    public void AddPlayer (PlayerSet _player)
    {
        players.Add(_player);
    }
}
