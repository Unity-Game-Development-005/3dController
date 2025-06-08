
using UnityEngine;


public class PuckController : MonoBehaviour
{
    // get a reference ro the ball's rigidbody component
    private Rigidbody puckRb;

    // ball's start location
    private Vector3 puckStartPosition = new Vector3(10f, 0.5f, 0f);



    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        // set reference to the ball's rigidbody component
        puckRb = GetComponent<Rigidbody>();
    }


    private void ResetPuckPosition()
    {
        // stop player from moving
        puckRb.isKinematic = true;

        // reset player to start position
        transform.position = puckStartPosition;

        // allow player to move again
        puckRb.isKinematic = false;
    }


    private void OnCollisionEnter(Collision collidingObject)
    {
        // if the ball falls off the platform
        if (collidingObject.gameObject.CompareTag("Safety Net"))
        {
            ResetPuckPosition();
        }
    }


} // end of class
