
using UnityEngine;


public class PlayerController : MonoBehaviour
{
    // get a reference to the camera focal point transform
    public Transform focalPoint;


    // get a reference ro the player's rigidbody component
    private Rigidbody playerRb;

    // player's movement speed
    public float playerSpeed = 5f;



    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        // set reference to the player's rigidbody component
        playerRb = GetComponent<Rigidbody>();
    }


    // Update is called once per frame
    void Update()
    {
        // player's forward and backward input
        float verticalInput = Input.GetAxis("Vertical");

        // player's left and right input
        float horizontalInput = Input.GetAxis("Horizontal");

        // calulate a position to move the player to based on their input and normalise the value
        Vector2 movement = new Vector2(horizontalInput, verticalInput).normalized;

        // move the player based on the direction the camera is facing
        playerRb.AddForce((focalPoint.forward * movement.y + focalPoint.right * movement.x) * playerSpeed);
    }


    private void LateUpdate()
    {
        // keep the camera focal point aligned with the player's position
        focalPoint.position = transform.position;
    }


} // end of class
