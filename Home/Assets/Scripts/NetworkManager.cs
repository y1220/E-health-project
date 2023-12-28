using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using Photon.Realtime;

public class NetworkManager : MonoBehaviourPunCallbacks
{
    public int maxPlayers; // max number of players

    // singleton
    public static NetworkManager instance;

    private void Awake()
    {
        if (instance != null && instance != this)
        {
            gameObject.SetActive(false);
        } else
        {
            instance = this;
            // Debug.Log(gameObject);
            DontDestroyOnLoad(gameObject);
        }
    }

    private void Start()
    {
        // connecting into the master server at the beginging of the game 
        PhotonNetwork.ConnectUsingSettings();
    }

    public override void OnConnectedToMaster()
    {
        PhotonNetwork.JoinLobby();
    }

    public void CreateRoom(string roomName)
    {
        RoomOptions options = new RoomOptions();
        options.MaxPlayers = (byte)maxPlayers;

        PhotonNetwork.CreateRoom(roomName, options);
    }

    public void JoinRoom(string roomName)
    {
        PhotonNetwork.JoinRoom(roomName);
    }

    [PunRPC]
    public void ChangeScene(string sceneName)
    {
        PhotonNetwork.LoadLevel(sceneName);
    }
    

}
