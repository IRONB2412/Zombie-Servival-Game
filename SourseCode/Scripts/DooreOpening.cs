
using UnityEngine;
using UnityEngine.UI;

public class DooreOpening : MonoBehaviour
{
    public float TheDistance;
    public GameObject ActionDisplay;
    public GameObject Actiontext;
    public GameObject DoorHing;

    

    // Update is called once per frame
    void FixedUpdate()
    {
        TheDistance = PlayerCasting.DistanceFromPlayer;
    }
    private void OnMouseOver()
    {
        if(TheDistance<=3f)
        {
            ActionDisplay.SetActive(true);
            Actiontext.SetActive(true);
            Actiontext.GetComponent<Text>().text = "Open The Door";
           
        }else
        {
            ActionDisplay.SetActive(false);
            Actiontext.SetActive(false);
        }
        if(Input.GetKeyDown(KeyCode.E))
        {
           if (TheDistance <= 3f)
            {
                ActionDisplay.SetActive(false);
                Actiontext.SetActive(false);
                DoorHing.GetComponent<Animation>().Play("openDoor");

            }
        }
    }
    private void OnMouseExit()
    {
        ActionDisplay.SetActive(false);
        Actiontext.SetActive(false);
    }
    
} 
