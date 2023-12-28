using System.Collections;
using System.Collections.Generic;
using System.Runtime.Serialization.Json;
using System.Xml;
using UnityEngine.SceneManagement;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.UI;


public class QuestionMaker : MonoBehaviour
{
    public GameObject title;
    public GameObject option1;
    public GameObject option2;
    public GameObject option3;
    public GameObject answerIndex;

    private string Title;
    private string Option1;
    private string Option2;
    private string Option3;
    private string AnswerIndex;
    private string CreatedBy;
    private string CreatedFor;

    [SerializeField]
    private string API_URL = Configuration.ApiUrlEndpoint + "/questions";

    public void MakeQuestion()
    {
        StartCoroutine(Send(API_URL));

    }

    IEnumerator Send(string uri)
    {
        Title = title.GetComponent<TMPro.TMP_InputField>().text;
        Option1 = option1.GetComponent<TMPro.TMP_InputField>().text;
        Option2 = option2.GetComponent<TMPro.TMP_InputField>().text;
        Option3 = option3.GetComponent<TMPro.TMP_InputField>().text;
        AnswerIndex = answerIndex.GetComponent<TMPro.TMP_InputField>().text;
        CreatedBy = PlayerPrefs.GetString("UserID");
        CreatedFor = "1"; //TODO: take partner's userId

        QuestionData data = new QuestionData(
            Title, Option1, Option2, Option3, AnswerIndex, CreatedBy, CreatedFor
        );

        string jsonData = JsonUtility.ToJson(data);
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
        Debug.Log("Question: " + webRequestSignup.result);
        switch (webRequestSignup.result)
        {
            case UnityWebRequest.Result.ConnectionError:
            case UnityWebRequest.Result.DataProcessingError:
                Debug.Log(": ERROR: " + webRequestSignup.error);
                SceneManager.LoadScene("QuestionMaker");
                //SceneManager.LoadScene("Survey");
                //SceneManager.LoadScene("Thanks");
                break;
            case UnityWebRequest.Result.ProtocolError:
                Debug.Log(": HTTP ERROR: " + webRequestSignup.error);
                SceneManager.LoadScene("QuestionMaker");
                break;
            case UnityWebRequest.Result.Success:
                Debug.Log("Received: " + webRequestSignup.downloadHandler.text);
                //QuestionData question = JsonUtility.FromJson<QuestionData>(webRequestSignup.downloadHandler.text);
                //PlayerPrefs.SetString("QuestionID", question.id.ToString());
                SceneManager.LoadScene("Game");
                break;
        }
    }

}
