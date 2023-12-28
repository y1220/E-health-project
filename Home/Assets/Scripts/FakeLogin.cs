using System.Collections;
using System.Collections.Generic;
using System.Runtime.Serialization.Json;
using System.Xml;
using UnityEngine.SceneManagement;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.UI;


public class FakeLogin : MonoBehaviour
{

    private string Email;
    private string Password;

    [SerializeField]
    private string API_URL = "http://192.168.3.138:3000/login";

    void Start()
    {
        StartCoroutine(Send(API_URL));
    }

    public void Login()
    {
        StartCoroutine(Send(API_URL));

    }

    IEnumerator Send(string uri)
    {
        Email = "ale2";
        Password = "ale2";

        LoginData data = new LoginData(
            Email, Password
        );

        string jsonData = JsonUtility.ToJson(data);
        UnityWebRequest webRequest = new UnityWebRequest(uri, "GET");
        byte[] bodyRaw = System.Text.Encoding.UTF8.GetBytes(jsonData);
        webRequest.uploadHandler = new UploadHandlerRaw(bodyRaw);
        webRequest.downloadHandler = new DownloadHandlerBuffer();
        // this is needed for ruby on rails
        webRequest.SetRequestHeader("Content-Type", "application/json");

        yield return webRequest.SendWebRequest();
        Debug.Log("Signin: returned response from rails");
        Debug.Log(webRequest.result);
        switch (webRequest.result)
        {
            case UnityWebRequest.Result.ConnectionError:
            case UnityWebRequest.Result.DataProcessingError:
                Debug.Log(": ERROR: " + webRequest.error);
                break;
            case UnityWebRequest.Result.ProtocolError:
                Debug.Log(": HTTP ERROR: " + webRequest.error);
                break;
            case UnityWebRequest.Result.Success:
                Debug.Log("Received: " + webRequest.downloadHandler.text);
                PlayerMonster playerMonster = JsonUtility.FromJson<PlayerMonster>(webRequest.downloadHandler.text);
                PlayerPrefs.SetString("UserID", playerMonster.id.ToString());
                PlayerPrefs.SetString("Username", playerMonster.username.ToString());
                PlayerPrefs.SetString("Email", playerMonster.email.ToString());
                Debug.Log(playerMonster.id + ": " + playerMonster.username);
                SceneManager.LoadScene("Planets");

                break;
        }
    }

}
