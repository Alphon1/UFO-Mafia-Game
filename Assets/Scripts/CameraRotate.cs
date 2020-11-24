using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraRotate : MonoBehaviour
{
    public Camera Player_cam;
    private float x;
    private float y;
    private Vector3 rotateValue;
    public void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        y = Input.GetAxis("Mouse X");
        x = Input.GetAxis("Mouse Y");
        rotateValue = new Vector3(x, y * -1, 0);
        Player_cam.transform.eulerAngles = transform.eulerAngles - rotateValue;
    }
}
