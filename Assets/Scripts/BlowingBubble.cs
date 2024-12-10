using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;

//Blowing Bubble Minigame. This is to simulate the creation of the socket. 
public class BlowingBubble : MonoBehaviour
{
    //The Variables for the Minigame 
    //They will be used for implementing Dynamic Difficulty

    //Declaring the bubble object
    public GameObject bubbleObject;
    public float maxBubbleSize = 3.0f;

    //Declaring the timer variables to account for dynamic difficulty
    public float timer = 10.0f;
    private float originalTimer;
    public float difficultyIncrease = 0.5f;

    //To establish the growth rate of the bubble per button press
    public float growthRate = 0.01f;

    //Boolean to check to see if the Game has been won
    private bool gameWon = false;

    //Declaring the variables for the popup Window
    public GameObject winPopup;
    public GameObject lossPopup;

    //Declaring variables for the Cast;
    private float castSize;
    private float targetSize;

    //Declaring the Buttons
    public Button restartButton;
    public Button quitButton;
    public Button nextButton;

    //Declaring the Text Variables
    public TextMeshProUGUI bubbleProgressText;
    public TextMeshProUGUI timerText;

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

            //Updates the timer text
            timerText.text = "Time: " +  Mathf.Max(0, timer).ToString("F1");


            //Checks to see if the User clicked the Button
            if (Input.GetMouseButton(0))
            {
                RightClick();
            }

            //Updates the Bubble Percentage Text
            float bubbleProgress = (bubbleObject.transform.localScale.x / targetSize) * 100f;
            bubbleProgressText.text = "Bubble Progress: " + Mathf.Min(bubbleProgress, 100f).ToString("F1") + "%";
        }
    }

    //Established the loss popup
    void ShowLossPopup()
    {
        Debug.Log("Loss Popup Triggered");
        lossPopup.SetActive(true);
        //Increases the amount of time available
        gameWon = true;
        //Declaring the onClick Handlers
        restartButton.onClick.AddListener(setupNewRound);
        quitButton.onClick.AddListener(LoadPreviousScene);
        timer += difficultyIncrease;
    }

    //Established the Win Popup
    void ShowWinPopup()
    {
        winPopup.SetActive(true);
        //Decreases the amount of time available
        gameWon = true;
        timer -= difficultyIncrease;
        //Declaring the onClick Handlers
        nextButton.onClick.AddListener(LoadNextScene);
    }

    //For the quit Button 
    void LoadPreviousScene()
    {
        SceneManager.LoadScene("ForestLevel");
    }

    //For the next Button 
    void LoadNextScene()
    {
        SceneManager.LoadScene("CastingMiniGame");
    }

    //Sets up the first round of the minigame
    void setupNewRound()
    {
        //Will reset the bubble size
        bubbleObject.transform.localScale = Vector3.one * 0.1f;

        //Randomize the cast size
        castSize = Random.Range(1.5f, 3.0f);
        PlayerPrefs.SetFloat("castSize", castSize);

        //Determine the target Bubble position
        targetSize = Mathf.Min(castSize * (2.0f / 3.0f), maxBubbleSize);

        //Resets the Timer 
        timer = originalTimer;
        gameWon = false;

        //Hides the Popups
        winPopup.SetActive(false);
        lossPopup.SetActive(false);
        CenterBubble();
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

        if (bubbleObject.transform.localScale.x > maxBubbleSize)
        {
            bubbleObject.transform.localScale = Vector3.one * maxBubbleSize;
        }
        Debug.Log("Curent Bubble Size: " + bubbleObject.transform.localScale);
        //Checks to see if the User has won.
        if (bubbleObject.transform.localScale.x >= targetSize)
        {
            gameWon = true;
            ShowWinPopup();
        }
    }

    //Centering the Runaway Bubble
    void CenterBubble()
    {
        bubbleObject.transform.localPosition = Vector3.zero;
        bubbleObject.transform.localScale = Vector3.one;
    }
}
