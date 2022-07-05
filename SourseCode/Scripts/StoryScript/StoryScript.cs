
using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class StoryScript : MonoBehaviour
{
    [SerializeField] private GameObject MassegText;

    IEnumerator OnTriggerEnter(Collider other)
    {
        if (other.gameObject.name == "FpsPlayer")
        {
            MassegText.SetActive(true);
            MassegText.GetComponent<Text>().text = "Pick Up The Gun From Table";
            yield return new WaitForSeconds(5f);
        }
    }
    IEnumerator OnTriggerExit(Collider other)
    {
        if (other.gameObject.name == "FpsPlayer")
        {
            yield return new WaitForSeconds(5f);
            MassegText.GetComponent<Text>().text = null;
            MassegText.SetActive(false);
            Destroy(gameObject);
        }
    }
}
