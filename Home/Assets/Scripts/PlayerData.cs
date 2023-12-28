using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[System.Serializable]
public class PlayerData
{
    public string username;
    public string email;
    public string password;

    public PlayerData(string username, string email, string password)
    {
        this.username = username;
        this.email = email;
        this.password = password;
    }
}
