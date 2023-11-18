using System.Collections;
using System.Collections.Generic;
using System.Runtime.Serialization.Json;
using System.Xml;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.UI;


public class Signup : MonoBehaviour
{
    public GameObject username;
    public GameObject email;
    public GameObject password;

    private string Username;
    private string Email;
    private string Password;

    [SerializeField]
    private string API_URL = "http://192.168.43.250:3000/players";
    
    public void CreatePlayer()
    {
        StartCoroutine(Send(API_URL));

    }

    IEnumerator Send(string uri)
    {
        // Component[] components = username.GetComponents(typeof(Component));
        // foreach (Component component in components)
        // {
        //     Debug.Log(component.ToString());
        // }
        Username = username.GetComponent<TMPro.TMP_InputField>().text;
        Email = email.GetComponent<TMPro.TMP_InputField>().text;
        Password = password.GetComponent<TMPro.TMP_InputField>().text;
        
        PlayerData data = new PlayerData(
            Username, Email, Password
        );

        string jsonData = JsonUtility.ToJson(data);
        UnityWebRequest webRequest = new UnityWebRequest(uri, "POST");
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
                PlayerData player = JsonUtility.FromJson<PlayerData>(webRequest.downloadHandler.text);
                Debug.Log(player.username);
                break;
        }
    }

}
