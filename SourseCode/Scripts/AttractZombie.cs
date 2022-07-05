using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttractZombie : MonoBehaviour
{
   [SerializeField] private FpsMovement FpsScript;
    public SphereCollider AttractColider;
    void Start()
    {
        
    }

   
    void Update()
    {
        if(FpsScript.isGrounded==true && FpsScript.isWalking==true)
        {
            AttractColider.radius = 3;
        }else
        if(FpsScript.isGrounded==true && FpsScript.isRuning==true)
        {
            AttractColider.radius = 5;
        }else
        {
            AttractColider.radius = 1;
        }
       
        
    }
    private void OnTriggerEnter(Collider other)
    { 
        switch(other.gameObject.tag)
        {
            case "Zombie":
                other.gameObject.GetComponent<ZombieAi>().OnAwear();
                break;
            case "Zombie1":
                other.gameObject.GetComponent<Zombie1Ai>().OnAwear();
                break;
            case "Zombie2":
                other.gameObject.GetComponent<Zombie2Ai>().OnAwear();
                break;
                default:
                break;
        }
    }
}
