using UnityEngine;
using TMPro;
using Photon.Pun;

public class DisplayPlayerNickname : MonoBehaviour
{
    public TextMeshProUGUI nicknameText;

    void Start()
    {
        // Check if PhotonNetwork is connected and the player has a nickname
        if (PhotonNetwork.IsConnected && PhotonNetwork.InRoom)
        {
            // Display the player's nickname
            SetNicknameText(PhotonNetwork.NickName);
        }
        else
        {
            Debug.LogWarning("PhotonNetwork is not connected or player has no nickname.");
        }
    }

    void SetNicknameText(string nickname)
    {
        // Update the UI with the player's nickname
        if (nicknameText != null)
        {
            nicknameText.text = nickname;
        }
        else
        {
            Debug.LogError("NicknameText reference is not set in the inspector.");
        }
    }
}