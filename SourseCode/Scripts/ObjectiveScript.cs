using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;

public class ObjectiveScript : MonoBehaviour
{
    public GameObject ObjectivePanle;
    public TextMeshProUGUI ObjectiveText1;
    public TextMeshProUGUI ObjectiveText2;
    public TextMeshProUGUI ObjectiveText3;
    public GameObject MsgTxt,LodingBackground;
    public GameObject ArGunHand;
    public GameObject PistolGunHand;
    public LoadScence Scenceloder;
    public KillCount Countkills;
    

    
    void Update()
    {
        if (LodingBackground.activeSelf == true)
        {
            ObjectivePanle.SetActive(false);
        }
        if(Input.GetKeyDown(KeyCode.Tab) && ObjectivePanle.activeSelf==false)
        {
            ObjectivePanle.gameObject.SetActive(true);
        }
        else
        if(Input.GetKeyDown(KeyCode.Tab) && ObjectivePanle.activeSelf == true)
        {
            ObjectivePanle.gameObject.SetActive(false);
        }
        switch(SceneManager.GetActiveScene().buildIndex)
        {
            case 2:
              
                
                ObjectiveText1.text = "Pick Up The Guns And Ammo";
                ObjectiveText2.text = "Kill"+"("+ Scenceloder.RequiredKills +")"+" Zombie";
                ObjectiveText3.text = "Find The Way Out";
                if (PistolGunHand.activeSelf == true && ArGunHand.activeSelf == true)
                {
                    ObjectiveText1.color = Color.green;
                }
                if(Countkills.CurrentKill>=Scenceloder.RequiredKills)
                {
                    ObjectiveText2.color = Color.green;
                }
            
            
                break;
                case 3:
                
               ObjectiveText1.text = "Pick Up All The Guns And Ammo";
                ObjectiveText2.text = "Kill 25 Zombie";
                ObjectiveText3.text = "Explore The map";
                if (PistolGunHand.activeSelf == true && ArGunHand.activeSelf == true)
                {
                    ObjectiveText1.color = Color.green;
                }
                if(Countkills.CurrentKill>=25)
                {
                    ObjectiveText2.color = Color.green;
                }
                break;
        }
        
    }
}
