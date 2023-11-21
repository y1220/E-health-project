using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using Photon.Pun;


public class JumpToIntroduction0 : MonoBehaviour
{
    public void StartBtn()
    {
        SceneManager.LoadScene("Introduction-0");
    }
}
