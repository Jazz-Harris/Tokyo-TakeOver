using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TimerText : MonoBehaviour
{
    public static TimerText instance; // instance of PlayerController class
    private float startTime;
    public string minutes;
    public string seconds;
    public Text timerText;
    public bool isTimerOn = false; // bool to check to see if the timer is on or off

    // Awake is called when the script instance is being loaded. Checks to make sure the instance is not null and assigns it to this class
    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
    }

    

    // Starts timer and turns bool isTimerOn to true
    public void TimerStart()
    {
        
        isTimerOn = true;
        startTime = Time.time;

    }

    public void TimerEnd()
    {
        isTimerOn = false;
    }

    // Update is called once per frame and updates the in game timer as long as the game is in play
    void Update()
    {
        if (isTimerOn == true)
        {
            float time = Time.time - startTime;
            minutes = ((int)time / 60).ToString();
            seconds = (time % 60).ToString("f2");

            // display format for timer to be displayed
            timerText.text = minutes + ":" + seconds;

            // starts the display for the runtime UI
            UIManager.instance.DisplayStartUI();
        }
        
    }


}
