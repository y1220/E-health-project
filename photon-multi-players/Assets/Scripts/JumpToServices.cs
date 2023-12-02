using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class JumpToServices : MonoBehaviour
{
    private const string SceneName = "Services";

    public void StartBtn()
    {
        SceneManager.LoadScene(SceneName);
    }
}
