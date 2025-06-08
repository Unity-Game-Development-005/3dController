
using UnityEngine;


public class CameraController : MonoBehaviour
{
    // how quickly the camera orbits around the player
    private float rotationSensitivity = 150f;


    // for player input
    private float horizontalInput;



    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        // hide cursor
        ///Cursor.visible = false;

        // lock mouse to screen bounds
        ///Cursor.lockState = CursorLockMode.Locked;
    }


    // Update is called once per frame
    void Update()
    {
        GetPlayerInput();

        OrbitCamera();
    }


    private void GetPlayerInput()
    {
        ///float mouseX = Input.GetAxis("Mouse X");
        horizontalInput = Input.GetAxis("Camera Orbit");
    }


    private void OrbitCamera()
    {
        ///transform.Rotate(mouseSensitivity * mouseX * Time.deltaTime * Vector3.up);
        transform.Rotate(rotationSensitivity * horizontalInput * Time.deltaTime * Vector3.up);
    }


} // end of class
