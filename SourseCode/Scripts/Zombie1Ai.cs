using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Zombie1Ai : MonoBehaviour
{
    [SerializeField] public GameObject FpsPlayer;
    public NavMeshAgent Zombie;
    public float ViweDistance=10;
    public int ViweAngle=100;
    public bool isAwear=false;
    public Animator ZombiAnimator;
   [SerializeField] public FpsMovement FpsScript;
    private float Zlook;
    public bool JumpAnim;
   
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
            
        }else
        {
            searchForPlayer();
        }
    
    }
    

    IEnumerator ComingtoYou()
    {
        if( isAwear)
       {
            transform.LookAt(FpsPlayer.transform.position);
            yield return new WaitForSeconds(0.5f);
            ZombiAnimator.SetBool("IsSwa", true);
            yield return new WaitForSeconds(2f);
            Zombie.SetDestination(FpsPlayer.transform.position);
            ZombiAnimator.SetBool("IsWalk",true);

            if (Zombie.remainingDistance <= 4f && Zombie.remainingDistance >= 3.5f)
            {
                JumpAnim=true;
                transform.LookAt(FpsPlayer.transform.position);
                ZombiAnimator.SetBool("NearByPlayer", true);
                
                JumpAnim=false;
            }
            else
            if (Zombie.remainingDistance >= 4.1f)
            {

                ZombiAnimator.SetBool("NearByPlayer", false);
                ZombiAnimator.SetBool("FrontOfPlayer", false);
                ZombiAnimator.SetBool("IsWalk", true);

            }
            else
                if (Zombie.remainingDistance <= 1.5f)
            {
                
                ZombiAnimator.SetBool("FrontOfPlayer", true);
                ZombiAnimator.SetBool("NearByPlayer", false);
                
                ZombiAnimator.SetBool("IsWalk", false);
            }
            
            

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
