using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
    
public class UINavigation : MonoBehaviour
{
     public void ChangeSelectedButton(Button newButton)
     {
         // UI navigation for M&K or Controller is Wonky, this sets the 
         //selected button to whatever we want to not lose controller nav.
         EventSystem.current.SetSelectedGameObject(newButton.gameObject);
     }

     public void KeepSelectedButton()
     {
         var currentButton = EventSystem.current.currentSelectedGameObject?.GetComponent<Button>();
         EventSystem.current.SetSelectedGameObject(currentButton.gameObject);       

     }
    
}
