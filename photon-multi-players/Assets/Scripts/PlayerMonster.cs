using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[System.Serializable]
public class PlayerMonster
{
    public int id;
    public string username;
    public string email;
    public string password;

    public PlayerMonster(int id, string username, string email, string password)
    {
        this.id = id;
        this.username = username;
        this.email = email;
        this.password = password;
    }
}
