using UnityEngine;
using TMPro;
using Photon.Pun;
using UnityEngine.UIElements;

public class DisplayPlayerNickname : MonoBehaviour
{
    public TextMeshProUGUI userIdText;
    public TextMeshProUGUI usernameText;
    public TextMeshProUGUI emailText;
    public SpriteRenderer profileImages;

    void SetUserIdText(string userId)
    {
        // Update the UI with the player's nickname
        if (userIdText != null)
        {
            userIdText.text = userId;
        }
        else
        {
            Debug.LogError("UserIdText reference is not set in the inspector.");
        }
    }

    void SetUsernameText(string username)
    {
        // Update the UI with the player's username
        if (username != null)
        {
            usernameText.text = username;
        }
        else
        {
            Debug.LogError("UsernameText reference is not set in the inspector.");
        }
    }

    void SetEmailText(string email)
    {
        // Update the UI with the player's email
        if (emailText != null)
        {
            emailText.text = email;
        }
        else
        {
            Debug.LogError("EmailText reference is not set in the inspector.");
        }
    }

    void SetImage(string userType)
    {
        Debug.Log(userType);
        ProfileImageSetter imageSetter = profileImages.GetComponent<ProfileImageSetter>();
        imageSetter.SetSpriteBasedOnRole(userType);
    }

    void Start()
    {
        // Check if PhotonNetwork is connected and check if the player data is preserved
        if (PhotonNetwork.IsConnected && PhotonNetwork.InRoom)
        {
            // Display the player's nickname from playerPrefs
            Debug.Log("UserID: " + PlayerPrefs.GetString("UserID"));
            SetUserIdText(PlayerPrefs.GetString("UserID"));
            SetUsernameText(PlayerPrefs.GetString("Username"));
            SetEmailText(PlayerPrefs.GetString("Email"));
            Debug.Log(PlayerPrefs.GetString("UserType"));
            // Set the profile picture based on userType
            SetImage(PlayerPrefs.GetString("UserType"));
            //SetImage("Ester");
        }
        else
        {
            Debug.LogWarning("PhotonNetwork is not connected or player has no nickname.");
        }
    }
}
