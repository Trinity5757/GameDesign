using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;

public class CastingScript : MonoBehaviour
{
    public Image targetArea;
    public Transform targetStartPosition;
    public Transform targetEndPosition;
    private bool isButtonHeld = false;
    private Vector3 targetPosition;
    private int wins = 0;

    public GameObject bubbleObject;
    private float castSize;

    public GameObject winPopup;
    public GameObject lossPopup;

    public Button restartButton;
    public Button quitButton;
    public Button nextButton;

    public float difficultyIncrease = 0.1f;
    private float targetAreaWidth;

    void Start()
    {
        castSize = PlayerPrefs.GetFloat("CastSize", 2.0f);
        targetAreaWidth = targetArea.rectTransform.rect.width;
        SetupNewRound();
    }

    void Update()
    {
        if (Input.GetMouseButton(0))
        {
            if (!isButtonHeld)
            {
                isButtonHeld = true;
            }

            // Move the target area position
            targetPosition = Vector3.Lerp(targetStartPosition.position, targetEndPosition.position, Mathf.PingPong(Time.time * (1 + wins * 0.1f), 1));
            targetArea.transform.position = targetPosition;

            // Adjust bubble size dynamically
            AdjustBubbleSize();
        }
        else if (isButtonHeld)
        {
            EndGame(CheckReleasePosition());
            isButtonHeld = false;
        }
    }

    void AdjustBubbleSize()
    {
        float bubbleScale = Mathf.Lerp(1.0f, castSize, Mathf.PingPong(Time.time, 1.0f));
        bubbleObject.transform.localScale = Vector3.one * bubbleScale;
    }

    bool CheckReleasePosition()
    {
        float targetAreaX = targetArea.transform.position.x;
        return Mathf.Abs(targetAreaX - targetEndPosition.position.x) < targetAreaWidth * 0.5f;
    }

    void EndGame(bool success)
    {
        if (success)
        {
            wins++;
            ShowWinPopup();
        }
        else
        {
            wins = 0;
            ShowLossPopup();
        }
    }

    void ShowLossPopup()
    {
        Debug.Log("Loss Popup Triggered");
        lossPopup.SetActive(true);

        // Clear existing listeners and add new ones
        restartButton.onClick.RemoveAllListeners();
        restartButton.onClick.AddListener(SetupNewRound);

        quitButton.onClick.RemoveAllListeners();
        quitButton.onClick.AddListener(LoadPreviousScene);
    }

    void ShowWinPopup()
    {
        winPopup.SetActive(true);

        // Adjust target area size for dynamic difficulty
        AdjustTargetAreaSize();

        // Clear existing listeners and add new ones
        nextButton.onClick.RemoveAllListeners();
        nextButton.onClick.AddListener(LoadNextScene);
    }

    void LoadPreviousScene()
    {
        SceneManager.LoadScene("SampleScene");
    }

    void LoadNextScene()
    {
        SceneManager.LoadScene("WireMiniGame");
    }

    void AdjustTargetAreaSize()
    {
        targetAreaWidth += difficultyIncrease * 100f; // Gradually increase target area width
        targetArea.rectTransform.sizeDelta = new Vector2(targetAreaWidth, targetArea.rectTransform.sizeDelta.y);
    }

    void SetupNewRound()
    {
        // Reset target area size and bubble size
        targetAreaWidth = 100f;
        targetArea.rectTransform.sizeDelta = new Vector2(targetAreaWidth, targetArea.rectTransform.sizeDelta.y);

        bubbleObject.transform.localScale = Vector3.one;
        winPopup.SetActive(false);
        lossPopup.SetActive(false);
        targetPosition = targetStartPosition.position;
    }
}