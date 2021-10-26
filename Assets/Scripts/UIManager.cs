using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

// This class handles all of the UI present within the game
public class UIManager : MonoBehaviour
{

    public Text _countLapText; // text display for lap count
    public Text _winText; // text display for game completion or failure
    public Text _gameTitleText; // Displays the text "tokyo take over throughout game time'
    
    public static UIManager instance; // instance of PlayerController class

    // Awake is called when the script instance is being loaded. Checks to make sure the instance is not null and assigns it to this class
    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
    }

    // Start is called before the first frame update and displays the UI elements needed before count down stops
    void Start()
    {
        _gameTitleText.text = "TokyoTakeOver";
        _countLapText.gameObject.SetActive(false);
        _winText.gameObject.SetActive(false);
    }


    // UI details for run time of the game
    public void DisplayStartUI()

    {
        // lap of time text to be active and assigned to the scene
        _countLapText.gameObject.SetActive(true);
   
       
    }

   
}
