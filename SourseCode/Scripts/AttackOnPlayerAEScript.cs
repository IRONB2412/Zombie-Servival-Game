using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackOnPlayerAEScript : MonoBehaviour
{
    public GameObject RightFist;
    public GameObject LeftFist;
    

   

    public void ActiveatRightFist()
    {
        RightFist.GetComponent<SphereCollider>().enabled = true;
    }
    public void DiactivetRightFist()
    {
        RightFist.GetComponent<SphereCollider>().enabled = false;
    }
    public void ActiveatLeftFist()
    {
        LeftFist.GetComponent<SphereCollider>().enabled = true;
    }
    public void DiactiveatLeftFist()
    {
        LeftFist.GetComponent<SphereCollider>().enabled = false;
    }
   
}
