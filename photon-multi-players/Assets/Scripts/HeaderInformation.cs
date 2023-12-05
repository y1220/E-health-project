using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using Photon.Pun;

public class HeaderInformation : MonoBehaviour
{
    public TextMeshProUGUI playerName;

    public void Initialized(string text)
    {
        playerName.text = text;
    }
    
}
