using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.SceneManagement;

public class PlayerSelector : MonoBehaviour
{
    public GameObject nextButton;

    public GameObject backwardButton;

    public static PlayerSelector instance;

    public string playerPrefabName;

    public GameObject[] playerModel;
    public int selectedCharacter;
    private string API_URL = Configuration.ApiUrlEndpoint + "/role";

    private void Awake()
    {
        instance = this;
    }

    // Start is called before the first frame update
    void Start()
    {
        if (PlayerPrefs.HasKey("SelectedCharacter"))
        {
            selectedCharacter = PlayerPrefs.GetInt("SelectedCharacter");
            playerPrefabName = playerModel[selectedCharacter].GetComponent<PlayerModelName>().playerName;

            //nextButton.SetActive(false);
            //backwardButton.SetActive(false);
        }
        else
        {
            nextButton.SetActive(true);
            backwardButton.SetActive(true);
        }

        foreach (GameObject player in playerModel)
        {
            player.SetActive(false);
        }

        playerModel[selectedCharacter].SetActive(true);
        AudioManager.instance.PlaySFX(1);

        //PlayerPrefs.SetString("UserType", playerPrefabName);

        //StartCoroutine(PutRequest(API_URL + "/update_role"));

        // Set UserType into PlayerPrefs
        //PlayerPrefs.SetString("UserType", "Player");
    }

    public void SelectCharacter()
    {
        selectedCharacter = PlayerPrefs.GetInt("SelectedCharacter");
        playerPrefabName = playerModel[selectedCharacter].GetComponent<PlayerModelName>().playerName;
        PlayerPrefs.SetInt("SelectedCharacter", selectedCharacter);
        Debug.Log(selectedCharacter);
        PlayerPrefs.SetString("UserType", playerPrefabName);
        StartCoroutine(PutRequest(API_URL));
        SceneManager.LoadScene("Thanks");
    }

    public void ChangeNext()
    {
        AudioManager.instance.PlaySFX(1);
        playerModel[selectedCharacter].SetActive(false);
        selectedCharacter++;
        if (selectedCharacter == playerModel.Length)
            selectedCharacter = 0;
        playerModel[selectedCharacter].SetActive(true);
        PlayerPrefs.SetInt("SelectedCharacter", selectedCharacter);
        playerPrefabName = playerModel[selectedCharacter].GetComponent<PlayerModelName>().playerName;
    }

    public void ChangeBack()
    {
        AudioManager.instance.PlaySFX(1);
        playerModel[selectedCharacter].SetActive(false);
        selectedCharacter--;
        if (selectedCharacter == -1)
            selectedCharacter = playerModel.Length - 1;
        playerModel[selectedCharacter].SetActive(true);
        PlayerPrefs.SetInt("SelectedCharacter", selectedCharacter);
    }

    IEnumerator PutRequest(string uri)
    {
        Debug.Log(PlayerPrefs.GetString("UserType"));
        PlayerRoleData data = new PlayerRoleData(
            PlayerPrefs.GetString("UserID"), "1"
        );


        Debug.Log(PlayerPrefs.GetString("UserType"));
        if (PlayerPrefs.GetString("UserType") == "hardir")
        {
            data = new PlayerRoleData(
                PlayerPrefs.GetString("UserID"), "2"
            );
        }

        string jsonData = JsonUtility.ToJson(data);
        UnityWebRequest webRequest = new UnityWebRequest(uri, "PUT");
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
