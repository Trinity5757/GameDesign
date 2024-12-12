using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    public static bool GameIsPaused = false;
    public GameObject pauseMenuUI;
    private MaterialData _materialData;

    public SecondaryCamera secondaryCameraScript;

    // Will update the game to check to see if it is paused 
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (GameIsPaused)
            {
                ResumeGame();
            }
            else
            {
                PauseGame();
            }
        }
    }

    // Will allow the user to resume the game 
    public void ResumeGame()
    {
        pauseMenuUI.SetActive(false);
        Time.timeScale = 1f;
        GameIsPaused = false;
        AudioListener.pause = false;

        // Hide and lock the cursor for gameplay
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;

        secondaryCameraScript.ReturnToMainCamera();
    }

    // Will pause the game
    public void PauseGame()
    {
        pauseMenuUI.SetActive(true);
        Time.timeScale = 0f;
        GameIsPaused = true;
        AudioListener.pause = true;

        // Unlock and show the cursor for UI interaction
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;

        secondaryCameraScript.StartPauseMenu();
    }

    public void Save()
    {
        _materialData = Inventory.Instance.GetMaterialData();
        SaveData.Save(_materialData);
    }

    // Input the name of the scene when I know what I am doing. 
    // Will return to the main menu 
    public void ExitToMainMenu()
    {
        Time.timeScale = 1f;
        Save();
        SceneManager.LoadScene(0);
    }
}