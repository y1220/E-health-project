using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using Photon.Pun;

public class JumpToHelda : MonoBehaviour
{
    public void StartBtn()
    {
        NetworkManager.instance.photonView.RPC("ChangeScene", RpcTarget.All, "Helda");
        //SceneManager.LoadScene("Introduction-1");
    }
}
