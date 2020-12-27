using UnityEngine;
using System;
using UnityEngine.EventSystems;

public class MouseListener : MonoBehaviour, IPointerUpHandler, IPointerDownHandler
{
    public event Action<PointerEventData> LeftClick;
    public event Action<PointerEventData> RightClick;
    public event Action<PointerEventData> LeftClickDraggedUp;
    public event Action<PointerEventData> LeftClickDraggedDown;
    public event Action<PointerEventData> RightClickDraggedUp;
    public event Action<PointerEventData> RightClickDraggedDown;

    private float  lastMousePos;
    private float firstMousePos;
    private float targetPos;

    public void OnPointerDown(PointerEventData eventData)
    {
        firstMousePos = eventData.position.y;
        if (Input.GetMouseButtonDown(0))
        {
            LeftClick?.Invoke(eventData);
        }

        if (Input.GetMouseButtonDown(1))
        {
            RightClick?.Invoke(eventData);
        }
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        lastMousePos = eventData.position.y;
        targetPos = lastMousePos - firstMousePos;

        if (Input.GetMouseButtonUp(0) && targetPos > 0.0f)
        {
            LeftClickDraggedUp?.Invoke(eventData);
        }
        if (Input.GetMouseButtonUp(0) && targetPos < 0.0f)
        {
            LeftClickDraggedDown?.Invoke(eventData);
        }
        if (Input.GetMouseButtonUp(1) && targetPos > 0.0f)
        {
            RightClickDraggedUp?.Invoke(eventData);
        }
        if (Input.GetMouseButtonUp(1) && targetPos < 0.0f)
        {
            RightClickDraggedDown?.Invoke(eventData);
        }
    }
    
}
