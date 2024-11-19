using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnpoweredWireStats : MonoBehaviour
{
    public bool movable = false;
    public bool moving = false;
    public Vector3 startPosition;
    public WireType wire;
    public bool connected = false;
    public Vector3 connectedPosition;

    // Start is called before the first frame update
    void Start()
    {
        startPosition = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
