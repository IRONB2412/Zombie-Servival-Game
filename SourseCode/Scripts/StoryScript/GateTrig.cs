using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GateTrig : MonoBehaviour
{
    [SerializeField] private GameObject MassegText;
    [SerializeField] private GameObject LeftGate;
    [SerializeField] private GameObject RightGate;
    IEnumerator OnTriggerEnter(Collider other)
    {
        if (other.gameObject.name == "FpsPlayer")
        {
            MassegText.SetActive(true);
            MassegText.GetComponent<Text>().text = "There is someone i need to be careful";

            LeftGate.GetComponent<Animation>().Play();
            RightGate.GetComponent<Animation>().Play();
            yield return new WaitForSeconds(5f);
            MassegText.SetActive(false);
            Destroy(gameObject);
            
        }
    }
   

}
