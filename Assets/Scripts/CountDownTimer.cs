using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

// This class controls and runs the count down timer to alert the player that the game has started
public class CountDownTimer : MonoBehaviour
{
    private int _countDownTime =3 ; // count down int that allows for the count down to start at 3
    public Text _countDownTextUI; // display text for count down to the user during run time of the game

    // Start is called before the first frame update. Gets Rigidbody for Player's movement and start position
    private void Start()
    {   // starts in game timer for the count down to be started
        StartCoroutine(CountDownTimerToStartGame());
    }

    // Controls the count down and display of it
    IEnumerator CountDownTimerToStartGame()
    {
        while(_countDownTime > 0)
        {   // Converts int to string for the count down time to be displayed
            _countDownTextUI.text = _countDownTime.ToString();

            yield return new WaitForSeconds(1f);

            // decrease count down seconds by one until the count down reaches 0
            _countDownTime--;
        }

        // displays text to the user to inform them they may now move
        _countDownTextUI.text = "Go!";
      
        yield return new WaitForSeconds(1f);

        // removes count down timer from game view
        _countDownTextUI.gameObject.SetActive(false);

        // starts the UI display and movement for the game
        GameController.instance.StartGame();

        // starts in game Timer
        TimerText.instance.TimerStart();


    }
}
