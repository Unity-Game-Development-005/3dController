
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
        // call the start game function in the game controller script
        gameController.ReadyPlayerOne();
    }


    public void OpenOptionsMenu()
    {

    }


    public void CloseOptionsMenu()
    {

    }


    public void QuitGame()
    {
        Application.Quit();
    }


} // end of class
