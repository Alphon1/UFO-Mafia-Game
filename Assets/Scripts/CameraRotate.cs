using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CameraRotate : MonoBehaviour
{
    public Camera Player_cam;
    private float x;
    private float y;
    private Vector3 rotateValue;
    private PauseMenu pauseMenu;
    public void Start()
    {
        pauseMenu = FindObjectOfType<PauseMenu>();



    }

    // Update is called once per frame
    void Update()
    {
        if (pauseMenu.isPaused == true)
        {
            Time.timeScale = 0f;
        }
        else
        {
            Cursor.visible = true;
        y = Input.GetAxis("Mouse X");
        x = Input.GetAxis("Mouse Y");
        rotateValue = new Vector3(x, y * -1, 0);
        Player_cam.transform.eulerAngles = transform.eulerAngles - rotateValue;
        }
        
       
        
    }
}
