using System.Collections.Generic;
using UnityEngine;

public class MiniGameManager : MonoBehaviour
{
    public List<GameObject> miniGames; // List of mini-game prefabs
    private int currentMiniGameIndex = 0;
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
            }

            // Activate the next mini-game
            currentMiniGameInstance = miniGames[currentMiniGameIndex];
            currentMiniGameInstance.SetActive(true);


            // Attach callback to the mini-game's completion
            MiniGame miniGameLogic = currentMiniGameInstance.GetComponent<MiniGame>();
            if (miniGameLogic != null)
            {
                miniGameLogic.OnMiniGameComplete += HandleMiniGameCompletion;
            }
            else
            {
                Debug.Log("mini game logic null");
            }
        }
        else
        {
            Debug.Log("All mini-games completed!");
            finishingUI.SetActive(true);
            currentMiniGameIndex = 0; //if we finish, restart the index.
        }
    }

    private void HandleMiniGameCompletion()
    {
        // Move to the next mini-game
        currentMiniGameIndex++;
        StartNextMiniGame();
    }
}
