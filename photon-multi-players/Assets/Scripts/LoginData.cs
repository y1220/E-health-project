using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[System.Serializable]
public class LoginData
{
    public string username;
    public string email;
    public string password;

    public LoginData(string email, string password)
    {
        this.email = email;
        this.password = password;
    }
}
