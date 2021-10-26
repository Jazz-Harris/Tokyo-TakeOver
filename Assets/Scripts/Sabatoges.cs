using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

// This game controls the sabatoges collisions and sabatoges count to the UI
public class Sabatoges : MonoBehaviour
{
   
    public Text _countLapText; // text display for lap count
    private int _countLap = 0; // counter for each lap passed by the player during runtime
    private int _Level1LapGoal = 3; // number of laps to be completed before the player will win the game if reached before AI
    public Text _SabotageDetails; // text display that informs the user of what the sabotage does

    public static Sabatoges instance;

    // Awake is called when the script instance is being loaded. Checks to make sure the instance is not null and assigns it to this class
    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
    }

    // Checks to see if the player has collided with a blue sabatoge and handles the effect of the sabatoge
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("BlueSabatoge"))
        {
            other.gameObject.SetActive(false);
            

        

            _SabotageDetails.text = "No speed for" + "\n" + "4 seconds";
            BlueSabotage();
        }

        // Checks to see if the player has collided with a blue sabatoge and handles the effect of the sabatoge
        else if (other.gameObject.CompareTag("WhiteSabatoge"))
        {
            other.gameObject.SetActive(false);

            

            _SabotageDetails.text = "Slowed for " + "\n" + "7 seconds";
            WhiteSabotage();

        }
        // Checks to see if the player has reached the finish line
        else
        {

            _countLap += 1;

            _countLapText.text = "LAP   " + _countLap + "  OF  " + _Level1LapGoal;


            if (_countLap == _Level1LapGoal)
            {
                PlayerController.instance.FinishLine();
            }
        }


    }

    // Blue Sabotage when hit will cause the AI or Player to stop moving completely for 7 seconds
    public void BlueSabotage()
    {
        PlayerMovement.instance._moveSpeed = 0.0f;
        PlayerMovement.instance.playerMove.velocity = Vector2.zero;
        PlayerMovement.instance.playerMove.angularVelocity = 0f;

        StartCoroutine(StopMovement());

    }

    // White Sabotage when hit will cause the AI or Player to have a reduced speed for 7 seconds
    public void WhiteSabotage()
    {
        PlayerMovement.instance._moveSpeed = 1f;
        StartCoroutine(SpeedReduction());
    }

     IEnumerator  SpeedReduction()
    {
        yield return new WaitForSeconds(7f);
        _SabotageDetails.text = " ";
        PlayerMovement.instance._moveSpeed = 3f;
    }

    IEnumerator StopMovement()
    {
        yield return new WaitForSeconds(4f);
        _SabotageDetails.text = " ";
        PlayerMovement.instance._moveSpeed = 3f;
    }
}