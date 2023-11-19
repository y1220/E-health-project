using System.Collections;
using System.Collections.Generic;
using System.Runtime.Serialization.Json;
using System.Xml;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.UI;


public class Signin : MonoBehaviour
{
    public GameObject email;
    public GameObject password;

    private string Email;
    private string Password;

    [SerializeField]
    private string API_URL = "http://192.168.1.5:3000/login";
    
    public void Login()
    {
        StartCoroutine(Send(API_URL));

    }

    IEnumerator Send(string uri)
    {
        Email = email.GetComponent<TMPro.TMP_InputField>().text;
        Password = password.GetComponent<TMPro.TMP_InputField>().text;
        
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
                PlayerMonster player = JsonUtility.FromJson<PlayerMonster>(webRequest.downloadHandler.text);
                Debug.Log(player.id + ": " + player.username);
                break;
        }
    }

}
