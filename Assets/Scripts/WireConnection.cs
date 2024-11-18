using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WireConnection : MonoBehaviour
{
    bool mouseDown = false;
    public WireStats powerWireStates;

    void Start()
    {
        powerWireStates = gameObject.GetComponent<WireStats>();
    }

    void Update()
    {
        MoveWire();
    }

    void OnMouseDown()
    {
        mouseDown = true;
    }

    void OnMouseOver()
    {
        powerWireStates.movable = true;
    }

    void OnMouseExit()
    {
        if (!powerWireStates.moving)
        {
            powerWireStates.movable = false;
        }
    }

    void OnMouseUp()
    {
        mouseDown = false;
        gameObject.transform.position = powerWireStates.startingPosition;
    }

    void MoveWire()
    {
        if (mouseDown && powerWireStates.movable)
        {
            powerWireStates.moving = true;
            float mouseX = Input.mousePosition.x;
            float mouseY = Input.mousePosition.y;
            gameObject.transform.position = Camera.main.ScreenToWorldPoint(new Vector3(mouseX, mouseY, Camera.main.nearClipPlane));
        }
        else
        {
            powerWireStates.moving = false;
        }

    }

}
// Do not want to delete old code due to notes. 
// //A knock off Method is a prefab
// public GameObject linePrefab;

// //Will describe the position in the game (Shows position, relation, and scale)
// public Transform targetPoint;

// //Current wire being drawn
// private LineRenderer currentLine;
// private bool isDragging = false;

// //Where the wire will begin 
// private Vector3 startPosition;

// void Update()
// {
//     //Checking to see if the line is rendered
//     if (currentLine != null)
//     {
//         // Set the start and end positions of the line
//         currentLine.SetPosition(0, startPosition);
//         // Converts the mouse position to world space and update the end position of the wire
//         Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
//         // Sets the wire in 2D space by setting the z position to 0
//         mousePos.z = 0;
//         currentLine.SetPosition(1, mousePos);
//     }

//     // Begin dragging a wire on the mouse click
//     if (Input.GetMouseButtonDown(0))
//     {
//         StartDrag();
//     }

//     // Update the wire to follow the mouse 
//     if (isDragging)
//     {
//         // Reference to 3D space or could reference 3 separate things
//         Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
//         // Keep the mouse in the 2D space
//         mousePos.z = 0;
//         // Actually set the position
//         currentLine.SetPosition(1, new Vector3(mousePos.x, mousePos.y, 0));
//     }

//     // Stop dragging the body when the mouse is released
//     if (Input.GetMouseButtonUp(0) && isDragging)
//     {
//         StopDrag();
//     }
// }

// void StartDrag()
// {
//     // Will set the boolean for dragging the body to true
//     isDragging = true;
//     // Will have a new line created
//     GameObject newLine = Instantiate(linePrefab);
//     currentLine = newLine.GetComponent<LineRenderer>();
//     // Sets the start position of the line
//     startPosition = transform.position;
//     currentLine.SetPosition(0, startPosition);
// }

// void StopDrag()
// {
//     isDragging = false;

//     // Checks to see if the wire ends near the correct target point
//     float distance = Vector3.Distance(currentLine.GetPosition(1), targetPoint.position);
//     if (distance < 0.5f)
//     {
//         currentLine.SetPosition(1, targetPoint.position);
//     }
//     else
//     {
//         Destroy(currentLine.gameObject);
//     }
// }