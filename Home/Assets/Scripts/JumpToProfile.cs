using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class JumpToProfile : MonoBehaviour
{
    private const string SceneName = "Profile";


    public void StartBtn()
    {
        SceneManager.LoadScene(SceneName);
    }
}
