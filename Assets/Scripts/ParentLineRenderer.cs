using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParentLineRenderer : MonoBehaviour
{
    private LineRenderer lineRenderer;
    public Transform startPosition;
    public Transform endPosition;
    // Start is called before the first frame update
    void Start()
    {
        lineRenderer = GetComponent<LineRenderer>();
        if (lineRenderer == null)
        {
            lineRenderer = gameObject.AddComponent<LineRenderer>();
        }
        lineRenderer.startWidth = 0.1f;
        lineRenderer.endWidth = 0.1f;
        lineRenderer.positionCount = 2;
    }

    // Update is called once per frame
    void Update()
    {
        if (startPosition != null && endPosition != null)
        {
            lineRenderer.SetPosition(0, startPosition.position);
            lineRenderer.SetPosition(1, endPosition.position);
        }

    }
}
