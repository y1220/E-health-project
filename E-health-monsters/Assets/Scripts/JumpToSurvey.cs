using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class JumpToSurvey : MonoBehaviour
{
    public void StartBtn()
    {
        SceneManager.LoadScene("Survey");
    }
}
