using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[System.Serializable]
public class UserRole
{
    public int id;
    public int role;

    public UserRole(int userId, int role)
    {
        this.id = userId;
        this.role = role;
    }
}
