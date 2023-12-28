using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using Photon.Pun;

public class JumpToIndoDoors : MonoBehaviour
{
    public void StartBtn()
    {
        NetworkManager.instance.photonView.RPC("ChangeScene", RpcTarget.All, "IndoDoors");
        //SceneManager.LoadScene("Introduction-1");
    }
}
