using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using Photon.Pun;
using Photon.Realtime;
public class JumpToMenu : MonoBehaviour
{
    private const string SceneName = "Menu";

    public void StartBtn()
    {
        AudioManager.instance.PlaySFX(1);


        NetworkManager.instance.photonView.RPC("ChangeScene", RpcTarget.All, SceneName);
        // SceneManager.LoadScene(SceneName);
    }
}
