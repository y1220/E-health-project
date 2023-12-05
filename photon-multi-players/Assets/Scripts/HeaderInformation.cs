using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using Photon.Pun;

public class HeaderInformation : MonoBehaviourPun
{
    public TextMeshProUGUI playerName;
    public HeaderInformation()
    {
        Debug.Log(PhotonNetwork.NickName);
        playerName.text = PhotonNetwork.NickName;
    }
    public void Initialized(string text)
    {
        Debug.Log(text);
        playerName.text = text;
    }
    
}
