
using UnityEngine;


public class BallController : MonoBehaviour
{
    // get a reference ro the ball's rigidbody component
    private Rigidbody ballRb;

    // ball's start location
    private Vector3 ballStartPosition = new Vector3(10f, 0.5f, 0f);



    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        // set reference to the ball's rigidbody component
        ballRb = GetComponent<Rigidbody>();
    }


    private void ResetBallPosition()
    {
        // stop player from moving
        ballRb.isKinematic = true;

        // reset player to start position
        transform.position = ballStartPosition;

        // allow player to move again
        ballRb.isKinematic = false;
    }


    private void OnCollisionEnter(Collision collidingObject)
    {
        // if the ball falls off the platform
        if (collidingObject.gameObject.CompareTag("Safety Net"))
        {
            ResetBallPosition();
        }
    }


} // end of class
