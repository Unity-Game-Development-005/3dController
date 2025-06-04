
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

    // maximum enemies to spawn
    private const int MAXIMUM_ENEMIES = 11;



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
        Vector3 lookDirection = ((player.transform.position - transform.position).normalized);

        enemyRb.AddForce(lookDirection * enemySpeed);
    }


    private void OnCollisionEnter(Collision collidingObject)
    {
        // if an enemy falls off the platform
        if (collidingObject.gameObject.CompareTag("Safety Net"))
        {
            // destroy the enemy
            Destroy(gameObject);

            // subtract one from the number of enemies
            spawnController.enemyCount--;

            // if there are no more enemies to kill
            if (spawnController.enemyCount == 0)
            {
                // play next wave
                spawnController.enemyWave++;

                // increase the number of enemies
                spawnController.enemiesToSpawn++;

                // if we have reached the maximum number of enemies to spawn
                if (spawnController.enemiesToSpawn > MAXIMUM_ENEMIES)
                {
                    // set the number of enemies to spawn to the maximum number
                    spawnController.enemiesToSpawn = MAXIMUM_ENEMIES;
                }

                // spawn next wave of enemies
                spawnController.SpawnRandomEnemyWave(spawnController.enemiesToSpawn);
            }
        }
    }


} // end of class
