using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cameracontroller : MonoBehaviour
{
    public Transform cameraTransform;

    public float NormalSpeed;
    public float FastSpeed;
    public float MovementSpeed;
    public float MovementTime;
    public float RotationAmount;
    public Vector3 ZommInAmount;

    public Vector3 newPosition;
    public Quaternion newRotation;
    public Vector3 newZoom;

    public Vector3 rotateStartPosition;
    public Vector3 rotateCurrentPosition;

    public Transform playerCam;

    // Start is called before the first frame update
    void Start()
    {
    
        newPosition = transform.position;
        newRotation = transform.rotation;
        newZoom = cameraTransform.localPosition;
        
    }

    // Update is called once per frame
    void Update()
    {

        HandleMovemntInput();
        HandleMouseInput();
        
        
        

    }

    void HandleMouseInput()
    {
        if(Input.mouseScrollDelta.y != 0)
        {
            newZoom += Input.mouseScrollDelta.y * ZommInAmount;
        }

        if (Input.GetMouseButtonDown(2))
        {
            rotateStartPosition = Input.mousePosition;
        }
        if (Input.GetMouseButton(2))
        {
            rotateCurrentPosition = Input.mousePosition;
            Vector3 difference = rotateStartPosition - rotateCurrentPosition;
            rotateStartPosition = rotateCurrentPosition;
            newRotation *= Quaternion.Euler(Vector3.up * (-difference.x / 5f));
        }
    }
       void HandleMovemntInput()
    {
        if (Input.GetKey(KeyCode.LeftShift))
        {
            MovementSpeed = FastSpeed;
        }
        else
        {
            MovementSpeed = NormalSpeed;
        }

        if(Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.UpArrow))
        {
            newPosition += (transform.forward * MovementSpeed);
        }
        if (Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.DownArrow))
        {
            newPosition += (transform.forward * -MovementSpeed);
        }
        if (Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.RightArrow))
        {
            newPosition += (transform.right * MovementSpeed);
        }
        if (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.LeftArrow))
        {
            newPosition += (transform.right * -MovementSpeed);
        }

        if (Input.GetKey(KeyCode.E))
        {
            newRotation *= Quaternion.Euler(Vector3.up * RotationAmount);
        }
        if (Input.GetKey(KeyCode.Q))
        {
            newRotation *= Quaternion.Euler(Vector3.up * -RotationAmount);
        }
        if(Input.GetKey(KeyCode.R))
        {
            newZoom += ZommInAmount;
        }
        if (Input.GetKey(KeyCode.F))
        {
            newZoom -= ZommInAmount;
        }
        transform.position = Vector3.Lerp(transform.position, newPosition, Time.deltaTime * MovementTime);
        transform.rotation = Quaternion.Lerp(transform.rotation, newRotation, Time.deltaTime * MovementTime);
        cameraTransform.localPosition = Vector3.Lerp(cameraTransform.localPosition, newZoom, Time.deltaTime * MovementTime);
        }
    


}
