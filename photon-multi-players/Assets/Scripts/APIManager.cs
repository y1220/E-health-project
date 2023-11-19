using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class APIManager : MonoBehaviour
{
    private string API_URL = "http://192.168.43.250:3000/players";
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(GetRequest(API_URL + "/1"));
        // post request
        StartCoroutine(PostRequest(API_URL));

    }
    
    IEnumerator GetRequest(string uri)
    {
        using (UnityWebRequest webRequest = UnityWebRequest.Get(uri))
        {
            // Request and wait for the desired page
            yield return webRequest.SendWebRequest();
            string[] pages = uri.Split('/');
            int page = pages.Length - 1;
            Debug.Log(webRequest.result);
            switch (webRequest.result)
            {
                case UnityWebRequest.Result.ConnectionError:
                case UnityWebRequest.Result.DataProcessingError:
                    Debug.Log(pages[page] + ": ERROR: " + webRequest.error);
                    break;
                case UnityWebRequest.Result.ProtocolError:
                    Debug.Log(pages[page] + ": HTTP ERROR: " + webRequest.error);
                    break;
                case UnityWebRequest.Result.Success:
                    Debug.Log(pages[page] + ":\nReceived: " + webRequest.downloadHandler.text);
                    PlayerMonster player = JsonUtility.FromJson<PlayerMonster>(webRequest.downloadHandler.text);
                    Debug.Log(player.username);
                    break;
            }
        }
    }

    IEnumerator PostRequest(string uri)
    {
        PlayerData data = new PlayerData(
            "player2", "player2@example.com", "password"
        );

        string jsonData = JsonUtility.ToJson(data);
        UnityWebRequest webRequest = new UnityWebRequest(uri, "POST");
        byte[] bodyRaw = System.Text.Encoding.UTF8.GetBytes(jsonData);
        webRequest.uploadHandler = new UploadHandlerRaw(bodyRaw);
        webRequest.downloadHandler = new DownloadHandlerBuffer();
        // this is needed for ruby on rails
        webRequest.SetRequestHeader("Content-Type", "application/json");

        yield return webRequest.SendWebRequest();
        
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
                Debug.Log(player.username);
                break;
        }
    }
}
