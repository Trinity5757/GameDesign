using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum Wire {wire1, wire2, wire3, wire4};
public class WireStats : MonoBehaviour
{
    //Checks to see if the wire is able to move
    public bool movable = false; 

    //Checks to see if the wire is moving
    public bool moving = false; 

    //Is the beginning position of the wire
    public Vector3 startingPosition;
    // Start is called before the first frame update
    void Start()
    {
        startingPosition = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
