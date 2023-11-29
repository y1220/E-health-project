using System.Collections;
using System.Collections.Generic;
using System.Runtime.Serialization.Json;
using System.Xml;
using UnityEngine.SceneManagement;
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
    private string API_URL = "http://192.168.1.5:3000/players";
    
    public void CreatePlayer()
    {
        StartCoroutine(Send(API_URL));

    }

    IEnumerator Send(string uri)
    {
        Component[] components = username.GetComponents(typeof(Component));
        foreach (Component component in components) {
             Debug.Log(component.ToString());
        }
        Username = username.GetComponent<TMPro.TMP_InputField>().text;
        Email = email.GetComponent<TMPro.TMP_InputField>().text;
        Password = password.GetComponent<TMPro.TMP_InputField>().text;
        
        PlayerData data = new PlayerData(
            Username, Email, Password
        );

        string jsonData = JsonUtility.ToJson(data);
        UnityWebRequest webRequestSignup = new UnityWebRequest(uri, "POST");
        byte[] bodyRaw = System.Text.Encoding.UTF8.GetBytes(jsonData);
        webRequestSignup.uploadHandler = new UploadHandlerRaw(bodyRaw);
        webRequestSignup.downloadHandler = new DownloadHandlerBuffer();
        // this is needed for ruby on rails
        webRequestSignup.SetRequestHeader("Content-Type", "application/json");

        yield return webRequestSignup.SendWebRequest();
        Debug.Log("Signup: returned response from rails");
        Debug.Log("Signup " + webRequestSignup.result);
        switch (webRequestSignup.result)
        {
            case UnityWebRequest.Result.ConnectionError:
            case UnityWebRequest.Result.DataProcessingError:
                Debug.Log(": ERROR: " + webRequestSignup.error);
                SceneManager.LoadScene("Signup");
                break;
            case UnityWebRequest.Result.ProtocolError:
                Debug.Log(": HTTP ERROR: " + webRequestSignup.error);
                SceneManager.LoadScene("Signup");
                break;
            case UnityWebRequest.Result.Success:
                Debug.Log("Received: " + webRequestSignup.downloadHandler.text);
                PlayerMonster playerMonster = JsonUtility.FromJson<PlayerMonster>(webRequestSignup.downloadHandler.text);
                Debug.Log(playerMonster.id + ": " + playerMonster.username);
                SceneManager.LoadScene("Survey");
                break;
        }
    }

}
