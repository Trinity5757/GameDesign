using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Interactor : MonoBehaviour
{
    public float InteractRange = 5f;
    InteractableObject currentInteractable;
    private PlayerControls controls;

    private void Awake()
    {
        controls = new PlayerControls();
    }
    
    private void OnEnable()
    {
        controls.Player.Interact.performed += OnInteract; // Listen for the Interact action
        controls.Enable();
    }

    private void OnDisable()
    {
        controls.Player.Interact.performed -= OnInteract; // Remove listener when disabled
        controls.Disable();
    }

    private void Update()
    {
        if(Time.timeScale == 0f)
            return;
        
        CheckInteraction();
        /* old input 
        if (Input.GetKeyDown(KeyCode.E) && currentInteractable!= null) //TODO: Change this hardcoded input 
        {
            currentInteractable.Interact();
        } 
        */ 
    }
    
    private void OnInteract(InputAction.CallbackContext context)
    {
        if (currentInteractable != null)
        {
            currentInteractable.Interact(); // Trigger the interaction
        }
    }
    

    void CheckInteraction()
    {
        RaycastHit hit;
        Ray ray = new Ray(Camera.main.transform.position, Camera.main.transform.forward);

        if (Physics.Raycast(ray, out hit, InteractRange))
        {
            if (hit.collider.gameObject.CompareTag("Interactable"))
            {
                InteractableObject newInteractable = hit.collider.GetComponent<InteractableObject>();

                //check to see if current interactable is not the new interactable 
                if (currentInteractable && newInteractable != currentInteractable)
                {
                    currentInteractable.DisableOutline();
                }
                
                if (newInteractable.enabled)
                {
                    setNewCurrentInteractable(newInteractable);
                }
                else // if new interactable is not enabled 
                {
                    disableCurrentInteractable();
                }
            }
            else //if not interactable
            {
                disableCurrentInteractable();
            }
        }
        else //does not hit anything
        {
            disableCurrentInteractable();
        }
    }


    void setNewCurrentInteractable(InteractableObject newInteractable)
    {
        currentInteractable = newInteractable;
        currentInteractable.EnableOutline();
        HUDController.instance.EnableInteractionText(currentInteractable.message);
    }

    void disableCurrentInteractable()
    {
        HUDController.instance.DisableInteractionText();
        if (currentInteractable)
        {
            currentInteractable.DisableOutline();
            currentInteractable = null;
        }
    }
    
    
}
