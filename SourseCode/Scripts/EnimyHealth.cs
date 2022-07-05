using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnimyHealth : MonoBehaviour
{
    public int health=20;
    public Animator ZombiAnimator;
    public NavMeshAgent NavmashAgent;
    public ZombieAi ZommbieAiScript; 
    
    public Zombie1Ai Zommbie1AiScript;
    public Zombie2Ai Zommbie2AiScript;
    public ZombieSpown[] zombieSpown;
    public KillCount KillCountScript;
    public GunRaycast PistolGunScript;
    public ArGunRaycast ArGunScript;




    public void DamageZombie(int DamageValue)
    {
        health-=DamageValue;

        if(health<=0)
        { 
            this.GetComponent<CapsuleCollider>().enabled = false;
            Die();
            AmmoDrop();
            KillCountScript.GetKill(1);
           
        }
    }
   
    public void Die()
    {
        int S=Random.Range(0,zombieSpown.Length);
        StartCoroutine(playDeadAnimetion());
        zombieSpown[S].n--;
        zombieSpown[S].Chaken();
    }
    IEnumerator playDeadAnimetion()
    {
        if (this.gameObject.tag == "Zombie")
        {
            
            
            ZombiAnimator.SetBool("IsDead", true);
            ZombiAnimator.SetBool("IsRuning", false);
            ZombiAnimator.SetBool("IsWalking", false);
            ZombiAnimator.SetBool("IsComing", false);
            ZombiAnimator.SetBool("IsAttacking", false);
            ZommbieAiScript.enabled = false;
           
            yield return new WaitForSeconds(4f);
            Destroy(gameObject);
           
        }
        else
            if (this.gameObject.tag == "Zombie2")
        {
           
           
            ZombiAnimator.SetBool("Z2IsDead", true);
            ZombiAnimator.SetBool("Z2IsWalking", false);
            ZombiAnimator.SetBool("Z2IsAttacking", false);
            Zommbie2AiScript.enabled = false;
      
            yield return new WaitForSeconds(4f);
            Destroy(gameObject);
            
        }
        else
            if(this.gameObject.tag =="Zombie1")
        {
            
           
            
            ZombiAnimator.SetBool("NearByPlayer", false);
            ZombiAnimator.SetBool("FrontOfPlayer", false);
            ZombiAnimator.SetBool("IsWalk", false);
            ZombiAnimator.SetBool("IsDead", true);
            Zommbie1AiScript.enabled = false;
            
            yield return new WaitForSeconds(4f);
            Destroy(gameObject);
            
        }
       
    }
    public void AmmoDrop()
    {
        int R = Random.Range(0, 3);
        ArGunScript.CurrentStokBullet += R;
        PistolGunScript.CurrentStokBullet += R;
    }
    
            


}
