using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using Photon.Pun;

public class JumpToTakeCarePlantSuccess : MonoBehaviour
{
    public void StartBtn()
    {
        //NetworkManager.instance.photonView.RPC("ChangeScene", RpcTarget.All, "TakeCarePlantSuccess");
        Debug.Log("Success is called");
        SceneManager.LoadScene("TakeCarePlantSuccess");
    }
}
