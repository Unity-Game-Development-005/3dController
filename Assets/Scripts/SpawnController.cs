
//using System;
//using System.Collections.Generic;
using UnityEngine;


public class SpawnController : MonoBehaviour
{
    // get a reference to the game controller script
    private GameController gameController;

    // get a reference to the powerup controller
    private PowerupController powerupController;


    // reference for enemy prefab
    public GameObject[] enemyPrefabs;

    // stores a random vector3 position to spawn enemy
    private Vector3 randomEnemyPosition;

    // the spawn range (x and z) to spawn enemies
    private float leftSpawnBoundaryZ;
    private float rightSpawnBoundaryZ;
    private float topSpawnBoundaryX;
    private float bottomSpawnBoundaryX;

    // keeps track of the number of enemies in play
    // made public so it can be accessed for the enemy controller script
    public int enemyCount;

    // enemy wave number
    // made public so it can be accessed for the enemy controller script
    public int enemyWave;

    // number of enemies to spawn per wave
    // made public so it can be accessed for the enemy controller script
    public int enemiesToSpawn;

    // maximum enemies to spawn
    private const int MAXIMUM_ENEMIES = 11;



    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        // set reference to game controller script
        gameController = GameObject.Find("Game Controller").GetComponent<GameController>();

        // set reference to powerup controller script
        powerupController = GameObject.Find("Powerup Controller").GetComponent<PowerupController>();

        InitialiseEnemySpawner();

        //SpawnRandomEnemyWave(enemiesToSpawn);
    }


    public void InitialiseEnemySpawner()
    {
        enemyCount = 0;

        enemyWave = 1;

        enemiesToSpawn = 1;

        // spawn boundaries
        leftSpawnBoundaryZ = -20f;
        rightSpawnBoundaryZ = 20f;

        topSpawnBoundaryX = -5f;
        bottomSpawnBoundaryX = 14f;

        SpawnRandomEnemyWave(enemiesToSpawn);
    }


    // generates random spawn positions for the enemy
    public Vector3 GenerateRandomSpawnPosition()
    {
        // get a random position along the'x' axis between the top and bottom spawn boundaries
        float spawnPosX = Random.Range(topSpawnBoundaryX, bottomSpawnBoundaryX);

        // get a random position along the'z' axis between the left and right spawn boundaries
        float spawnPosZ = Random.Range(leftSpawnBoundaryZ, rightSpawnBoundaryZ);

        // create the new position
        randomEnemyPosition = new Vector3(spawnPosX, 0f, spawnPosZ);

        // and return it
        return randomEnemyPosition;
    }


    // made public so it can be accessed from the enemy controller script 
    public void SpawnRandomEnemyWave(int enemiesToSpawn)
    {
        // loop through number of enemies to spawn
        for (int numberOfEnemies = 0; numberOfEnemies < enemiesToSpawn; numberOfEnemies++)
        {
            // select a random enemy
            int randomEnemy = Random.Range(0, enemyPrefabs.Length);

            // instantiate the enemy at random spawn location
            Instantiate(enemyPrefabs[randomEnemy], GenerateRandomSpawnPosition(), enemyPrefabs[randomEnemy].transform.rotation);
        }

        // keep track of the number of enemies in play
        enemyCount = enemiesToSpawn;

        // if there is more than one enemy
        if (enemiesToSpawn > 1)
        {
            // spawn a random powerup
            powerupController.SpawnRandomPowerup();
        }
    }


    // check to see if more enemies need to be spawned
    public void RespawnEnemies()
    {
        // subtract one from the number of enemies
        enemyCount--;

        // if there are no more enemies to kill
        if (enemyCount == 0)
        {
            // play next wave
            enemyWave++;

            // update ui
            UpdateWaveLevel();

            // increase the number of enemies
            enemiesToSpawn++;

            // if we have reached the maximum number of enemies to spawn
            if (enemiesToSpawn > MAXIMUM_ENEMIES)
            {
                // set the number of enemies to spawn to the maximum number
                enemiesToSpawn = MAXIMUM_ENEMIES;
            }

            // spawn next wave of enemies
            SpawnRandomEnemyWave(enemiesToSpawn);
        }
    }


    private void UpdateWaveLevel()
    {
        gameController.waveValue.text = enemyWave.ToString();
    }


} // end of class
