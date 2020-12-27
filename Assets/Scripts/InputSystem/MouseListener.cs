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
            Debug.Log("Left Click");
            LeftClick?.Invoke(eventData);
        }

        if (Input.GetMouseButtonDown(1))
        {
            Debug.Log("Right Click");
            RightClick?.Invoke(eventData);
        }
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        lastMousePos = eventData.position.y;
        targetPos = lastMousePos - firstMousePos;

        if (Input.GetMouseButtonUp(0) && targetPos > 0.0f)
        {
            Debug.Log("Drag Up Left ");
            LeftClickDraggedUp?.Invoke(eventData);
        }
        if (Input.GetMouseButtonUp(0) && targetPos < 0.0f)
        {
            Debug.Log("Drag Down Left");
            LeftClickDraggedDown?.Invoke(eventData);
        }
        if (Input.GetMouseButtonUp(1) && targetPos > 0.0f)
        {
            Debug.Log("Drag up Right");
            RightClickDraggedUp?.Invoke(eventData);
        }
        if (Input.GetMouseButtonUp(1) && targetPos < 0.0f)
        {
            Debug.Log("Drag Down Right");
            RightClickDraggedDown?.Invoke(eventData);
        }
    }
    
}
