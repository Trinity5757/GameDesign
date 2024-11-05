using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Billboard : MonoBehaviour
{
    
    //apply to any sprite for a billboarded effect

    private SpriteRenderer SR;
    
    // Start is called before the first frame update
    void Start()
    {
        SR = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        //position of camera to face
        Vector3 targetPosition = Camera.main.transform.position;
        
        //calculate direction then zero out y component to remove vertical tilt
        Vector3 direction = (transform.position - targetPosition).normalized;
        direction.y = 0;

        //SR.flipX = (transform.position.z < targetPosition.x); //flip based on position 
        
        if (direction.sqrMagnitude > 0.01f) // Avoid small jitter when close to the target
        {
            transform.forward = direction.normalized;
        }
    }
}
