
using UnityEngine;


public class EnemyController : MonoBehaviour
{
    // get a reference to the enemy rigibody component
    private Rigidbody enemyRb;

    // get a reference to the player component
    private GameObject player;

    // enemy speed
    public float enemySpeed = 5f;



    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
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


} // end of class
