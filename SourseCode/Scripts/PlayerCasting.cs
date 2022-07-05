using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerCasting : MonoBehaviour
{
    public static float DistanceFromPlayer;
    public float ToDistance;
    public MouseSettings mouseSettings;
    public SoundSettings soundSettings;
    public GameObject Canvas1,Canvas2,ScenceLoadeImg,HealthBars,CrossHair,Guide,Kills;

    
    private void Awake()
    {
        Canvas1.gameObject.SetActive(true);
        Canvas2.gameObject.SetActive(true);
        Kills.gameObject.SetActive(true);
        CrossHair.gameObject.SetActive(true);
        HealthBars.gameObject.SetActive(true);
        ScenceLoadeImg.gameObject.SetActive(false);
        Time.timeScale = 1;
        mouseSettings.Start();
        soundSettings.Start();
        if(SceneManager.GetActiveScene()==SceneManager.GetSceneByBuildIndex(2))
        {
            Guide.SetActive(true);
        }
    }


    // Update is called once per frame
    void Update()
    {
        RaycastHit hit;
        if (Physics.Raycast(transform.position, transform.forward, out hit))
        {
            ToDistance = hit.distance;
            DistanceFromPlayer = ToDistance;

        }
    }
}
