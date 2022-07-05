using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AmmoScript : MonoBehaviour
{
    public GameObject ActionKeyDisplay;
    public GameObject ActionText;
    public float DistanceFrom;
    public ArGunRaycast ArGunScript;
    public GunRaycast PistolGunScript;
    private void Update()
    {
        DistanceFrom = PlayerCasting.DistanceFromPlayer;
    }
    private void OnMouseOver()
    {
        if (DistanceFrom <= 3f)
        {
            ActionKeyDisplay.SetActive(true);
            ActionText.SetActive(true);
            ActionText.GetComponent<Text>().text = "Pick Up Gun Ammo";
            if(Input.GetKeyDown(KeyCode.E))
            {
            Pick();
            }

        }
        else
        {
            ActionKeyDisplay.SetActive(false);
            ActionText.SetActive(false);
        }
        
       
    }
    public void Pick()
    {
        ArGunScript.CurrentStokBullet += 30;
        PistolGunScript.CurrentStokBullet += 30;
        ActionKeyDisplay.SetActive(false);
        ActionText.SetActive(false);
        Destroy(gameObject);

    }
    private void OnMouseExit()
    {
        ActionKeyDisplay.SetActive(false);
        ActionText.SetActive(false);
    }
}
