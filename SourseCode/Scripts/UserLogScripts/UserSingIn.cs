using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using Realms;
using UnityEngine.SceneManagement;

public class UserSingIn : MonoBehaviour
{
    public string UserID;
    public string UserPass;
    public float MouseSenci=50;
    public float SoundVol=50;
    public GameObject InputUserID;
    public GameObject InputUserPass;
    private Realm realm;
    private DataBase data;
    public PassBetweenscence PassingScript;
    public TextMeshProUGUI ShowProgress;
    

    public void Start()
    {
        realm = Realm.GetInstance();
        Debug.Log(realm.Config.DatabasePath);


    }
    public void Update()
    {
        UserID = InputUserID.GetComponent<TMP_InputField>().text;
        UserPass = InputUserPass.GetComponent<TMP_InputField>().text;
        
       

        
    }
    public void RegisterUser()
    {
         realm=Realm.GetInstance();
        data = realm.Find<DataBase>(UserID);
        if(data!=null)
        {
            ShowProgress.text = null;
            ShowProgress.text = "User is already exists";
            return;
        }else
        {
            realm.Write(() =>
            {
                data = realm.Add(new DataBase(UserID, UserPass, MouseSenci,SoundVol));
                Debug.Log(data.UserName + UserPass);
            });
        }
        realm.Dispose();
    }
    public void LogIn()
    {
        Debug.Log(realm.Config.DatabasePath);
        realm = Realm.GetInstance();
        data = realm.Find<DataBase>(UserID);
        /*data= realm.Find<DataBase>(UserPass);*/
        if(data==null)
        {
            ShowProgress.text = null;
            ShowProgress.text = "User Not Found pleas Creat a User";
            return;
        }
        else
        if(UserID==data.UserName && UserPass==data.Password)
        {
            ShowProgress.text = null;
            ShowProgress.text="user Log in succsessfull";

            PassBetweenscence.CurrentUserName = UserID;

            SceneManager.LoadScene(1);
        }
        
    }
   
}
