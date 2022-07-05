using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraLook : MonoBehaviour
{
    public Transform player;
    public static float mouseSensitivity;
    float xRotation = 0f;
   
    void Start()
    {
        
       /* Cursor.lockState = CursorLockMode.Locked;*/
        
    }


    void FixedUpdate()
    {
        float mousex = Input.GetAxis("Mouse X") * mouseSensitivity * Time.deltaTime;
        float mousey = Input.GetAxis("Mouse Y") * mouseSensitivity * Time.deltaTime;
        xRotation -= mousey;
        xRotation = Mathf.Clamp(xRotation, -60f, 48f);
        transform.localRotation = Quaternion.Euler(xRotation, 0f, 0f);


        player.Rotate(Vector3.up * mousex);
    }
}
