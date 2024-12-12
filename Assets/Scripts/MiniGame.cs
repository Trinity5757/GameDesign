using UnityEngine;

public class MiniGame : MonoBehaviour
{
    public delegate void MiniGameComplete();
    public event MiniGameComplete OnMiniGameComplete;

    public void CompleteMiniGame()
    {
        Debug.Log("Mini-game completed!");
        OnMiniGameComplete?.Invoke(); // Notify manager
        gameObject.SetActive(false);
    }
}