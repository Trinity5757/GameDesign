using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Blowing Bubble Minigame. This is to simulate the creation of the socket. 
public class BlowingBubble : MonoBehaviour
{
    //The Variables for the Minigame 
    //They will be used for implementing Dynamic Difficulty

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
        if(!gameWon)
        {
            //Updates the Timer
            timer -= Time.deltaTime;

            //Checks to see if the timer is 0
            if(timer <=0)
            {
                ShowLossPopup();
            }
        }
    }

    //Established the loss popup
    void ShowLossPopup()
    {

    }


    //Established the Win Popup
    void ShowWinPopup()
    {
        
    }

    //Sets up the first round of the minigame
    void setupNewRound()
    {

    }

    //Sets up a new round of the minigame
    void restartGame()
    {

    }



}
