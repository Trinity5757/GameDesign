using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WireTask : MonoBehaviour
{

    public List<Color> _wireColors = new List<Color>();
    public List<Wire> _leftwires = new List<Wire>();
    public List<Wire> _rightwires = new List<Wire>();

    private List<Color> _availableColors;

    private List<int> _availableleftwiresIndex;
    private List<int> _availablerightwiresIndex;
    // Start is called before the first frame update
    void Start()
    {
        _availableColors = new List<Color>(_wireColors);
        _availableleftwiresIndex = new List<int>();
        _availablerightwiresIndex = new List<int>();

        for(int i = 0; i < _leftwires.Count; i++)
        {
            _availableleftwiresIndex.Add(i);
        }
        for(int i = 0; i < _rightwires.Count; i++)
        {
            _availablerightwiresIndex.Add(i);
        }
        while(_availableColors.Count > 0 && _availableleftwiresIndex.Count > 0 && _availablerightwiresIndex.Count > 0)
        {
            Color pickedColor = _availableColors[Random.Range(0, _availableColors.Count)];
            int pickedLeftIndex = Random.Range(0, _availableleftwiresIndex.Count);
            int pickedRightIndex = Random.Range(0, _availablerightwiresIndex.Count); 

            _leftwires[_availableleftwiresIndex(pickedLeftIndex)].SetColor(pickedColor);
            _rightwires[_availablerightwiresIndex(pickedRightIndex)].SetColor(pickedColor);

            _availableColors.Remove(pickedColors);
            _availableleftwiresIndex.RemoveAt(pickedLeftIndex);
            _availablerightwiresIndex.RemoveAt(pickedRightIndex);
        }
    }
}
