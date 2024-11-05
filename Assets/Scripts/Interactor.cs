using System.Collections;
using System.Collections.Generic;
using UnityEngine;


interface IInteractable
{
    public void Interact();
}


public class Interactor : MonoBehaviour
{
    public Transform InteractSource;
    public float InteractRange;
    
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E)) // Check to see if player is pressing E  
        {
            Ray ray = new Ray(InteractSource.position, InteractSource.forward); //a raycast is created with position and direction of source
            if (Physics.Raycast(ray, out RaycastHit hitInfo, InteractRange)) 
            {
                if (hitInfo.collider.gameObject.TryGetComponent(out IInteractable interactObj)) //if object is hit, we attempt to use the interact method 
                {
                    interactObj.Interact();
                }
            }
        }
    }
}
