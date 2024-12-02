using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Blowing Bubble Minigame.
public class BlowingBubble : MonoBehaviour
{

    //Declaring Variables for the bubbles growth rate.
    public float growthRate = 0.5f;
    public float maxSize = 2.0f;
    private Vector3 originalScale;


    // Start is called before the first frame update
    void Start()
    {
        originalScale = transform.localScale;
    }

    // Update is called once per frame
    void Update()
    {
        if(transform.localScale.x < maxSize)
        {
            transform.localScale += Vector3.one * growthRate * Time.deltaTime;
        }
        else
        {
            Destroy(gameObject);
        }
    }
}
