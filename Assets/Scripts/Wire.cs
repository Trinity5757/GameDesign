using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wire : MonoBehaviour
{
    private Image _image;
    
    private void Awake()
    {
        _image = getComponent<Image>();
    }

    public void SetColor(Color color)
    {
        _image.color = color;
    }
}
