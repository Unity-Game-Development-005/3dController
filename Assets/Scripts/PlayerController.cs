
using System.Collections;
using UnityEngine;


public class PlayerController : MonoBehaviour
{
    // get a reference to the spawn controller script
    private SpawnController spawnController;

    // get a reference to the game controller script
    private GameController gameController;

    // get a reference to the player's health bar script
    private PlayerHealthBar playerHealthBar;



    // get a reference to the camera focal point transform
    // (set in inspector)
    public Transform focalPoint;


    // get a reference ro the player's rigidbody component
    public Rigidbody playerRb;

    // player's start location
    private Vector3 playerStartPosition = new Vector3(20f, 0.5f, 0f);

    // player's movement speed
    public float playerSpeed = 5f;

    // indicates player has pickup a powerup item
    public bool hasKillPowerup;

    // get a reference to the player's powerup indicator
    // (set in inspector)
    public GameObject powerupIndicator;

    // get a reference to the player's health bar
    // (set in inspector)
    public GameObject healthBarIndicator;

    // strength of powerup
    private float powerupStrength = 15f;

    // time powerup lasts
    private float powerupTime = 10f;

    // player input controls
    // horizontal
    private float horizontalInput;

    // vertical
    private float verticalInput;

    // get a reference to the audio source component
    private AudioSource audioPlayer;

    // in-game sounds
    public AudioClip jumpSound;

    public AudioClip crashSound;

    public AudioClip pickupSound;


    // maximum damage to player
    private const int MAXIMUM_DAMAGE = 100;




    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        // set reference to spawn controller script
        spawnController = GameObject.Find("Spawn Controller").GetComponent<SpawnController>();

        // set reference to game controller script
        gameController = GameObject.Find("Game Controller").GetComponent<GameController>();

        // set reference to player health bar script
        playerHealthBar = GetComponentInChildren<PlayerHealthBar>();


        // set reference to the player's rigidbody component
        //playerRb = GetComponent<Rigidbody>();

        // set reference to the audio source component
        audioPlayer = GetComponent<AudioSource>();
    }


    // Update is called once per frame
    void Update()
    {
        PositionIndicators();

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
        // if we are not in countdown
        if (!gameController.inCountdown)
        {
            // if we are playing the game
            if (gameController.inPlay)
            {
                // get player's forward and backward input
                verticalInput = Input.GetAxis("Vertical");

                // get player's left and right input
                horizontalInput = Input.GetAxis("Horizontal");
            }
        }
    }


    private void MovePlayer()
    {
        // calculate a position to move the player to based on their input and normalise the value
        Vector2 movement = new Vector2(horizontalInput, verticalInput).normalized;

        // move the player based on the direction the camera is facing
        playerRb.AddForce((focalPoint.forward * movement.y + focalPoint.right * movement.x) * playerSpeed);
    }


    public void ResetPlayerPosition()
    {
        // stop player from moving
        playerRb.isKinematic = true;

        // reset player to start position
        transform.position = playerStartPosition;

        // allow player to move again
        playerRb.isKinematic = false;
    }


    private void PositionIndicators()
    {
        // places the powerup indicator at the feet of the player
        powerupIndicator.transform.position = transform.position + new Vector3(0f, -0.5f, 0f);

        // places the health bar at the head of the player
        healthBarIndicator.transform.position = transform.position + new Vector3(0f, 2f, 0f);
    }



    private void OnTriggerEnter(Collider collidingObject)
    {
        // if player has coillided with a powerup
        if (collidingObject.CompareTag("Kill Powerup"))
        {
            // set hasPowerup to true
            hasKillPowerup = true;

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
        hasKillPowerup = false;

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
        if (collidingObject.gameObject.CompareTag("Enemy") && hasKillPowerup)
        {
            // get and set a reference to the enemy rigidbody component
            Rigidbody enemyRigidbody = collidingObject.gameObject.GetComponent<Rigidbody>();

            // set the direction of the knockback
            Vector3 knockBack = (collidingObject.gameObject.transform.position - transform.position);

            //Debug.Log("COLLIDED WITH " + collidingObject.gameObject.name + " with powerup set to " + hasPowerup);

            // and knockback the enemy 
            ///enemyRigidbody.AddForce(knockBack * powerupStrength, ForceMode.Impulse);

            // destroy the enemy
            Destroy(collidingObject.gameObject);

            // check to see if more enemies need to be respawned
            spawnController.RespawnEnemies();
        }
    }


} // end of class
