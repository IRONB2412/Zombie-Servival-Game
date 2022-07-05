using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;


public class LoadScence : MonoBehaviour
{
    [SerializeField]public int RequiredKills;
    [SerializeField] KillCount KillCountScript;
    public GameObject ScenceLoadeImg;
    public Image FillBar;
    public int sceneId;
    public float Chake;
    public float Progress;
    public GameObject Canvas1,Canvas2,ObjectivePanle;


    

    private void OnTriggerEnter(Collider other)
    {
        if(KillCountScript.CurrentKill>=RequiredKills && other.gameObject.tag=="Player")
        {
           
            StartCoroutine(LoadAscyncManager(sceneId));
        }
        
    }
    IEnumerator LoadAscyncManager(int sceneID)
    {
        
        ScenceLoadeImg.gameObject.SetActive(true);
        ObjectivePanle.SetActive(false);
        Canvas1.gameObject.SetActive(false);
        Canvas2.gameObject.SetActive(false);
        yield return new WaitForSeconds(2f);
        AsyncOperation Opretion = SceneManager.LoadSceneAsync(sceneId);
         while (!Opretion.isDone)
        {
            Progress = Mathf.Clamp((float)Opretion.progress/0.9f, 0f, 1f);
           FillBar.fillAmount = Progress;
            yield return null;

        }
    }
    
}
