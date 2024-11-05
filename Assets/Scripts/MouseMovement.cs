using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class MouseMovement : MonoBehaviour
{
 
    public float mouseSensitivity = 100f;
 
    float xRotation = 0f;
    float YRotation = 0f;

    private PlayerControls controls;

    private void Awake()
    {
        controls = new PlayerControls(); 
    }

    void OnEnable()
    {
        controls.Camera.Look.performed += OnLook;
        controls.Enable(); 
    }

    void OnDisable()
    {
        controls.Camera.Look.performed -= OnLook;
        controls.Disable();
    }
    

    void Start()
    {
        //Locking the cursor to the middle of the screen and making it invisible
        Cursor.lockState = CursorLockMode.Locked;
    }
 
    void OnLook(InputAction.CallbackContext context)
    {
        //float mouseX = Input.GetAxis("Mouse X") * mouseSensitivity * Time.deltaTime;
        //float mouseY = Input.GetAxis("Mouse Y") * mouseSensitivity * Time.deltaTime; //old input system

        Vector2 lookInput = context.ReadValue<Vector2>();
        
        float mouseX = lookInput.x * mouseSensitivity * Time.deltaTime;
        float mouseY = lookInput.y * mouseSensitivity * Time.deltaTime;
 
        //control rotation around x axis (Look up and down)
        xRotation -= mouseY;
        //we clamp the rotation so we cant Over-rotate (like in real life)
        xRotation = Mathf.Clamp(xRotation, -90f, 90f);
        //control rotation around y axis (Look up and down)
        YRotation += mouseX;
 
        //applying both rotations
        transform.localRotation = Quaternion.Euler(xRotation, YRotation, 0f);
 
    }
}