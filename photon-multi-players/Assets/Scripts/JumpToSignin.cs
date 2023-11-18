using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class JumpToSignin : MonoBehaviour
{
    public void StartBtn()
    {
        SceneManager.LoadScene("Signin");
    }
}
