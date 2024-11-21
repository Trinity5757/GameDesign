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

    // Start is called before the first frame update
    void Start()
    {
        _availableColors = new List<Color>(_wireColors);
        _availableleftwiresIndex = new List<int>();
        _availablerightwiresIndex = new List<int>();

        for (int i = 0; i < _leftwires.Count; i++)
        {
            _availableleftwiresIndex.Add(i);
        }
        for (int i = 0; i < _rightwires.Count; i++)
        {
            _availablerightwiresIndex.Add(i);
        }

        while (_availableColors.Count > 0 && _availableleftwiresIndex.Count > 0 && _availablerightwiresIndex.Count > 0)
        {
            Color pickedColor = _availableColors[Random.Range(0, _availableColors.Count)];
            int pickedLeftIndex = Random.Range(0, _availableleftwiresIndex.Count);
            int pickedRightIndex = Random.Range(0, _availablerightwiresIndex.Count);

            // Assign the picked color to the wires at the chosen indices
            _leftwires[_availableleftwiresIndex[pickedLeftIndex]].SetColor(pickedColor);
            _rightwires[_availablerightwiresIndex[pickedRightIndex]].SetColor(pickedColor);

            // Remove the color and wire indices from the available list
            _availableColors.Remove(pickedColor);
            _availableleftwiresIndex.RemoveAt(pickedLeftIndex);
            _availablerightwiresIndex.RemoveAt(pickedRightIndex);
        }
        StartCoroutine(CheckTaskCompletion());
    }
    private IEnumerator CheckTaskCompletion()
    {
        while(!IsTaskCompleted)
        {
            int successfulWires = 0;
            for(int i = 0; i < _rightwires.Count; i++)
            {
                if(_rightwires[i].IsSuccess)
                {
                    successfulWires++;
                }
            }
                if(successfulWires >= _rightwires.Count)
                {
                    Debug.Log("Task Completed");
                }
                else
                {
                    //Debug.Log("Task Failed");
                }
                yield return new WaitForSeconds(0.5f);
            }
        }
}
