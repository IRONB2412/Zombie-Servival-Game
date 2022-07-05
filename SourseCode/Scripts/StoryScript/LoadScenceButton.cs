using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;


public class LoadScenceButton : MonoBehaviour
{
   
    
    public GameObject ScenceLoadeImg;
    public Image FillBar;
    public int sceneId;
    public float Chake;
    public float Progress;
    public GameObject MainMenu;
    public GameObject  Canvas1,Canvas2, ObjectivePanle;
    



    public void Button(int sceneID)
    {
       
        {
           
            StartCoroutine(LoadAscyncManager(sceneId));
        }
        
    }
    IEnumerator LoadAscyncManager(int sceneID)
    {
        MainMenu.SetActive(false);
        ObjectivePanle.SetActive(false);
         ScenceLoadeImg.gameObject.SetActive(true);
        Canvas1.SetActive(false);
        Canvas2.SetActive(false);
        
        AsyncOperation Opretion = SceneManager.LoadSceneAsync(sceneId);
         while (!Opretion.isDone)
        {

            Progress = Mathf.Clamp((float)Opretion.progress/0.9f, 0f, 1f);
 
            FillBar.fillAmount = Progress;
            
            yield return null;
            

        }

       
    }
}
