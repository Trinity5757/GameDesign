using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Blowing Bubble Minigame. This is to simulate the creation of the socket. 
public class BlowingBubble : MonoBehaviour
{
    //The Variables for the Minigame 
    //They will be used for implementing Dynamic Difficulty

    //Declaring the bubble object
    public GameObject bubbleObject;

    //Declaring the timer variables to account for dynamic difficulty
    public float timer = 10.0f;
    private float originalTimer;
    public float difficultyIncrease = 0.5f;

    //To establish the growth rate of the bubble per button press
    public float growthRate = 0.1f;

    //Boolean to check to see if the Game has been won
    private bool gameWon = false;

    //Declaring the variables for the popup Window
    public GameObject winPopup;
    public GameObject lossPopup;

    //Declaring variables for the Cast;
    private float castSize;
    private float targetSize;

    //Start is called before the first frame update
    void Start()
    {
        //Establishes that the original timer is equal to the timer variable
        originalTimer = timer;
        setupNewRound();
    }

    void Update()
    {
        //A continual loop to check to see if the user has one the game. 
        if (!gameWon)
        {
            //Updates the Timer
            timer -= Time.deltaTime;

            //Checks to see if the timer is 0
            if (timer <= 0)
            {
                ShowLossPopup();
            }
            if(Input.GetMouseButton(0))
            {
                RightClick();
            }
        }
    }

    //Established the loss popup
    void ShowLossPopup()
    {
        lossPopup.SetActive(true);
        //Increases the amount of time available
        gameWon = true;
    }

    //Established the Win Popup
    void ShowWinPopup()
    {
        winPopup.SetActive(true);
        //Decreases the amount of time available
        gameWon = true;
        timer -= difficultyIncrease;
    }

    //Sets up the first round of the minigame
    void setupNewRound()
    {
        //Will reset the bubble size
        bubbleObject.transform.localScale = Vector3.one * 0.1f;

        //Randomize the cast size
        castSize = Random.Range(1.5f, 3.0f);

        //Determine the target Bubble position
        targetSize = castSize * (2.0f / 3.0f);

        //Resets the Timer 
        timer = originalTimer;
        gameWon = false;

        //Hides the Popups
        winPopup.SetActive(false);
        lossPopup.SetActive(false);
    }

    //Sets up a new round of the minigame
    void restartGame()
    {
        setupNewRound();
    }

    public void RightClick()
    {
        Debug.Log("OnButtonPress");
        //Checks to see if the game has been one
        if (gameWon)
        {
            return;
        }

        //Increases the Bubble size
        bubbleObject.transform.localScale += Vector3.one * growthRate;

        Debug.Log("Curent Bubble Size: " + bubbleObject.transform.localScale);
        //Checks to see if the User has won.
        if (transform.localScale.x >= targetSize)
        {
            gameWon = true;
            ShowWinPopup();
        }
    }
}
