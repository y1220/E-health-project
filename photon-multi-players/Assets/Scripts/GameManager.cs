using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using System.Linq;

public class GameManager : MonoBehaviourPun
{
    [Header("Players")]
    public string playerPrefabPath;

    public PlayerController[] players;
    public Transform[] spawnPoint;
    public float respawnTime;
    private int playersInGame;

    public static GameManager instance;

    public void Awake()
    {
        instance = this;
    }

    // Start is called before the first frame update
    void Start()
    {
        players = new PlayerController[PhotonNetwork.PlayerList.Length];
        photonView.RPC("ImInGame", RpcTarget.AllBuffered);
    }

    // Update is called once per frame
    void Update()
    {

    }

    [PunRPC]
    void ImInGame()
    {
        playersInGame++;

        if (playersInGame == PhotonNetwork.PlayerList.Length)
            SpawnPlayer();
    }

    void SpawnPlayer()
    {
        string playerType;

        // Check if player type is stored in PlayerPrefs
        if (PlayerPrefs.GetString("UserType") != null)
        {
            playerType = FirstCharToUpper(PlayerPrefs.GetString("UserType"));
        }
        else
        {
            // Default player type if not found
            playerType = "Ester";
        }

        // spawn player randomly in spawn point list position
        GameObject playerObject = PhotonNetwork.Instantiate(playerType,
            spawnPoint[Random.Range(0, spawnPoint.Length)].position, Quaternion.identity);

        // initialize
        playerObject.GetComponent<PhotonView>().RPC("Initialized", RpcTarget.All, PhotonNetwork.LocalPlayer);
    }

    public static string FirstCharToUpper(string input)
    {
        return input.First().ToString().ToUpper() + input.Substring(1);
    }
}
