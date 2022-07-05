using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryControl : MonoBehaviour
{


    public GameObject[] Guns;
    public int SelectedWepon=0;
     
    void Start()
    {

        SelectWepon();
    }

    
    void Update()
    {
        if (Input.GetAxis("Mouse ScrollWheel") > 0f)
        {

           if (SelectedWepon >= 1)
            {
                SelectedWepon = 0;
            }
            else
            {
                SelectedWepon++;
            }
        }
        if (Input.GetAxis("Mouse ScrollWheel") < 0f)
        {
            if (SelectedWepon <= 0) 
            {
                SelectedWepon = transform.childCount - 1;
            }
            else
            {
                SelectedWepon--;
            }
        }
        SelectWepon();

    }
    void SelectWepon()
    {
        int i = 0;
        
        foreach(GameObject Wepons in Guns)
        {
            if(i==SelectedWepon)
            {
               Wepons.gameObject.SetActive(true);
            }
            else
            {
                Wepons.gameObject.SetActive(false);
            }
            i++;
        }
        
    }
}
