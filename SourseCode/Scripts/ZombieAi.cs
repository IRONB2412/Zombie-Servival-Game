using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class ZombieAi : MonoBehaviour
{
    [SerializeField] public GameObject FpsPlayer;
    public NavMeshAgent Zombie;
    public float ViweDistance=10;
    public int ViweAngle=100;
    public bool isAwear=false;
    public Animator ZombiAnimator;
   [SerializeField] public FpsMovement FpsScript;
    private float Zlook;
    
    
 

    void Start()
    {
        Zombie = GetComponent<NavMeshAgent>();
        FpsScript = FpsPlayer.GetComponent<FpsMovement>();
       Zlook= Random.Range(0f, 360f);
        this.transform.Rotate(new Vector3(0f, Zlook, 0f));
    }
 
    void Update()
    {
        
       
        if (isAwear)
        {
           transform.LookAt(transform.position);
           StartCoroutine(ComingtoYou());
            Zombie.SetDestination(FpsPlayer.transform.position);
           
           


            if (Zombie.remainingDistance<=1.5f)
            {
                transform.LookAt(FpsPlayer.transform.position);
            ZombiAnimator.SetBool("IsAttacking", true);
                

            }else
            {
            ZombiAnimator.SetBool("IsAttacking", false);
            }
            
            
        }else
        {
            searchForPlayer();
        }
    
    }
    

    IEnumerator ComingtoYou()
    {
        if( isAwear)
       {
          
            Zombie.GetComponent<NavMeshAgent>().speed = 1f;
            ZombiAnimator.SetBool("IsRuning", false);
            ZombiAnimator.SetBool("IsWalking",true);
            ZombiAnimator.SetBool("IsComing",true) ;
            yield return null;
        }

    }

    void searchForPlayer()
    {
        if(isAwear)
        {
            return;
        }
        if (Vector3.Angle(Vector3.forward, Zombie.transform.InverseTransformPoint(FpsPlayer.transform.position)) < ViweAngle / 2f)
        {
            if (Vector3.Distance(Zombie.transform.position, FpsPlayer.transform.position) < ViweDistance) 
            {
                OnAwear();
            }
        }
    }
 
   public void  OnAwear()
    {
        
        Zombie.GetComponent<NavMeshAgent>().speed = 1f;
        isAwear = true;
        
    }
    

}
