using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class JumpToGame : MonoBehaviour
{
    private const string SceneName = "Game";

    public void StartBtn()
    {
        SceneManager.LoadScene(SceneName);
    }
}
