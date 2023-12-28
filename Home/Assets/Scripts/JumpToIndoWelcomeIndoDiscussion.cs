using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using Photon.Pun;


public class JumpToWelcomeIndoDiscussion : MonoBehaviour
{
    public void StartBtn()
    {
        NetworkManager.instance.photonView.RPC("ChangeScene", RpcTarget.All, "WelcomeIndoDiscussion");
        // SceneManager.LoadScene("Introduction-7");
    }
}
