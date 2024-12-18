using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;


public class Wire : MonoBehaviour, IDragHandler, IBeginDragHandler, IEndDragHandler
{
    public bool IsLeftWire;
    public Color CustomColor;

    private Image _image;
    private LineRenderer _lineRenderer;

    private Canvas _canvas;
    private bool _isDragStarted = false;
    private WireTask _wireTask;
    public bool IsSuccess = false;

    //Adding an Audio Component
    private AudioManager audioManager;

    private void Awake()
    {
        _image = GetComponent<Image>();
        _lineRenderer = GetComponent<LineRenderer>();
        _canvas = GetComponentInParent<Canvas>();
        _wireTask = GetComponentInParent<WireTask>();
        audioManager = FindObjectOfType<AudioManager>();
    }

    private void Update()
    {
        if (_isDragStarted)
        {
            Vector2 movePos;
            RectTransformUtility.ScreenPointToLocalPointInRectangle(
    _canvas.transform as RectTransform,
    Input.mousePosition,
    _canvas.worldCamera,
    out movePos
);

            _lineRenderer.SetPosition(0, transform.position);
            _lineRenderer.SetPosition(1, _canvas.transform.TransformPoint(movePos));
        }
        else
        {
            if (!IsSuccess)
            {
                _lineRenderer.SetPosition(0, Vector3.zero);
                _lineRenderer.SetPosition(1, Vector3.zero);
            }
        }
        bool isHovered = RectTransformUtility.RectangleContainsScreenPoint(transform as RectTransform, Input.mousePosition, _canvas.worldCamera);
        if (isHovered)
        {
            _wireTask.CurrentHoveredWire = this;
        }
    }

    public void SetColor(Color color)
    {
        color.a = 1;
        _image.color = color;
        _lineRenderer.startColor = color;
        _lineRenderer.endColor = color;
        CustomColor = color;
    }

    public void OnDrag(PointerEventData eventData) { }

    public void OnBeginDrag(PointerEventData eventData)
    {
        if (!IsLeftWire)
        {
            return;
        }
        if (IsSuccess)
        {
            return;
        }
        Debug.Log("Dragging " + this.gameObject.name);
        _isDragStarted = true;
        _wireTask.CurrentDraggedWire = this;
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        if (_wireTask.CurrentHoveredWire.CustomColor == CustomColor && !_wireTask.CurrentHoveredWire.IsLeftWire)
        {
            {
                IsSuccess = true;
                _wireTask.CurrentHoveredWire.IsSuccess = true;
                Debug.Log("Wire successfully connected!");
                audioManager.PlayClickSound();
            }
        }
        Debug.Log("Drag Cancelled");
        _isDragStarted = false;
        _wireTask.CurrentDraggedWire = null;
    }
    
    public void ResetWire()
    {
        // Reset the success state
        IsSuccess = false;

        // Clear the LineRenderer positions
        if (_lineRenderer != null)
        {
            _lineRenderer.SetPosition(0, Vector3.zero);
            _lineRenderer.SetPosition(1, Vector3.zero);
        }

        // Reset the wire's color to transparent or a default color
        Color defaultColor = new Color(1, 1, 1, 0); // Transparent white
        SetColor(defaultColor);

        // Reset drag state
        _isDragStarted = false;
    }
}
