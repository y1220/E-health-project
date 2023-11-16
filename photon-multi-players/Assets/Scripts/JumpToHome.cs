using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class JumpToHome : MonoBehaviour
{
    private const string SceneName = "Home";

    public void StartBtn()
    {
        SceneManager.LoadScene(SceneName);
    }
}
