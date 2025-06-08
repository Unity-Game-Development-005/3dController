
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




    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }


    // Update is called once per frame
    void Update()
    {
        
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

        // and open the options menu
        gameController.optionsMenu.SetActive(true);
    }


    public void CloseOptionsMenu()
    {
        // play a tone to signify button click
        gameController.audioPlayer.PlayOneShot(gameController.buttonClick, 1f);

        // close the options menu
        gameController.optionsMenu.SetActive(false);

        // and open the main menu
        gameController.mainMenu.SetActive(true);
    }


    public void QuitGame()
    {
        // play a tone to signify button click
        gameController.audioPlayer.PlayOneShot(gameController.buttonClick, 1f);

        Application.Quit();
    }


} // end of class
