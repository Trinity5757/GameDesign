using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WireConnection : MonoBehaviour
{
    //A knock off Method is a prefab
    public GameObject linePrefab;

    //Will describe the position in the game (Shows postion, relation, and scale)
    public Transform targetPoint;

    //Current wire being drawn
    private LineRenderer currentLine;
    private bool isDragging = false;

    //Where the wire will begin 
    private Vector3 startPosition;


    void Update()
    {
        //Checking to see if the line is rendered
        if(currentLine != null)
        {
            currentLine.SetPosition(0, startPosition);
            //Converts the mouse position to world space and update the end position of the wire
            Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            //Sets the wire in 2D space by settings the z position to 0
            mousePos.z = 0;
            currentLine.SetPosition(1, mousePos);
        }
        //Begin dragging a wire on the mouse click
        if(Input.GetMouseButtonDown(0))
        {
            StartDrag();
        }

        //Update the wire to follow the mouse 
        if(isDragging)
        {
            //Reference to 3d space or could reference 3 seperate things
            Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            //Keep the mouse in the 2D space
            mousePos.z = 0;
            //Actually sets the position
            currentLine.SetPosition(1, new Vector3(mousePos.x, mousePos.y, 0));
        }

        //Stop dragging the body when the mouse is released
        if(Input.GetMouseButtonUp(0) && isDragging)
        {
            StopDrag();
        }
    }

    void StartDrag()
    {
        //Will set the boolean for dragging the body to true
        isDragging = true;
        //Will have a new line created
        GameObject newLine = Instantiate(linePrefab);
        currentLine = newLine.GetComponent<LineRenderer>();
        //Sets the position of the line
        currentLine.SetPosition(0, transform.position);
    }

    void StopDrag()
    {
        isDragging = false;

        //Checks to see if the wire ends near the correct target point
        float distance = Vector3.Distance(currentLine.GetPosition(1), targetPoint.position);
        if(distance < 0.5f)
        {
            currentLine.SetPosition(1, targetPoint.position);
        }
        else
        {
            Destroy(currentLine.gameObject);
        }
    }
}