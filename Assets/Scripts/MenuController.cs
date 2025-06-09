
using UnityEngine;


public class MenuController : MonoBehaviour
{
    // reference to game controller script
    private GameController gameController;




    private void Awake()
    {
        // set reference to game controller script
        gameController = GameObject.Find("Game Controller").GetComponent<GameController>();
    }



    // when the start game button is clicked
    public void StartGame()
    {
        // play a tone to signify button click
        gameController.audioPlayer.PlayOneShot(gameController.buttonClick, 1f);

        // call the start game function in the game controller script
        gameController.ReadyPlayerOne();
    }


    public void OpenOptionsMenu()
    {
        // play a tone to signify button click
        gameController.audioPlayer.PlayOneShot(gameController.buttonClick, 1f);

        // close the main menu
        gameController.mainMenu.SetActive(false);

        // if the game is pawzed
        if (gameController.isPawzed)
        {
            gameController.pawzMenu.SetActive(false);
        }

        // and open the options menu
        gameController.optionsMenu.SetActive(true);
    }


    public void CloseOptionsMenu()
    {
        // play a tone to signify button click
        gameController.audioPlayer.PlayOneShot(gameController.buttonClick, 1f);

        // close the options menu
        gameController.optionsMenu.SetActive(false);

        // the game is pawzed
        if (gameController.isPawzed)
        {
            gameController.pawzMenu.SetActive(true);
        }

        // otherwise
        else
        {
            // open the main menu
            gameController.mainMenu.SetActive(true);
        }
    }


    public void OpenPawzScreen()
    {

    }


    public void QuitGame()
    {
        // play a tone to signify button click
        gameController.audioPlayer.PlayOneShot(gameController.buttonClick, 1f);

        Application.Quit();
    }


} // end of class
