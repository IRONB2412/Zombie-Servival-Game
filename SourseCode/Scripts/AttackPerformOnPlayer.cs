using System.Collections;

using UnityEngine;


public class AttackPerformOnPlayer : MonoBehaviour
{
    public int ZombieDameg = 2;
    public GameObject BloodDamageAinmetion;
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.name == "FpsPlayer")
        {
           
            PlayerHealth player=other.GetComponent<PlayerHealth>();
            
            
                player.PlayerHealthDown(ZombieDameg);
            StartCoroutine(DamageAnimetionPlay());
           
            
        }
    }
    IEnumerator DamageAnimetionPlay()
    {
        BloodDamageAinmetion.SetActive(true);
        BloodDamageAinmetion.GetComponent<Animation>().Play("BloodDamege");
        yield return new WaitForSeconds(0.20f);
        BloodDamageAinmetion.SetActive(false);

    }
}
