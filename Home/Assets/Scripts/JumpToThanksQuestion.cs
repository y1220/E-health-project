using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using Photon.Pun;

public class JumpToThanksQuestion : MonoBehaviour
{
    public void StartBtn()
    {
        //NetworkManager.instance.photonView.RPC("ChangeScene", RpcTarget.All, "TakeCarePlant1");
        SceneManager.LoadScene("ThanksQuestion");
    }
}
