
using UnityEngine;


public class SpawnController : MonoBehaviour
{
    // reference for enemy prefab
    public GameObject enemyPrefab;

    // stores a random vector3 position to spawn enemy
    private Vector3 randomPosition;

    // number of enemy to spawn
    private int spawnRange = 9;




    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        SpawnEnemy();
    }


    // Update is called once per frame
    void Update()
    {
        
    }


    // generates random spawn positions for the enemy
    private Vector3 GenerateRandomSpawnPosition()
    {
        // get a random position along the'x' axis between -9 and 9
        float spawnPosX = Random.Range(-spawnRange, spawnRange);

        // get a random position along the'z' axis between -9 and 9
        float spawnPosZ = Random.Range(-spawnRange, spawnRange);

        // create the new position
        randomPosition = new Vector3(spawnPosX, 0f, spawnPosZ);

        // and return it
        return randomPosition;
    }


    private void SpawnEnemy()
    {
        Instantiate(enemyPrefab, GenerateRandomSpawnPosition(), enemyPrefab.transform.rotation);
    }


} // end of class
