using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using Photon.Pun;

public class JumpToPostoffice : MonoBehaviour
{
    public void StartBtn()
    {
        //NetworkManager.instance.photonView.RPC("ChangeScene", RpcTarget.All, "TakeCarePlant1");
        SceneManager.LoadScene("PostOffice");
    }
}
