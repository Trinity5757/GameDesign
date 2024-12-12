using System.Collections.Generic;
using UnityEngine;

public class MiniGameManager : MonoBehaviour
{
    public List<GameObject> miniGames; // List of mini-game prefabs
    public int currentMiniGameIndex = 0;
    private GameObject currentMiniGameInstance;

    public GameObject confirmationUI; // Confirmation UI
    public GameObject finishingUI;

    private void Start()
    {
        // Ensure all mini-games are inactive initially
        foreach (GameObject miniGame in miniGames)
        {
            miniGame.SetActive(false);
        }

        if (confirmationUI != null)
        {
            confirmationUI.SetActive(false); // Hide confirmation UI initially
            finishingUI.SetActive(false);
        }
    }

    public void InteractWithWorkbench()
    {
        // Show confirmation UI
        if (confirmationUI == null) return;

        Time.timeScale = 0f;

        // Unlock and show the cursor for UI interaction
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
        confirmationUI.SetActive(true);
    }

    public void ExitWorkbench()
    {
        Time.timeScale = 1f;

        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;

        currentMiniGameIndex = 0;
        Debug.Log("current mini game index: " + currentMiniGameIndex);
        confirmationUI.SetActive(false);
        finishingUI.SetActive(false);
    }

    public void StartMiniGameSequence()
    {
        if (confirmationUI != null)
        {
            confirmationUI.SetActive(false); // Hide confirmation UI
        }
        
        currentMiniGameIndex = 0; //if we quit restart the index

        StartNextMiniGame();
    }

    private void StartNextMiniGame()
    {
        if (currentMiniGameIndex < miniGames.Count)
        {
            // Deactivate any previous mini-game
            if (currentMiniGameInstance != null)
            {
                currentMiniGameInstance.SetActive(false);
                MiniGame previousMiniGameLogic = currentMiniGameInstance.GetComponent<MiniGame>();
                if (previousMiniGameLogic != null)
                {
                    // Unsubscribe previous handlers
                    previousMiniGameLogic.OnMiniGameComplete -= HandleMiniGameCompletion;
                    previousMiniGameLogic.OnMiniGameExit -= HandleMiniGameExit;
                }
            }

            // Activate the next mini-game
            currentMiniGameInstance = miniGames[currentMiniGameIndex];
            currentMiniGameInstance.SetActive(true);

            // Attach callbacks to the mini-game
            MiniGame miniGameLogic = currentMiniGameInstance.GetComponent<MiniGame>();
            if (miniGameLogic != null)
            {
                // Subscribe new handlers
                miniGameLogic.OnMiniGameComplete += HandleMiniGameCompletion;
                miniGameLogic.OnMiniGameExit += HandleMiniGameExit;
            }
            else
            {
                Debug.Log("MiniGame logic is null!");
            }
        }
        else
        {
            Debug.Log("All mini-games completed!");
            finishingUI.SetActive(true);
            currentMiniGameIndex = 0; // Reset the index for future playthroughs
        }
    }


    private void HandleMiniGameCompletion()
    {
        // Move to the next mini-game
        currentMiniGameIndex++;
        Debug.Log("Delegate MiniGameCompletion called. Current index: " + currentMiniGameIndex);

        StartNextMiniGame();
    }

    private void HandleMiniGameExit()
    {
        Debug.Log("Mini-game exited!");
        ExitWorkbench();
    }
}
