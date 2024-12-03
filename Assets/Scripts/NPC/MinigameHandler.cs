using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MinigameHandler : MonoBehaviour
{
    public string firstMinigameSceneName = "WireMinigame";


    public void StartFirstMinigame()
    {
        // Lock movement of camera and controls
        Debug.Log("Starting first minigame :>");
        Cursor.lockState = CursorLockMode.None;
        SceneManager.LoadScene(firstMinigameSceneName, LoadSceneMode.Additive);
    }

    public void UnloadFirstMinigame()
    {
        SceneManager.UnloadSceneAsync(firstMinigameSceneName);
    }

    
}
