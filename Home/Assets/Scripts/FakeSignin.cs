using System.Collections;
using System.Collections.Generic;
using System.Runtime.Serialization.Json;
using System.Xml;
using UnityEngine.SceneManagement;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.UI;


public class FakeSignin : MonoBehaviour
{
    public void Login()
    {
        PlayerPrefs.SetString("UserID", "1");
        PlayerPrefs.SetString("Username", "test");
        PlayerPrefs.SetString("Email", "test@example.com");
        SceneManager.LoadScene("Planets");
    }
}
