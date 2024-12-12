using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WireTask : MonoBehaviour
{
    public List<Color> _wireColors = new List<Color>();
    public List<Wire> _leftwires = new List<Wire>();
    public List<Wire> _rightwires = new List<Wire>();

    public Wire CurrentDraggedWire;
    public Wire CurrentHoveredWire;

    public bool IsTaskCompleted = false;

    private List<Color> _availableColors;
    private List<int> _availableleftwiresIndex;
    private List<int> _availablerightwiresIndex;

    //Adding an Audio Component
    private AudioManager audioManager;

    private MiniGame _miniGame;

    // Start is called before the first frame update
    void Start()
    {
        InitializeTask();
        audioManager = FindObjectOfType<AudioManager>();
    }

    private void InitializeTask()
    {
        Debug.Log("Starting Initialize task...");
        _miniGame = GetComponentInParent<MiniGame>();

        IsTaskCompleted = false;

        _availableColors = new List<Color>(_wireColors);
        _availableleftwiresIndex = new List<int>();
        _availablerightwiresIndex = new List<int>();

        for (int i = 0; i < _leftwires.Count; i++)
        {
            _availableleftwiresIndex.Add(i);
            _leftwires[i].ResetWire(); // Reset each left wire
        }
        for (int i = 0; i < _rightwires.Count; i++)
        {
            _availablerightwiresIndex.Add(i);
            _rightwires[i].ResetWire(); // Reset each right wire
        }

        // Assign colors to wires after resetting them
        while (_availableColors.Count > 0 && _availableleftwiresIndex.Count > 0 && _availablerightwiresIndex.Count > 0)
        {
            Color pickedColor = _availableColors[Random.Range(0, _availableColors.Count)];
            int pickedLeftIndex = Random.Range(0, _availableleftwiresIndex.Count);
            int pickedRightIndex = Random.Range(0, _availablerightwiresIndex.Count);

            _leftwires[_availableleftwiresIndex[pickedLeftIndex]].SetColor(pickedColor);
            _rightwires[_availablerightwiresIndex[pickedRightIndex]].SetColor(pickedColor);

            _availableColors.Remove(pickedColor);
            _availableleftwiresIndex.RemoveAt(pickedLeftIndex);
            _availablerightwiresIndex.RemoveAt(pickedRightIndex);
        }
        Debug.Log("Ending Initialize task...");
        Debug.Log("Starting coroutine...");
        StartCoroutine(CheckTaskCompletion());
    }

    private IEnumerator CheckTaskCompletion()
    {
        Debug.Log("Layer zero");
        while (!IsTaskCompleted)
        {
            int successfulWires = 0;
            
            Debug.Log("Stuff is happening");
            
            for (int i = 0; i < _rightwires.Count; i++)
            {
                //Debug.Log("Stuff is happening");
                if (_rightwires[i].IsSuccess)
                {
                    successfulWires++;
                    Debug.Log("succwires: " + successfulWires);
                }
            }
            
            if (successfulWires >= _rightwires.Count)
            {
                Debug.Log("Task Completed");
                IsTaskCompleted = true;
                audioManager.PlayWinNoise();
                
                ResetTask(); // Reset the task after completion
                
                if (_miniGame != null)
                {
                    _miniGame.CompleteMiniGame();
                }
                else
                {
                    Debug.Log("Ain't No mini game here.");
                }
                
                
            }
            yield return new WaitForSecondsRealtime(1f);
        }
    }

    public void ResetTask()
    {
           IsTaskCompleted = false;
           StopCoroutine(CheckTaskCompletion()); // Stop active coroutines
           IsTaskCompleted = false;
        
            foreach (Wire wire in _leftwires)
            {
                wire.ResetWire(); // Reset each left wire
            }
            foreach (Wire wire in _rightwires)
            {
                wire.ResetWire(); // Reset each right wire
            }

            IsTaskCompleted = false; // Reset task completion flag
        

        // Reinitialize the task
        InitializeTask();
        Debug.Log("Calling initialize task...");
        Debug.Log("Starting coroutine...");
        StartCoroutine(CheckTaskCompletion());
    }
}
