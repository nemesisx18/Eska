﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UILobby : MonoBehaviour
{
    public static UILobby instance;

    [Header("Host Join")]
    [SerializeField]
    InputField joinMatchInput;

    [SerializeField]
    Button joinButton;

    [SerializeField]
    Button hostButton;

    [SerializeField]
    Canvas lobbyCanvas;

    [Header("Lobby")]
    [SerializeField]
    Transform UIPlayerParent;

    [SerializeField]
    GameObject UIPlayerPrefab;

    [SerializeField]
    Text matchIDText;

    [SerializeField]
    GameObject beginGameButton;

    void Start()
    {
        instance = this;
    }

    public void Host()
    {
        joinMatchInput.interactable = false;
        joinButton.interactable = false;
        hostButton.interactable = false;

        PlayerSet.localPlayer.HostGame();
    }

    public void HostSuccess (bool success, string matchID)
    {
        if (success)
        {
            lobbyCanvas.enabled = true;

            SpawnPlayerUIPrefab(PlayerSet.localPlayer);
            matchIDText.text = matchID;
            beginGameButton.SetActive(true);
        }
        else
        {
            joinMatchInput.interactable = true;
            joinButton.interactable = true;
            hostButton.interactable = true;
        }
    }

    public void Join ()
    {
        joinMatchInput.interactable = false;
        joinButton.interactable = false;
        hostButton.interactable = false;

        PlayerSet.localPlayer.JoinGame(joinMatchInput.text.ToUpper());
    }

    public void JoinSuccess (bool success, string matchID)
    {
        if (success)
        {
            lobbyCanvas.enabled = true;

            SpawnPlayerUIPrefab(PlayerSet.localPlayer);
            matchIDText.text = matchID;
        }
        else
        {
            joinMatchInput.interactable = true;
            joinButton.interactable = true;
            hostButton.interactable = true;
        }
    }

    public void SpawnPlayerUIPrefab (PlayerSet player)
    {
        GameObject newUIPlayer = Instantiate(UIPlayerPrefab, UIPlayerParent);
        newUIPlayer.GetComponent<UIPlayer>().SetPlayer (player);
        newUIPlayer.transform.SetSiblingIndex(player.playerIndex - 1);
    }

    public void BeginGame ()
    {
        PlayerSet.localPlayer.BeginGame();
    }
}
