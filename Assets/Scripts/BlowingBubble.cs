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
    public float originalBubbleSize = 10f;
    public float maxBubbleSize = 30f;

    //Declaring the timer variables to account for dynamic difficulty
    public float timer = 10.0f;
    private float originalTimer;
    public float difficultyIncrease = 0.5f;

    //To establish the growth rate of the bubble per button press
    public float growthRate = 1f;

    //Boolean to check to see if the Game has been won
    public bool gameWon = false;
    public bool gameActive = false; // activated once player clicks for the first time

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
    public float bubbleProgress;
    public TextMeshProUGUI bubbleProgressText;
    public TextMeshProUGUI timerText;

    //Declaring the Audio Manager
    private AudioManager audioManager;
    private MiniGame _miniGame;

    void Awake()
    {
        _miniGame = GetComponentInParent<MiniGame>();
    }

    //Start is called before the first frame update
    void Start()
    {
        //Establishes that the original timer is equal to the timer variable
        originalTimer = timer;
        
        bubbleObject.transform.localScale = Vector3.one * originalBubbleSize;

        audioManager = FindObjectOfType<AudioManager>();

        setupNewRound();
        SetBubbleProgressText();
    }

    void Update()
    {
        if (gameActive && !gameWon)
        {
            // Updates the Timer using unscaled time
            timer -= Time.unscaledDeltaTime;

            // Checks to see if the timer is 0
            if (timer <= 0)
            {
                ShowLossPopup();
            }

            // Updates the timer text
            timerText.text = "Time: " + Mathf.Max(0, timer).ToString("F1");
        }
        
        //A continual loop to check to see if the user has one the game. 
        if (!gameWon)
        {
            //Checks to see if the User clicked the Button
            if (Input.GetMouseButtonDown(0))
            {
                RightClick();
                //Updates the Bubble Percentage Text
                SetBubbleProgressText();
            }
        }
    }
    

    //Established the loss popup
    void ShowLossPopup()
    {
        Debug.Log("Loss Popup Triggered");
        lossPopup.SetActive(true);
        //Increases the amount of time available
        gameWon = true;
        audioManager.PlayLooseNoise();
        //Declaring the onClick Handlers
        restartButton.onClick.AddListener(setupNewRound);
        quitButton.onClick.AddListener(ExitAndReset);
        timer += difficultyIncrease;
    }

    //Established the Win Popup
    void ShowWinPopup()
    {
        winPopup.SetActive(true);
        //Decreases the amount of time available
        gameWon = true;
        timer -= difficultyIncrease;
        audioManager.PlayWinNoise();
        //Declaring the onClick Handlers
        nextButton.onClick.AddListener(ContinueAndReset);
    }

    void ContinueAndReset()
    {
        setupNewRound();
        _miniGame.CompleteMiniGame();
    }

    void ExitAndReset()
    {
        setupNewRound();
        _miniGame.ExitMiniGame();
    }
    

    //Sets up the first round of the minigame
    void setupNewRound()
    {
        bubbleProgress = 0f;

        //Will reset the bubble size
        bubbleObject.transform.localScale = Vector3.one * originalBubbleSize;

        //Randomize the cast size
        castSize = Random.Range(1.5f, 3.0f);
        PlayerPrefs.SetFloat("castSize", castSize);

        //Determine the target Bubble position
        //targetSize = Mathf.Min(castSize * (2.0f / 3.0f), maxBubbleSize);
        targetSize = maxBubbleSize;

        //Resets the Timer 
        timer = originalTimer;
        gameWon = false;

        //resets bubble progress
        bubbleProgress = 0f;

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
        //Debug.Log("OnButtonPress");
        gameActive = true;
        //Checks to see if the game has been one
        if (gameWon)
        {
            return;
        }

        //Increases the Bubble size
        bubbleObject.transform.localScale += Vector3.one * growthRate;

        audioManager.PlayClickSound();

        if (bubbleObject.transform.localScale.x > maxBubbleSize)
        {
            bubbleObject.transform.localScale = Vector3.one * maxBubbleSize;
        }
        Debug.Log("Curent Bubble Size: " + bubbleObject.transform.localScale);
        //Checks to see if the User has won.
        if (bubbleObject.transform.localScale.x >= targetSize)
        {
            gameWon = true;
            gameActive = false;
            ShowWinPopup();
        }
    }

    public void SetBubbleProgressText()
    {
        // Get the current bubble size as a scalar (assuming uniform scaling)
        float currentSize = bubbleObject.transform.localScale.x;

        // Calculate progress as a percentage of growth from the original size to the target size
        bubbleProgress = ((currentSize - originalBubbleSize) / (targetSize - originalBubbleSize)) * 100f;

        // Clamp the value to a maximum of 100%
        bubbleProgress = Mathf.Clamp(bubbleProgress, 0f, 100f);
        
        bubbleProgressText.text = "Bubble Progress: " + Mathf.Min(bubbleProgress, 100f).ToString("F1") + "%";
    }

    //Centering the Runaway Bubble
    void CenterBubble()
    {
        bubbleObject.transform.localPosition = Vector3.zero;
    }
}