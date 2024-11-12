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

    //Will update the game to check to see if it is paused 
    void Update()
    {
        if(Input.getKeyDown(KeyCode.Escape))
        {
            if(GameIsPaused)
            {
                ResumeGame();
            }
            else{
                PauseGame();
            }
        }
    }

    //Will allow the user to resume the game 
    public void ResumeGame()
    {
        pauseMenuUI.setActive(false);
        Time.timeScale = 1f;
        GameIsPaused = false;
    }

    //Will pause the game
        public void ResumeGame()
    {
        pauseMenuUI.setActive(true);
        Time.timeScale = 0f;
        GameIsPaused = true;
    }


    //Will have the user exit the game
    public void ExitGame()
    {
        Application.Quit();
    }

    // Input the name of the scene when I know what I am doing. 
    //Will return to the main menu 
    public void ResetGame()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene("MainMenu");
    }
}