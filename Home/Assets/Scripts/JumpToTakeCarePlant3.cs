using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using Photon.Pun;

public class JumpToTakeCarePlant3 : MonoBehaviour
{
    public void StartBtn()
    {
        //NetworkManager.instance.photonView.RPC("ChangeScene", RpcTarget.All, "TakeCarePlant3");
        SceneManager.LoadScene("TakeCarePlant3");
    }
}
