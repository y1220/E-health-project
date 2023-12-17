using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ButtonController : MonoBehaviour
{
    [SerializeField] GameObject BCont;
    [SerializeField] GameObject BMenu;
    [SerializeField] GameObject BResp;

    private int currentSceneIndex;

    private void Start()
    {
        Time.timeScale = 1;
        BCont.SetActive(false);
        BMenu.SetActive(false);
        BResp.SetActive(false);

        currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
    }

    public void Pause()
    {
        BCont.SetActive(true);
        BMenu.SetActive(true);
        BResp.SetActive(true);
        Time.timeScale = 0;
    }

    public void Restart()
    {
        BCont.SetActive(false);
        BMenu.SetActive(false);
        SceneManager.LoadScene(currentSceneIndex);
        Time.timeScale = 1;
    }

    public void Continue ()
    {
        BCont.SetActive(false);
        BResp.SetActive(false);
        BMenu.SetActive(false);
        Time.timeScale = 1;
    }
    public void Menu ()
    {
        BCont.SetActive(false);
        BMenu.SetActive(false);
        BResp.SetActive(false);
        SceneManager.LoadScene(0);
    }

}

