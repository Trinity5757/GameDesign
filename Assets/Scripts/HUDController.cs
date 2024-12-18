using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class HUDController : MonoBehaviour
{
   
    public static HUDController instance;
    private void Awake()
    {
        instance = this; 
    }

    [SerializeField] TMP_Text interactionText;

    public SecondaryCamera secondaryCameraScript;

    public void EnableInteractionText(string text)
    {
        interactionText.text = text + " [E]"; //TODO: Change this hardcoded input  
        interactionText.gameObject.SetActive(true);

        secondaryCameraScript.StartInteractionHub();
    }

    public void DisableInteractionText()
    {
        interactionText.gameObject.SetActive(false);
        secondaryCameraScript.ReturnToMainCamera(); 
    }

}
