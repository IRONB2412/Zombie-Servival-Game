using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;
using Realms;

public  class MouseSettings : MonoBehaviour
{
    public Slider mouseSlider;
    private CameraLook cameraLook;
    public TextMeshProUGUI SliderText;
    private Realm realm;
    private DataBase data;


     

    public void Start()
    {
        realm=Realm.GetInstance();
        data = realm.Find<DataBase>(PassBetweenscence.CurrentUserName);
        if(!(data==null))
        {
            SliderText.text=data.MouseSenci.ToString();
            mouseSlider.value = data.MouseSenci;
            CameraLook.mouseSensitivity = data.MouseSenci;
        }
        mouseSlider.onValueChanged.AddListener((Svalue) =>
        {
           
           data=realm.Find<DataBase>(PassBetweenscence.CurrentUserName);
            if(data!=null)
            {
                realm.Write(() =>
                {
                    data.MouseSenci=Svalue;
                });
                SliderText.text = data.MouseSenci.ToString();

                CameraLook.mouseSensitivity=data.MouseSenci;

            }
        });
    }
    private void OnDisable()
    {
        realm.Dispose();
    }
} 
