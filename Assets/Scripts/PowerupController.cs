
using System.Collections.Generic;
using UnityEngine;


public class PowerupController : MonoBehaviour
{
    // get a reference to the game controller script
    //private GameController gameController;

    // get a reference to the spawn controller script
    private SpawnController spawnController;


    // set reference to pickup prefab
    public GameObject[] powerupPrefabs;

    // list for spawned pickups
    //private List<GameObject> spawnedPickupsList;

    // stores a random vector3 position to spawn powerup
    private Vector3 randomPowerupPosition;

    // the spawn range (x and z) to spawn powerups
    private int spawnRange = 9;

    // start position for coin spawner
    //private Vector3 pickupSpawnPos;

    // start delay in seconds for the obstacle spawner
    //private float startDelay;

    // the time between spawns in seconds
    //private float repeatRate;



    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        // set reference to game controller script
        //gameController = GameObject.Find("Game Controller").GetComponent<GameController>();

        // set reference to spawn controller script
        spawnController = GameObject.Find("Spawn Controller").GetComponent<SpawnController>();

        //Initialise();

        // start the obstacle spawner
        //SelectRandomSpawnTime();
    }


    private void Initialise()
    {
        //spawnedPickupsList = new List<GameObject>();

        //pickupSpawnPos = new Vector3(25f, 4f, 0f);

        //startDelay = 2;

        //repeatRate = 2;
    }


    //private void SelectRandomSpawnTime()
    //{
    // if the game is not running
    //if (gameController.gameOver)
    //{
    // stop spawning obstacles
    //CancelInvoke();
    //}

    // select a random drop time base on the start delay time
    //float nextPickup = Random.Range(startDelay, startDelay * repeatRate);

    // spawn a random ball
    //Invoke(nameof(SelectRandomSpawnTime), nextPickup);

    // select another randon drop rate
    //Invoke(nameof(SpawnRandomPowerup), nextPickup);
    //}


    public void SpawnRandomPowerup()
    {
        // select a random powerup
        int randomPowerup = Random.Range(0, powerupPrefabs.Length);

        // instantiate the powerup at random spawn location
        GameObject instantitatedObject = Instantiate(powerupPrefabs[randomPowerup], spawnController.GenerateRandomSpawnPosition(), powerupPrefabs[randomPowerup].transform.rotation);
    }


} // end of class
