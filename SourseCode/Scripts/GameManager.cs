using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public GameObject PusePanel;
    public GameObject Canvas1;
    public GameObject Canvas2;
    bool GameisPused;

    public GameObject ScenceLoadeImg;
    public Image FillBar;
    public float Chake;
    public float Progress;
    public GameObject mainmenu;

    public GameObject WarningPanle, SettingsPanle, SoundSettingsPanle, MouseSettingsPanle;


    private void Update()
    {
        if (WarningPanle.gameObject.activeSelf == false &&!(SceneManager.GetActiveScene().buildIndex==0))
        {
            if (Input.GetKeyDown(KeyCode.Escape) && SettingsPanle.activeSelf == false)
            {
                if (!GameisPused)
                {
                    Puse();
                }
                else
                {
                    Resume();
                }
            }
        }
       
    }

    public void Puse()
    {
        Time.timeScale = 0;

        GameisPused = true;
        PusePanel.SetActive(true);
        Canvas1.SetActive(false);
        Canvas2.SetActive(false);
        Cursor.lockState = CursorLockMode.Confined;

    }
    public void Resume()
    {
        Time.timeScale = 1;
        GameisPused = false;
        PusePanel.SetActive(false);
        Canvas1.SetActive(true);
        Canvas2.SetActive(true);
        Cursor.lockState = CursorLockMode.Locked;
    }
    public void Quit()
    {
        Application.Quit();
    }
    public void MainMenu()
    {
        WarningPanle.gameObject.SetActive(true);
    }
    public void yes(int sceneID)
    {
        
        StartCoroutine(LoadAscyncManager(sceneID));

    }
    IEnumerator LoadAscyncManager(int sceneID)
    {
        ScenceLoadeImg.gameObject.SetActive(true);
        AsyncOperation Opretion = SceneManager.LoadSceneAsync(sceneID);
        while (!Opretion.isDone)
        {
            Progress = Mathf.Clamp(Opretion.progress, 0f, 100f);
            Progress = Progress / 100f;
            FillBar.fillAmount = Progress;

            yield return null;
        }
    }
    public void No()
    {
        WarningPanle.gameObject.SetActive(false);
    }
    public void SettingsClick()
    {
        SettingsPanle.gameObject.SetActive(true);
        mainmenu.SetActive(false);
        
    }
    public void BackFromSettings()
    {
        SettingsPanle.SetActive(false);
        mainmenu.SetActive(true);
    }
    public void SoundSettingsButton()
    {
        MouseSettingsPanle.gameObject.SetActive(false);
        SoundSettingsPanle.gameObject.SetActive(true);
    }
    public void MouseSettingsButton()
    {
        SoundSettingsPanle.gameObject.SetActive(false);
        MouseSettingsPanle.gameObject.SetActive(true);
    }
    public void RestartGameLvl()
    {
        
        int CureentScence = SceneManager.GetActiveScene().buildIndex;
        StartCoroutine(LoadAscyncManager(CureentScence));
    }
}
