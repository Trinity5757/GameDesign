using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Blowing Bubble Minigame.
public class BlowingBubble : MonoBehaviour
{

    //Adding the dynamic difficult  variables
    public float difficultyLevel = 1;
    public float difficultyIncrease = 0.1f;
    public float interatactionTime = 5.0f;
    public float playerScore = 0;
    public float timer;

    //Declaring Variables for the bubbles growth rate.
    public float growthRate = 0.5f + (difficultyLevel * difficultyIncrease);
    public float maxSize = 2.0f;
    private Vector3 originalScale;


    // Start is called before the first frame update
    void Start()
    {
        originalScale = transform.localScale;
        timer = interatactionTime;
    }

    // Update is called once per frame
    void Update()
    {
        //Adjusts the timer;
        timer -= Time.deltaTime;
        //Adjusts the growth rate dynamically

        float growthRate = 0.5f + (difficultyLevel * difficultyIncrease);

        if(transform.localScale.x < maxSize && timer > 0)
        {
            transform.localScale += Vector3.one * growthRate * Time.deltaTime;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    void OnMouseDown()
    {
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

    void AdjustDifficulty()
    {
        if(playerScore >=10)
        {
            difficultyLevel = 2;
        }
        else if (playerScore >= 20)
        {
            difficultyLevel = 3;
        }
        else if (playerScore >= 30)
        {
            difficultyLevel = 4;
        }
    }
}
