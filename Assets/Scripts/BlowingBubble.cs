using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Blowing Bubble Minigame. This is to simulate the creation of the socket. 
public class BlowingBubble : MonoBehaviour
{

    //Adding the dynamic difficult  variables
    public float difficultyLevel = 1;
    public float difficultyIncrease = 0.1f;
    public float interactionTime = 5.0f;
    public float playerScore = 0;
    public float timer;

    //Declaring Variables for the bubbles growth rate.
    public float growthRate = 0.5f;
    public float maxSize = 2.0f;
    private Vector3 originalScale;   

    // Start is called before the first frame update
    void Start()
    {
        originalScale = transform.localScale;
        timer = interactionTime;
    }

    // Update is called once per frame
    void Update()
    {
        //Adjusts the timer;
        timer -= Time.deltaTime;
        //Adjusts the growth rate dynamically

        growthRate = 0.5f + (difficultyLevel * difficultyIncrease);

        if(transform.localScale.x < maxSize && timer > 0)
        {
            transform.localScale += Vector3.one * growthRate * Time.deltaTime;
        }
        else
        {
            Destroy(gameObject);
        }
        if(timer < 0)
        {

            Destroy(gameObject);
            // popupPanel.ShowPopup();
        }
    }

    //What occurs when the mouse is clicked. 
    void OnMouseDown()
    {
        //Adjusts the player score. 
        if(transform.localScale.x < maxSize )
        {
            playerScore++;
        }
        else
        {
            playerScore--;
        }

        Destroy(gameObject);
        AdjustDifficulty();
    }

    //The function to adjust the difficulty level. 
    void AdjustDifficulty()
    {
       difficultyLevel = Mathf.Floor(playerScore / 10) + 1;
    }
}
