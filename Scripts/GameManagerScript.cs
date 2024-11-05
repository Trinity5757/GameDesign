using UnityEngine;

public class GameManager : MonoBehaviour
{
    public void StartGame()
    {

    }

    public void StopGame()
    {

    }
    // Input the name of the scene when I know what I am doing. 
    public void ResetGame()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene(UnityEngine.SceneManagement.SceneManager.GetActiveScene().name);
    }
}