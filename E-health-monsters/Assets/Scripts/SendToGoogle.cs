using System.Collections;
using System.Collections.Generic;
using System.Runtime.Serialization.Json;
using System.Xml;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.UI;


public class SendToGoogle : MonoBehaviour
{
    public GameObject username;
    public GameObject email;
    public GameObject phone;

    private string Name;
    private string Email;
    private string Phone;

    [SerializeField]
    private string BASE_URL = "https://docs.google.com/forms/u/0/d/e/1FAIpQLScX4PlbCUNSNpAgN84V2ERlVJLxlvL3yd2dmhW9CBngp3WyCg/formResponse";

    IEnumerator Post(string name, string email, string phone)
    {
        WWWForm form = new WWWForm();
        form.AddField("entry.1853058693", name);
        form.AddField("entry.1118730284", email);
        form.AddField("entry.358183629", phone);
        //byte[] rawData = form.data;
        UnityWebRequest www = UnityWebRequest.Post(BASE_URL, form);
        yield return www.SendWebRequest();
    }

    public void Send()
    {
        //var json = JsonSerializer.Serialize(user);
        //string json = jsonSerializer.Serialize(yourCustomObject);
        //var output = JsonConvert.SerializeObject(username);
        //var output = JsonUtility.ToJson(username.GetComponent<T>(), true);
        //Debug.Log(username.GetComponent<Text>());
        Component[] components = username.GetComponents(typeof(Component));
        foreach (Component component in components)
        {
            Debug.Log(component.ToString());
        }
        Name = username.GetComponent<TMPro.TMP_InputField>().text;
        Email = email.GetComponent<TMPro.TMP_InputField>().text;
        Phone = phone.GetComponent<TMPro.TMP_InputField>().text;

        StartCoroutine(Post(Name, Email, Phone));

    }



}
