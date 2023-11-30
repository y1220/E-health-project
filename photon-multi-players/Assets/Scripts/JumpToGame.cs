using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using Photon.Pun;
using Photon.Realtime;
public class JumpToGame : MonoBehaviour
{
    private const string SceneName = "Game";

    public void StartBtn()
    {
        NetworkManager.instance.photonView.RPC("ChangeScene", RpcTarget.All, SceneName); 
        // SceneManager.LoadScene(SceneName);
    }
}
