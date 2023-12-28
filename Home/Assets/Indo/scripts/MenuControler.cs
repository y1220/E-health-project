using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement; 

public class MenuController : MonoBehaviour 
{
    public void Menu()
    {
        SceneManager.LoadScene("Menu_platformer");
    }
    public void Intro()
    {
        SceneManager.LoadScene("AboutIndo");
    }
    public void Level1() 
    {
        SceneManager.LoadScene("lvl1");
    }
    public void Level2()
    {
        SceneManager.LoadScene("lvl2");
    }
    public void Level3()
    {
        SceneManager.LoadScene("lvl3");
    }

    public void Exit()
    {
        Application.Quit();
    }
}
