using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[System.Serializable]
public class PlayerRoleData
{
    public string id;
    public string role;


    public PlayerRoleData(string id, string role)
    {
        this.id = id;
        this.role = role;
    }
}
