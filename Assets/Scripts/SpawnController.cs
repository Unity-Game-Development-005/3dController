
using System.Collections.Generic;
using UnityEngine;


public class SpawnController : MonoBehaviour
{
    // get a reference to the powerup controller
    private PowerupController powerupController;


    // reference for enemy prefab
    public GameObject[] enemyPrefabs;

    // list for spawned enemies
    //private List<GameObject> spawnedEnemiesList;

    // stores a random vector3 position to spawn enemy
    private Vector3 randomEnemyPosition;

    // the spawn range (x and z) to spawn enemies
    private int spawnRange = 9;

    // keeps track of the number of enemies in play
    // made public so it can be accessed for the enemy controller script
    public int enemyCount;

    // enemy wave number
    // made public so it can be accessed for the enemy controller script
    public int enemyWave;

    // number of enemies to spawn per wave
    // made public so it can be accessed for the enemy controller script
    public int enemiesToSpawn;



    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        // set reference to spawn controller script
        powerupController = GameObject.Find("Powerup Controller").GetComponent<PowerupController>();

        Initialise();

        SpawnRandomEnemyWave(enemiesToSpawn);
    }


    // Update is called once per frame
    void Update()
    {
        
    }


    private void Initialise()
    {
        ///spawnedEnemiesList = new List<GameObject>();

        enemyCount = 0;

        enemyWave = 1;

        enemiesToSpawn = 1;
    }


    // generates random spawn positions for the enemy
    private Vector3 GenerateRandomSpawnPosition()
    {
        // get a random position along the'x' axis between -9 and 9
        float spawnPosX = Random.Range(-spawnRange, spawnRange);

        // get a random position along the'z' axis between -9 and 9
        float spawnPosZ = Random.Range(-spawnRange, spawnRange);

        // create the new position
        randomEnemyPosition = new Vector3(spawnPosX, 0f, spawnPosZ);

        // and return it
        return randomEnemyPosition;
    }


    // made public so it can be accessed for the enemy controller script 
    public void SpawnRandomEnemyWave(int enemiesToSpawn)
    {
        // loop through number of enemies to spawn
        for (int enemy = 0; enemy < enemiesToSpawn; enemy++ )
        {
            // select a random enemy
            int randomEnemy = Random.Range(0, enemyPrefabs.Length);

            // instantiate the enemy at random spawn location
            GameObject instantiatedObject = Instantiate(enemyPrefabs[randomEnemy], GenerateRandomSpawnPosition(), enemyPrefabs[randomEnemy].transform.rotation);

            // add the enemy to the spawned enemies list
            ///spawnedEnemiesList.Add(instantiatedObject);

            // keep track of the number of enemies in play
            enemyCount = enemiesToSpawn;
        }

        // spawn a random powerup
        powerupController.SpawnRandomPowerup();
    }


} // end of class
