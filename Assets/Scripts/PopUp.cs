using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PopUp : MonoBehaviour
{

    public GameObject popupPanel;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

        //Shows the Popup
    public void ShowPopup()
    {
        popupPanel.SetActive(true);
    }
    
    //Hides the Popup
    public void HidePopup()
    {
        popupPanel.SetActive(false);
    }
}
