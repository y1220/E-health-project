using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using Photon.Pun;

public class JumpToFelmeDoors : MonoBehaviour
{
    public void StartBtn()
    {
        NetworkManager.instance.photonView.RPC("ChangeScene", RpcTarget.All, "FelmeDoors");
        //SceneManager.LoadScene("Introduction-1");
    }
}
