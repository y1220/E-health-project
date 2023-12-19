using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Networking;
using UnityEngine.UI;

public class UIScript : MonoBehaviour
{
    public GameObject[] questionGroupArr;
    public QAClass[] qaArr;
    public GameObject AnswerPanel;

    [SerializeField]
    private string BASE_URL = "https://docs.google.com/forms/u/0/d/e/1FAIpQLSdPB3JeF_PS5mVXHJ-nuOkir8caLpg_n1YzHRRw5xec52VcqA/formResponse";

    [SerializeField]
    private string API_URL = "http://192.168.10.112:3000/role";


    // Start is called before the first frame update
    void Start()
    {
        qaArr = new QAClass[questionGroupArr.Length];
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void SubmitAnswer()
    {

        string[] entries = { "entry.39974158", "entry.1925534193", "entry.1046761834" };
        for (int i = 0; i < qaArr.Length; i++)
        {
            qaArr[i] = ReadQuestionAndAnswer(questionGroupArr[i]);
            Debug.Log(qaArr[i].Question);
            Debug.Log(qaArr[i].Answer);
        }


        StartCoroutine(Post(qaArr));
        StartCoroutine(Send(qaArr));
    }

    QAClass ReadQuestionAndAnswer(GameObject questionGroup)
    {
        QAClass result = new QAClass();

        GameObject q = questionGroup.transform.Find("Question").gameObject;
        GameObject a = questionGroup.transform.Find("Answer").gameObject;

        Component[] components = q.GetComponents(typeof(Component));
        foreach (Component component in components)
        {
            Debug.Log(component.ToString());
        }

        Component[] components2 = a.transform.GetChild(0).GetComponents(typeof(Component));
        foreach (Component component in components2)
        {
            Debug.Log(component.ToString());
        }

        result.Question = q.GetComponent<TMPro.TextMeshProUGUI>().text;


        if (a.GetComponent<ToggleGroup>() != null)
        {
            for (int i = 0; i < a.transform.childCount; i++)
            {
                if (a.transform.GetChild(i).GetComponent<Toggle>().isOn)
                {
                    result.Answer = a.transform.GetChild(i).Find("Label").GetComponent<Text>().text;
                    break;
                }
            }
        }
        else if (a.GetComponent<TMPro.TMP_InputField>() != null)
        {
            result.Answer = a.GetComponent<TMPro.TMP_InputField>().text;
        }
        else if (a.GetComponent<ToggleGroup>() == null && a.GetComponent<TMPro.TMP_InputField>() == null)
        {
            string s = "";
            int counter = 0;

            for (int i = 0; i < a.transform.childCount; i++)
            {
                if (a.transform.GetChild(i).GetComponent<Toggle>().isOn)
                {
                    if (counter != 0)
                    {
                        s = s + ", ";
                    }
                    s = s + a.transform.GetChild(i).Find("Label").GetComponent<Text>().text;
                    counter++;
                }

                if (i == a.transform.childCount - 1)
                {
                    s = s + ".";
                }
            }
            result.Answer = s;
        }

        return result;
    }

    IEnumerator Post(QAClass[] qaArr)
    {
        WWWForm form = new WWWForm();
        string[] entries = { "entry.39974158", "entry.1925534193", "entry.1046761834", "entry.1498878993" };
        for (int i = 0; i < qaArr.Length; i++)
        {
            Debug.Log(entries[i] + ": " + qaArr[i].Answer);
            form.AddField(entries[i], qaArr[i].Answer);
        }

        UnityWebRequest www = UnityWebRequest.Post(BASE_URL, form);
        yield return www.SendWebRequest();
    }

    IEnumerator Send(QAClass[] qaArr)
    {
        int role = 0;
        if (qaArr[2].Answer == "Estel(helper)")
        {
            role = 1;
        }
        else
        {
            role = 2;
        }

        UserRole data = new UserRole(
            50, role
        );

        string jsonData = JsonUtility.ToJson(data);
        UnityWebRequest webRequestRoleUpdate = new UnityWebRequest(API_URL, "PUT");
        byte[] bodyRaw = System.Text.Encoding.UTF8.GetBytes(jsonData);
        webRequestRoleUpdate.uploadHandler = new UploadHandlerRaw(bodyRaw);
        webRequestRoleUpdate.downloadHandler = new DownloadHandlerBuffer();
        // this is needed for ruby on rails
        webRequestRoleUpdate.SetRequestHeader("Content-Type", "application/json");

        yield return webRequestRoleUpdate.SendWebRequest();
        Debug.Log("Survey: returned response from rails");
        Debug.Log("Survey " + webRequestRoleUpdate.result);
        switch (webRequestRoleUpdate.result)
        {
            case UnityWebRequest.Result.ConnectionError:
            case UnityWebRequest.Result.DataProcessingError:
                Debug.Log(": ERROR: " + webRequestRoleUpdate.error);
                SceneManager.LoadScene("Survey");
                break;
            case UnityWebRequest.Result.ProtocolError:
                Debug.Log(": HTTP ERROR: " + webRequestRoleUpdate.error);
                SceneManager.LoadScene("Survey");
                break;
            case UnityWebRequest.Result.Success:
                Debug.Log("Received: " + webRequestRoleUpdate.downloadHandler.text);
                PlayerMonster playerMonster = JsonUtility.FromJson<PlayerMonster>(webRequestRoleUpdate.downloadHandler.text);
                Debug.Log(playerMonster.id + ": " + playerMonster.username);
                SceneManager.LoadScene("PlayerSelection");
                break;
        }
    }

}

[System.Serializable]
public class QAClass
{
    public string Question = "";
    public string Answer = "";
}
