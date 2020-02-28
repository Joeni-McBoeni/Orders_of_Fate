﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using Photon.Pun;

public class Launcher : MonoBehaviourPunCallbacks
{
    void Start()
    {
        Connect();
    }

    public void Connect()
    {
        // we check if we are connected or not, we join if we are , else we initiate the connection to the server.
        if (PhotonNetwork.IsConnected)
        {
            // #Critical we need at this point to attempt joining a Random Room. If it fails, we'll get notified in OnJoinRandomFailed() and we'll create one.
            PhotonNetwork.JoinRandomRoom();
        }
        else
        {
            // #Critical, we must first and foremost connect to Photon Online Server.
            PhotonNetwork.ConnectUsingSettings();
            PhotonNetwork.GameVersion = "1";
        }
    }

    public override void OnConnectedToMaster()
    {
        Debug.Log("OnConnectedToMaster() was called by PUN.");
        if(PhotonNetwork.JoinRandomRoom() == false)
        {
            PhotonNetwork.CreateRoom("");
            SceneManager.LoadScene("menu_joined", LoadSceneMode.Single);
        } 
        else
        {
            SceneManager.LoadScene("menu_joined", LoadSceneMode.Single);
        }


        //RoomOptions roomOptions = new RoomOptions();
        //roomOptions.IsVisible = true;
        //roomOptions.MaxPlayers = 2;
        //PhotonNetwork.CreateRoom("", roomOptions, TypedLobby.Default);
    }
}