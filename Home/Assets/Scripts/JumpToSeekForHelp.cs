using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using Photon.Pun;

public class JumpToSeekForHelp : MonoBehaviour
{
    public void StartBtn()
    {
        NetworkManager.instance.photonView.RPC("ChangeScene", RpcTarget.All, "SeekForHelp");
        //SceneManager.LoadScene("Introduction-1");
    }
}
