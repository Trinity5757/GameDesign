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
            gameObject.SetActive(true);
            ShowNextDialogue();
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
        //dialogueBox.text = dialogueStack[currentIndex];
        StartCoroutine(ScrollingText(dialogueStack[currentIndex], 0.05f));
    }

    public void OnDeactivate()
    {
        gameObject.SetActive(false);
        currentIndex = -1;
    }

    private IEnumerator ScrollingText(string currentChunk, float pause)
    {
        int i = 0;
        dialogueBox.text = "";
        while (i < currentChunk.Length)
        {
            dialogueBox.text += currentChunk[i];
            i++;
            yield return new WaitForSecondsRealtime(pause);
        }
    }

}