using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class JumpToIntroduction1 : MonoBehaviour
{
    public void StartBtn()
    {
        SceneManager.LoadScene("Introduction-1");
    }
}
