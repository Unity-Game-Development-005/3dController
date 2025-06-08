
using UnityEngine;


public class BrickController : MonoBehaviour
{
    // get a reference to the game controller script
    private GameController gameController;

    // get a reference to the level controller script
    private LevelController levelController;


    // brick points for score
    public int brickPoints;



    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        // set the reference to the game controller script
        gameController = GameObject.Find("Game Controller").GetComponent<GameController>();

        // set the reference to the level controller script
        levelController = GameObject.Find("Level Controller").GetComponent<LevelController>();
    }


    private void OnCollisionEnter(Collision collidingObject)
    {
        // if the puck collides with a brick
        if (collidingObject.gameObject.CompareTag("Puck"))
        {
            // destroy the brick
            Destroy(gameObject);

            // subtract 1 from the number of total bricks
            levelController.numberOfBricks[0]--;

            // increase score by brick points
            gameController.score += brickPoints;

            // update the score
            gameController.UpdateScore();
        }
    }


} // end of class
