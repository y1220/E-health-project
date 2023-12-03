using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using Photon.Pun;

public class JumpToIndoDoor2 : MonoBehaviour
{
    public void StartBtn()
    {
        //NetworkManager.instance.photonView.RPC("ChangeScene", RpcTarget.All, "Thanks");
        SceneManager.LoadScene("IndoDoor2");
    }
}
