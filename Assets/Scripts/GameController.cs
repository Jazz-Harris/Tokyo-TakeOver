using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

// This Class is handle the start,run and end time of the game
public class GameController : MonoBehaviour
{
    
    public Text _countLapText; // text display for lap count
    public Text _winText; // text display for game completion or failure
    public Text _timerText; // text display for in game timer

    public static GameController instance; // instance of PlayerController class

    // Awake is called when the script instance is being loaded. Checks to make sure the instance is not null and assigns it to this class
    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
    }

    // This method is used to display the proper UI display for when the game is started after the count down ends (In CountDownTimer)
    public void StartGame()
    {
        if (_countLapText != null )
        {
            _countLapText.text = "Lap 0 OF 1";

           

        }

       

        // starts the player movement ability
        PlayerMovement.instance.StartGame();

        // starts the AI movement ability
        AIController.instance.moveEnemyAtStart();
    }

   
}
