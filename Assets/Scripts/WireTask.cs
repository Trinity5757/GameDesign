using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WireTask : MonoBehaviour
{

    public List<Color> _wireColors = new ListColor<Color>();
    public List<Color> _leftwires = new ListColor<Color>();
    public List<Color> _rightwires = new ListColor<Color>();

    private List<Color> _availableColors;

    private List<Int> _availableleftwiresIndex;
    private List<Int> _availablerightwiresIndex;
    // Start is called before the first frame update
    void Start()
    {
        _availableColors = new ListColors(_wiresColor);
        _availableleftwiresIndex = new List<Int>();
        _availablerightwiresIndex = new List<Int>();

        for(int i = 0; i < _leftwires.Count; i++)
        {
            _availableLeftwiresIndex.Add(i);
        }
        for(int i = 0; i < _rightwires.Count; i++)
        {
            _availableRightwiresIndex.Add(i);
        }
        while(_availableColors.Count > 0 && _availableLeftwiresIndex.Count > 0 && _availableRightwiresIndex.Count > 0)
        {
            Color pickedColor = _availableColors[Random.Range(0, _availableColors.Count)];
            int pickedLeftIndex = Random.Range(0, _availableleftwiresIndex);
            int pickedRightIndex = Random.Range(0, _availablerightwiresIndex); 

            _leftwires[_availableleftwiresIndex(pickedLeftIndex)].SetColor(pickedColor);
            _rightwires[_availablerightwiresIndex(pickedRightIndex)].SetColor(pickedColor);

            _availableColors.Remove(pickedColors);
            _availableleftwiresIndex.RemoveAt(pickedLeftIndex);
            _availablerightwiresIndex.RemoveAt(pickedRightIndex);
        }
    }
}
