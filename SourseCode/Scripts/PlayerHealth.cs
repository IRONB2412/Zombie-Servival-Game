using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

[ExecuteInEditMode()]
public class PlayerHealth : MonoBehaviour
{
    public float healthBarValue;
    public Image HealthBar;
    public float PlayerLife = 20;
    private float Currethealth;
    public GameObject AfterDead;
    public GameObject Canvas1;
    public GameObject Canvas2;
    
    private void Awake()
    {
        Currethealth = PlayerLife;
    }
    public void PlayerHealthDown(int ZombieDameg)
    {
       Currethealth -= ZombieDameg;
    }

    private void Update()
    {
        healthBarValue = Currethealth / PlayerLife;
        Currethealth=Mathf.Clamp(Currethealth, 0,PlayerLife);
        HealthBar.fillAmount=healthBarValue;
        if (Currethealth <= 0)
        {
            PlayerDie();
        }
    }
    public void PlayerDie()
    {
        Time.timeScale = 0;
        AfterDead.gameObject.SetActive(true);
        Canvas1.SetActive(false);
        Canvas2.SetActive(false);
       
        Cursor.lockState = CursorLockMode.Confined;
    }
}
