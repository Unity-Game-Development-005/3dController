
using System.Collections;
using UnityEngine;


public class PlayerController : MonoBehaviour
{
    // get a reference to the camera focal point transform
    // (set in inspector)
    public Transform focalPoint;


    // get a reference ro the player's rigidbody component
    private Rigidbody playerRb;

    // player's start location
    private Vector3 playerStartPosition = new Vector3(20f, 0.5f, 0f);

    // player's movement speed
    public float playerSpeed = 5f;

    // indicates player has pickup a powerup item
    public bool hasPowerup;

    // get a reference to the player's powerup indicator
    // (set in inspector)
    public GameObject powerupIndicator;

    // strength of powerup
    private float powerupStrength = 15f;

    // time powerup lasts
    private float powerupTime = 10f;

    // player input controls
    // horizontal
    private float horizontalInput;

    // vertical
    private float verticalInput;



    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        // set reference to the player's rigidbody component
        playerRb = GetComponent<Rigidbody>();
    }


    // Update is called once per frame
    void Update()
    {
        PositionPowerupIndicator();

        GetPlayerInput();

        MovePlayer();
    }


    private void LateUpdate()
    {
        // keep the camera focal point aligned with the player's position
        focalPoint.position = transform.position;
    }


    private void GetPlayerInput()
    {
        // player's forward and backward input
        verticalInput = Input.GetAxis("Vertical");

        // player's left and right input
        horizontalInput = Input.GetAxis("Horizontal");
    }


    private void MovePlayer()
    {
        // calculate a position to move the player to based on their input and normalise the value
        Vector2 movement = new Vector2(horizontalInput, verticalInput).normalized;

        // move the player based on the direction the camera is facing
        playerRb.AddForce((focalPoint.forward * movement.y + focalPoint.right * movement.x) * playerSpeed);
    }


    private void ResetPlayerPosition()
    {
        // stop player from moving
        playerRb.isKinematic = true;

        // reset player to start position
        transform.position = playerStartPosition;

        // allow player to move again
        playerRb.isKinematic = false;
    }


    private void PositionPowerupIndicator()
    {
        // places the powerup indicator at the feet of the player
        powerupIndicator.transform.position = transform.position + new Vector3(0f, -0.5f, 0f);
    }



    private void OnTriggerEnter(Collider collidingObject)
    {
        // if player has coillided with a powerup
        if (collidingObject.CompareTag("Powerup"))
        {
            // set hasPowerup to true
            hasPowerup = true;

            // destroy the powerup
            Destroy(collidingObject.gameObject);

            // activate the powerup indicator
            powerupIndicator.gameObject.SetActive(true);

            // then start the timer for how long the powerup lasts
            StartCoroutine(PowerupCountdown());
        }
    }


    private IEnumerator PowerupCountdown()
    {
        // wait for the powerup time to expire
        yield return new WaitForSeconds(powerupTime);

        // the set haspower to false
        hasPowerup = false;

        // deactivate the powerup incidator
        powerupIndicator.gameObject.SetActive(false);
    }


    private void OnCollisionEnter(Collision collidingObject)
    {
        // if the player falls off the platform
        if (collidingObject.gameObject.CompareTag("Safety Net"))
        {
            ResetPlayerPosition();
        }


        // if the player has collided with an enemy and is carrying a powerup item
        if (collidingObject.gameObject.CompareTag("Enemy") && hasPowerup)
        {
            // get and set a reference to the enemy rigidbody component
            Rigidbody enemyRigidbody = collidingObject.gameObject.GetComponent<Rigidbody>();

            // set the direction of the knockback
            Vector3 knockBack = (collidingObject.gameObject.transform.position - transform.position);

            Debug.Log("COLLIDED WITH " + collidingObject.gameObject.name + " with powerup set to " + hasPowerup);

            // and knockback the enemy 
            ///enemyRigidbody.AddForce(knockBack * powerupStrength, ForceMode.Impulse);

            // destroy the enemy
            Destroy(collidingObject.gameObject);
        }
    }


} // end of class
