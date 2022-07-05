using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class KillCount : MonoBehaviour
{
    public GameObject Killcount;
    public int MyKills=0;
    public int CurrentKill=0;
   
    
    void Update()
    {
        Killcount.GetComponent<Text>().text= MyKills.ToString();
    }
    public void GetKill(int kill)
    {
       CurrentKill += kill;
      MyKills=CurrentKill;
    }
}
