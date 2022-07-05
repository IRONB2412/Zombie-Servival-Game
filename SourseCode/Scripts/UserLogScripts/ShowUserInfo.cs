using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using Realms;
using TMPro;

public class ShowUserInfo : MonoBehaviour
{
    private Realm realm;
    private DataBase data;
    public TextMeshProUGUI ShowUserName;

    private void Start()
    {
        ShowUserName.text = PassBetweenscence.CurrentUserName;
    }


    /*public void GetUser(string GetUserId)
    {
        realm = Realm.GetInstance();
        data = realm.Find<DataBase>(GetUserId);
        if(data.UserName==GetUserId)
        {
            ShowUserName.text = GetUserId;
        }
    }*/
}
