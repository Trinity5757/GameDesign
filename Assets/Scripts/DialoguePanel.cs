using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class DialoguePanel : MonoBehaviour
{
    // TODO: Make dialogue text scroll over time

    public TextMeshProUGUI dialogueBox;

    public string speakerName;

    public List<string> dialogueStack;
    public int currentIndex; // index of the current dialogue chunk that is loaded.

    public void OnActivate()
    {
        if (this.gameObject.activeInHierarchy) { return; }
        ShowNextDialogue();
        gameObject.SetActive(true);
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (dialogueStack.Count >= currentIndex + 1)
            {
                ShowNextDialogue();
            }
            else
            {
                OnDeactivate();
            }
        }

    }

    private void ShowNextDialogue()
    {
        currentIndex++;
        if (dialogueStack.Count >= currentIndex)
        {

            dialogueBox.text = dialogueStack[currentIndex];
        }
    }

    public void OnDeactivate()
    {
        gameObject.SetActive(false);
        currentIndex = -1;
    }

}