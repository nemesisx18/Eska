using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIPlayer : MonoBehaviour
{
    [SerializeField]
    Text text;

    PlayerSet player;
    
    public void SetPlayer (PlayerSet player)
    {
        //this.player = player;
        //text.text = "Player " + player.playerIndex.ToString();
        text.text = UserAccountManager.PlayerUsername;
    }
}
