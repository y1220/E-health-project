using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class JumpToMorning : MonoBehaviour
{
    public void StartBtn()
    {
        SceneManager.LoadScene("Morning");
    }
}
