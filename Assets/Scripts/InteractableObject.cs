using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class InteractableObject : MonoBehaviour// attatch to anything you want to interact with
{
    Outline outline;
    public string message;

    public UnityEvent onInteraction;
    
    // Start is called before the first frame update
    void Start()
    {
        outline = GetComponent<Outline>();
        DisableOutline(); 
    }

    public void DisableOutline()
    {
        outline.enabled = false; 
    }

    public void EnableOutline()
    {
        outline.enabled = true;
    }

    public void Interact()
    {
        Debug.Log("Item interacted with");
        onInteraction.Invoke();
    }
    
}
