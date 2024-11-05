using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialoguePanel : MonoBehaviour
{
    // TODO: Make dialogue text scroll over time

    public string speakerName;

    public List<string> dialogueStack;

    public void OnActivate()
    {
        if (this.gameObject.activeInHierarchy) { return; }

        gameObject.SetActive(true);
        while (dialogueStack.Count > 0)
        {
            gameObject.SetActive(true);
        }
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space)) 
        {
            Debug.Log("Pressed");
            OnDeactivate();
        }
    }

    public void OnDeactivate()
    {
        gameObject.SetActive(false);
    }

}
