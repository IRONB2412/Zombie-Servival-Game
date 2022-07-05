using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using Realms;

public class SoundSettings : MonoBehaviour
{

    public Slider musicSlider;
    public Realm realm;
    public DataBase data;
    public TextMeshProUGUI SliderText;

    
  
    

    public void Start()
    {
        realm = Realm.GetInstance();
        data = realm.Find<DataBase>(PassBetweenscence.CurrentUserName);
        if (!(data == null))
        {
            SliderText.text = data.SoundVol.ToString();
            musicSlider.value = data.SoundVol;
            AudioListener.volume= data.SoundVol/100;
        }
        musicSlider.onValueChanged.AddListener((Svalue) =>
        {
            
            data = realm.Find<DataBase>(PassBetweenscence.CurrentUserName);
            if (data != null)
            {
                realm.Write(() =>
                {
                    data.SoundVol = Svalue;
                });
                SliderText.text = data.SoundVol.ToString();

                AudioListener.volume = data.SoundVol/100;

            }
        });
    }
    private void OnDisable()
    {
        realm.Dispose();
    }

    
    
}
    