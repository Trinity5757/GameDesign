using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class DialoguePanel : MonoBehaviour
{
    // TODO: Make dialogue text scroll over time
    public TextMeshProUGUI speakerNameBox;
    public TextMeshProUGUI dialogueBox;

    public string speakerName;

    public List<string> dialogueStack;
    public int currentIndex; // index of the current dialogue chunk that is loaded.

    public void OnActivate()
    {
        if (this.gameObject.activeInHierarchy) { return; }
        ++currentIndex;
        if (currentIndex < dialogueStack.Count)
        {
            speakerNameBox.text = speakerName;
            ShowNextDialogue();
            gameObject.SetActive(true);
        }

    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            ++currentIndex;
            if (currentIndex < dialogueStack.Count)
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
        dialogueBox.text = dialogueStack[currentIndex];
    }

    public void OnDeactivate()
    {
        gameObject.SetActive(false);
        currentIndex = -1;
    }

}