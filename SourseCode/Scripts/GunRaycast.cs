using System.Collections;
using TMPro;
using UnityEngine;

public class GunRaycast : MonoBehaviour
{
    public float TargetDistance;
    public int DamageValue;
    public AudioSource GunShot;
    public float NextTimeOfFire;
    public bool CanFire=true;
    public int gunBullets = 15;
    public int usedBullet;
    public int CurrentGunBullets;
    [SerializeField]public int CurrentStokBullet;

    public Animation MuzzelFlash;
    public GameObject MuzzelPlean;
    public GameObject FpsCamera;
    public bool IsReloding;
    public GameObject[] HitPartical;
    public TextMeshProUGUI GunType;
    public TextMeshProUGUI GunInfo;

    

    private void Start()
    {
        CurrentGunBullets = gunBullets;
        CurrentStokBullet = 30;
        
    }
    private void Update()
    {
        
        if (IsReloding == true && CanFire == true && CurrentGunBullets <= 0)
        {
            StartCoroutine(Reload());
        }
        if (CurrentGunBullets <= 0)
        {
            StartCoroutine(Reload());
        }
        GunType.text = "Pistol";
        GunInfo.text = this.CurrentGunBullets + "/" + this.CurrentStokBullet;
    }


    void FixedUpdate()
    {
        
        if(IsReloding)
        {
            return;
        }
        if(Input.GetKeyDown(KeyCode.R))
        {
            CanFire = false;
            StartCoroutine(Reload());
        }

        if (CurrentGunBullets >= 1)
        {
            if (Input.GetButtonDown("Fire1") && CanFire == true && !IsReloding)
            {

                CurrentGunBullets--;
                CanFire = false;
                GunShot.GetComponent<AudioSource>().Play();
                Shoots();
                StartCoroutine(WaitForFire());
            }
        }
        else
        {
            StartCoroutine(Reload());
        }
        
        
    }
   
  void Shoots()
  {
    RaycastHit Shoot;

    if (Physics.Raycast(FpsCamera.transform.position, FpsCamera.transform.TransformDirection(Vector3.forward), out Shoot))
    {
            switch (Shoot.collider.tag)
            {
                case "Ground":
                    Instantiate(HitPartical[0], Shoot.point, Quaternion.LookRotation(Shoot.normal));
                    break;
                case "Wall":
                    Instantiate(HitPartical[1], Shoot.point, Quaternion.LookRotation(Shoot.normal));
                    break;
                case "GrassGround":
                    Instantiate(HitPartical[1], Shoot.point, Quaternion.LookRotation(Shoot.normal));
                    break;
                case "TypeDoor":
                    Instantiate(HitPartical[2], Shoot.point, Quaternion.LookRotation(Shoot.normal));
                    break;
                case "Zombie":
                    Instantiate(HitPartical[3], Shoot.point, Quaternion.LookRotation(Shoot.normal));
                    break;
                case "Zombie1":
                    Instantiate(HitPartical[3], Shoot.point, Quaternion.LookRotation(Shoot.normal));
                    break;
                case "Zombie2":
                    Instantiate(HitPartical[3], Shoot.point, Quaternion.LookRotation(Shoot.normal));
                    break;

            }
            
            EnimyHealth Enimy = Shoot.transform.GetComponent<EnimyHealth>();
            
      if (Enimy != null)
      {
                Enimy.DamageZombie(DamageValue);
              
      }
    }
  }
    IEnumerator WaitForFire()
    {
        
        MuzzelPlean.SetActive(true);
        
        MuzzelFlash.GetComponent<Animation>().Play();
        yield return new WaitForSeconds(0.2f);
        MuzzelPlean.SetActive(false);
        yield return new WaitForSeconds(NextTimeOfFire);
        CanFire = true;
    }
    IEnumerator Reload()
    { 
        CanFire= false;
        IsReloding=true;
        yield return new WaitForSeconds(3);
        if (CurrentStokBullet >= gunBullets)
        {
            usedBullet = gunBullets - CurrentGunBullets;
            CurrentGunBullets += usedBullet;
            CurrentStokBullet -= usedBullet;
        }
        if (CurrentStokBullet < gunBullets)
        {
            if(CurrentGunBullets+CurrentStokBullet>gunBullets)
            {
                usedBullet = gunBullets - CurrentGunBullets;
                CurrentGunBullets += usedBullet;
                CurrentStokBullet -= usedBullet;
            }
            if(CurrentGunBullets+CurrentStokBullet<gunBullets)
            {
                CurrentGunBullets = CurrentGunBullets + CurrentStokBullet;
                CurrentStokBullet -= CurrentStokBullet;
            }
            
        }
        IsReloding= false;
        CanFire = true;
        
    }
    private void OnDisable()
    {
        GunType.text = null;
        GunInfo.text = null;
    }
}