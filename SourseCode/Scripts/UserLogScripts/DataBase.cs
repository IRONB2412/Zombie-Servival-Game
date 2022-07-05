using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Realms;

public class DataBase : RealmObject
{
    [PrimaryKey]public string UserName { get; set; }
    

    public string Password { get; set; }
    public float MouseSenci { get; set; }
    public float SoundVol { get; set; }

    public DataBase() { }

    public DataBase(string userName, string password, float mouseSenci, float soundVol)
    {
        this.UserName = userName;
        this.Password = password;
        this.MouseSenci = mouseSenci;
        this.SoundVol = soundVol;
    }
}
