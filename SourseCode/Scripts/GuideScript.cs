using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GuideScript : MonoBehaviour
{
    public GameObject FpsPlayer;
    public GameObject MessageTxt;
    public Button SkipButton;
    public GameObject ObjectiveController;

    private void Update()
    {
        if(this.gameObject.activeSelf)
        {
            Cursor.lockState = CursorLockMode.Confined;
        }
    }
    private void Awake()
    {
        StartCoroutine(Guide());
    }
    IEnumerator Guide()
    {
        
        SkipButton.gameObject.SetActive(true);
        Cursor.lockState = CursorLockMode.Confined;
        MessageTxt.SetActive(true);
        MessageTxt.GetComponent<Text>().color = Color.red;
        MessageTxt.GetComponent<Text>().text = "Move Mouse To Look Around & Aim";
        yield return new WaitForSeconds(1f);
        FpsPlayer.GetComponent<FpsMovement>().enabled = false;
        yield return new WaitForSeconds(5f);
        MessageTxt.GetComponent<Text>().text = null;
        yield return new WaitForSeconds(1f);
        MessageTxt.GetComponent<Text>().text = "Use [W] & [S] To Move Forward & Backward";
        yield return new WaitForSeconds(4f);
        MessageTxt.GetComponent<Text>().text = "Use [A] & [D] To Move Left & Right";
        yield return new WaitForSeconds(4f);
        MessageTxt.GetComponent<Text>().text = null;
        yield return new WaitForSeconds(1f);
        MessageTxt.GetComponent<Text>().text = "Press Mouse Lef Button To Fire";
        yield return new WaitForSeconds(4f);
        MessageTxt.GetComponent<Text>().text = "Let's Go";
        yield return new WaitForSeconds(2f);
        FpsPlayer.GetComponent<FpsMovement>().enabled = true;
        MessageTxt.GetComponent<Text>().text = null;
        MessageTxt.GetComponent<Text>().color = Color.white;
        MessageTxt.SetActive(false);
        SkipButton.gameObject.SetActive(false);
        ObjectiveController.gameObject.SetActive(true);
        this.gameObject.SetActive(false);
        Cursor.lockState = CursorLockMode.Locked;

    }
    public void Skip()
    {
        FpsPlayer.GetComponent<FpsMovement>().enabled = true;
        MessageTxt.GetComponent<Text>().text = null;
        MessageTxt.GetComponent<Text>().color = Color.white;
        MessageTxt.SetActive(false);
        SkipButton.gameObject.SetActive(false);
        ObjectiveController.gameObject.SetActive(true);
        this.gameObject.SetActive(false);
        Cursor.lockState= CursorLockMode.Locked;
        return;
    }
   
    
}
