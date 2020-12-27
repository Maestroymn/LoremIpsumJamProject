using UnityEngine;
using System;
using UnityEngine.EventSystems;

public class MouseListener : MonoBehaviour, IDragHandler, IPointerDownHandler
{
    public event Action<PointerEventData> LeftClick;
    public event Action<PointerEventData> RightClick;
    public event Action<PointerEventData> LeftClickDraggedUp;
    public event Action<PointerEventData> LeftClickDraggedDown;
    public event Action<PointerEventData> RightClickDraggedUp;
    public event Action<PointerEventData> RightClickDraggedDown;

    private float  lastMousePos;

    public void OnPointerDown(PointerEventData eventData)
    {
        if (Input.GetMouseButtonDown(0))
        {
            LeftClick?.Invoke(eventData);
        }

        if (Input.GetMouseButtonDown(1))
        {
            RightClick?.Invoke(eventData);
        }
    }

    public void OnDrag(PointerEventData eventData)
    {
        lastMousePos = eventData.position.y - eventData.pressPosition.y;

        if (Input.GetMouseButton(0) && lastMousePos > 0.0f)
        {
            LeftClickDraggedUp?.Invoke(eventData);
        }
        if (Input.GetMouseButton(0) && lastMousePos < 0.0f)
        {
            LeftClickDraggedDown?.Invoke(eventData);
        }
        if (Input.GetMouseButton(1) && lastMousePos > 0.0f)
        {
            RightClickDraggedUp?.Invoke(eventData);
        }
        if (Input.GetMouseButton(1) && lastMousePos < 0.0f)
        {
            RightClickDraggedDown?.Invoke(eventData);
        }
    }
    
}
