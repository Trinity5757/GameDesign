using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    private int score;
    private boolean passed;

    public void UpdateScore(int amount)
    {
        score += amount;
        if (score > 50)
        {
            passed = true;
        }
        else
        {
            passed = false;
        }
    }
}