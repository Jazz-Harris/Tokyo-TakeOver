using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

//This script is used to updated the Game/UI Display based on Player actions
public class PlayerController : MonoBehaviour
{

    public static PlayerController instance; // instance of PlayerController class
    public Text _countLapText; // text display for lap count
    public Text _winText; // text display for game completion or failure

    // Awake is called when the script instance is being loaded. Checks to make sure the instance is not null and assigns it to this class
    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
    }

    // Checks to see if the player has gathered each sabatoge available and that they have already passed the finish line
    public void FinishLine()

    {
            _winText.gameObject.SetActive(true);
        TimerText.instance.TimerEnd();

             _countLapText.text = "Race Completed!";
            _winText.text = "You Win!";  
            

        //// AI passes finish line first before player
        //if (_countSabatoge != 3)
        //{
        //    _winText.text = "Level failed!";
        //}

    }

}
