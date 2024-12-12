using UnityEngine;

public class MiniGame : MonoBehaviour
{
    public delegate void MiniGameComplete();
    public delegate void MiniGameExit();
    public event MiniGameComplete OnMiniGameComplete;
    public event MiniGameExit OnMiniGameExit;

    public void CompleteMiniGame()
    {
        Debug.Log("Mini-game completed!");
        OnMiniGameComplete?.Invoke(); // Notify manager
        gameObject.SetActive(false);
    }

    public void ExitMiniGame()
    {
        Debug.Log("Mini Game Aborted!");
        OnMiniGameExit?.Invoke();
        gameObject.SetActive(false);
    }
    
    
}