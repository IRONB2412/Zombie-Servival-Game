
using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;


public class PickUpGuns : MonoBehaviour
{
    public GameObject ActionKeyDisplay;
    public GameObject ActionText;
    public GameObject FakeGun;
    public GameObject Gun;
    public float DistanceFrom;
    public GameObject FpsCam;
    public bool IsHoldingGun = false;
    [SerializeField] private GameObject PistolGun;
    [SerializeField] private GameObject ArGun;
    public GunRaycast PistolGunScript;
    public ArGunRaycast ArGunScript;
    public GameObject ArHolder;
    public GameObject PistolHolder;
    public GameObject ShowGun;
    [System.Obsolete]



    void Start()
    {
        if (PistolGun.active == true)
        {
            IsHoldingGun=true;
            ArGun.SetActive(false);
            

        }
        else
           if (ArGun.active == true)
        {
            IsHoldingGun=(true);
            PistolGun.SetActive(false);
            
        }
    }
    [System.Obsolete]
    void Update()
    {
        DistanceFrom = PlayerCasting.DistanceFromPlayer;
       if(ArGun.transform.parent==ArHolder)
        {
            ArGun.SetActive(true);
        }
        if(PistolGun.transform.parent==PistolHolder)
        {
            PistolGun.SetActive(true) ;
        }

    }
    [System.Obsolete]
    private void OnMouseOver()
    {
        if(DistanceFrom<=3f)
        {
            ActionKeyDisplay.SetActive(true);
            ActionText.SetActive(true);
            ActionText.GetComponent<Text>().text = "Pick Up Gun";
            
        }else
        {
            ActionKeyDisplay.SetActive(false);
            ActionText.SetActive(false);
        }
        
        if(!IsHoldingGun && Input.GetKeyDown(KeyCode.E)&& (!Gun.transform.parent == ArHolder.transform || PistolHolder.transform))
        {
            
            PickUp();
        }
        else
        if( (Gun.transform.parent==ArHolder.transform || PistolHolder.transform) && IsHoldingGun && Input.GetKeyDown(KeyCode.E)) 
        {
            
            GunManager();
        }
       
    }
    [System.Obsolete]
    private void PickUp()
    { 
        if(DistanceFrom<=3f)
        {
            FakeGun.SetActive(false);
            FirstTimePick();
            Gun.SetActive(true);
            IsHoldingGun = true;     
            this.GetComponent<BoxCollider>().enabled = false;           
            ActionKeyDisplay.SetActive(false);           
            ActionText.SetActive(false);

        }
           
    }
    [System.Obsolete]
    private void GunManager()
    {
        FirstTimePick();
        FakeGun.SetActive(false);
        IsHoldingGun = true;
        this.GetComponent<BoxCollider>().enabled = false;
        ActionKeyDisplay.SetActive(false);
        ActionText.SetActive(false);
        if(FakeGun.tag=="Pistol")
        {
            PistolGunScript.CurrentStokBullet += 15;
        }
        else
        if(FakeGun.tag=="ArGun")
        {
            ArGunScript.CurrentStokBullet += 30;
        }
    }
    [System.Obsolete]
    private void FirstTimePick()
    {
        if (!ArGun.transform.parent == ArHolder.transform && Gun.tag == "ActualAr")

        {

            ArGun.SetActive(true);
            ArGun.transform.SetParent(ArHolder.transform);
            ArGun.transform.localPosition=new Vector3(0,0,0);
            ArGun.transform.localRotation=Quaternion.identity;
            if(ShowGun.gameObject.active==false)
            {
                ShowGun.gameObject.SetActive(true);
            }
           
        }
        else
        if (!PistolGun.transform.parent == PistolHolder.transform && Gun.tag == "ActualPistol")

        {
            PistolGun.SetActive(true);
            PistolGun.transform.SetParent(PistolHolder.transform);
            PistolGun.transform.localPosition = Vector3.zero;
            PistolGun.transform.localRotation=Quaternion.identity;
            if (ShowGun.gameObject.active == false)
            {
                ShowGun.gameObject.SetActive(true);
            }

        }

    }
   
    private void OnMouseExit()
    {
        ActionKeyDisplay.SetActive(false);
        ActionText.SetActive(false);
        IsHoldingGun=false;
    }
}
