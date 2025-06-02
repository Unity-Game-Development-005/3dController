
using UnityEngine;


public class CameraController : MonoBehaviour
{
    // how quickly the camera is moves to a new position
    private float mouseSensitivity = 150f;



    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        // hide cursor
        Cursor.visible = false;

        // lock mouse to screen bounds
        Cursor.lockState = CursorLockMode.Locked;
    }

    // Update is called once per frame
    void Update()
    {
        float mouseX = Input.GetAxis("Mouse X");

        //float mouseY = Input.GetAxis("Mouse Y");

        transform.Rotate(mouseSensitivity * mouseX * Time.deltaTime * Vector3.up);

        //transform.Rotate(mouseSensitivity * mouseY * Time.deltaTime * Vector3.left);
    }


} // end of class
