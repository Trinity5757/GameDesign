using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


//This is the timer. It will complete the dynamic difficulty requirement
//This is the base code for the timer
public class Timer : MonoBehaviour
{

    //A float to reference the timer.
    public float timeRemaining = 30f;
    //Having the timer be set to the screen
    public Text timerText;

    bool timerIsRunning = false;
    // Start is called before the first frame update
    void Start()
    {
        //Start the timer
        timerIsRunning = true;
    }

    // Update is called once per frame
    void Update()
    {
        if(timerIsRunning)
        {
            //Decreases the timer
            if(timeRemaining > 0)
            {
                timeRemaining -= Time.deltaTime;
            }
            else
            {
                //Will stop the timer
                timeRemaining = 0;
                timerIsRunning = false;
                OnTimerEnd();
            }
        }
        //Will update the timer text
        UpdateTimerDisplay();
    }

    void UpdateTimerDisplay()
    {
        timerText.text = "Time Remaining: " + Mathf.Round(timeRemaining).ToString();
    }

    void OnTimerEnd()
    {
        Debug.Log("Timer is finished");
    }
}
