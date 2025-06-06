
using UnityEngine;


public class EnemyController : MonoBehaviour
{
    // get a reference to the spawn controller script
    private SpawnController spawnController;

    // get a reference to the enemy rigibody component
    private Rigidbody enemyRb;

    // get a reference to the player component
    private GameObject player;

    // enemy speed
    private float enemySpeed = 1f;



    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        // set reference to spawn controller script
        spawnController = GameObject.Find("Spawn Controller").GetComponent<SpawnController>();

        // set the reference to the enemy's rigidboy component
        enemyRb = GetComponent<Rigidbody>();

        // set the reference to the player component
        player = GameObject.Find("Player");
    }


    // Update is called once per frame
    void Update()
    {
        // get the position of the player and calculate a normalised direction toward them
        Vector3 lookDirection = ((player.transform.position - transform.position).normalized);

        // move enemy toward player
        enemyRb.AddForce(lookDirection * enemySpeed);
    }


    private void OnCollisionEnter(Collision collidingObject)
    {
        // if an enemy falls off the platform
        if (collidingObject.gameObject.CompareTag("Safety Net"))
        {
            // destroy the enemy
            Destroy(gameObject);

            // check to see if more enemies need to be respawned
            spawnController.RespawnEnemies();
        }
    }


} // end of class
