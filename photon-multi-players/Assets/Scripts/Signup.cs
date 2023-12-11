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
        foreach (Component component in components)
        {
            Debug.Log(component.ToString());
        }
        Username = username.GetComponent<TMPro.TMP_InputField>().text;
        Email = email.GetComponent<TMPro.TMP_InputField>().text;
        Password = password.GetComponent<TMPro.TMP_InputField>().text;

        PlayerData data = new PlayerData(
            Username, Email, Password
        );

        Debug.Log(Username);
        Debug.Log(Email);
        Debug.Log(Password);

        string jsonData = JsonUtility.ToJson(data);
        Debug.Log(jsonData);

        UnityWebRequest webRequestSignup = new UnityWebRequest(uri, "POST");
        Debug.Log(uri);

        byte[] bodyRaw = System.Text.Encoding.UTF8.GetBytes(jsonData);
        Debug.Log(bodyRaw);

        webRequestSignup.uploadHandler = new UploadHandlerRaw(bodyRaw);
        Debug.Log("After upload");

        webRequestSignup.downloadHandler = new DownloadHandlerBuffer();
        Debug.Log("After download");

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
                //SceneManager.LoadScene("Survey");
                //SceneManager.LoadScene("Thanks");
                break;
            case UnityWebRequest.Result.ProtocolError:
                Debug.Log(": HTTP ERROR: " + webRequestSignup.error);
                SceneManager.LoadScene("Signup");
                break;
            case UnityWebRequest.Result.Success:
                Debug.Log("Received: " + webRequestSignup.downloadHandler.text);
                PlayerMonster playerMonster = JsonUtility.FromJson<PlayerMonster>(webRequestSignup.downloadHandler.text);
                PlayerPrefs.SetString("UserID", playerMonster.id.ToString());
                PlayerPrefs.SetString("Username", playerMonster.username.ToString());
                PlayerPrefs.SetString("Email", playerMonster.email.ToString());

                Debug.Log(playerMonster.id + ": " + playerMonster.username);
                SceneManager.LoadScene("Survey");
                break;
        }
    }

}
