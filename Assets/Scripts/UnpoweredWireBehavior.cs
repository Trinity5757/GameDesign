using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnpoweredWireBehavior : MonoBehaviour
{
    public bool connected = false;
    public WireType wire; // Use WireType directly
    private UnpoweredWireStats unpoweredWireStats;

    // Start is called before the first frame update
    void Start()
    {
        unpoweredWireStats = gameObject.GetComponent<UnpoweredWireStats>(); // Ensure this component is added
    }

    // Update is called once per frame
    void Update()
    {
        if (unpoweredWireStats.connected) // Access connected from UnpoweredWireStats
        {
            unpoweredWireStats.GetComponent<Renderer>().material.color = Color.green;
        }
        else
        {
            unpoweredWireStats.GetComponent<Renderer>().material.color = Color.red;
        }
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.GetComponent<WireStats>())
        {
            WireStats wireStats = collision.GetComponent<WireStats>();
            if (wireStats != null && wireStats.GetComponent<UnpoweredWireStats>() == unpoweredWireStats) 
            {
                // Set connection state for both wires
                unpoweredWireStats.connected = true;
                wireStats.GetComponent<UnpoweredWireStats>().connected = true;
                wireStats.GetComponent<WireStats>().connectedPosition = gameObject.transform.position;
            }
        }
    }

    void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.GetComponent<WireStats>())
        {
            WireStats wireStats = collision.GetComponent<WireStats>();
            if (wireStats != null && wireStats.GetComponent<UnpoweredWireStats>() == unpoweredWireStats)
            {
                // Disconnect the wires
                unpoweredWireStats.connected = false;
                wireStats.GetComponent<UnpoweredWireStats>().connected = false;
                wireStats.GetComponent<WireStats>().connectedPosition = gameObject.transform.position;
            }
        }
    }
}
