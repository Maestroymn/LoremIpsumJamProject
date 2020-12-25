using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class MouseJoystickListener : MonoBehaviour
{
    public static event Action JoystickRightOne;
    public static event Action JoystickLeftOne;
    public static event Action JoystickLeftDraggedUp;
    public static event Action JoystickLeftDraggedDown;
    public static event Action JoystickRightDraggedUp;
    public static event Action JoystickRightDraggedDown;

    JoystickInputs joystickInputs;

    private void Awake()
    {
        joystickInputs = new JoystickInputs();

        joystickInputs.MouseJoystick.RightOne.performed += ctx => RightOneListener();
        joystickInputs.MouseJoystick.LeftOne.performed += ctx => LeftOneListener();

        joystickInputs.MouseJoystick.RightStickUp.performed += ctx => DraggedUpListener();
        joystickInputs.MouseJoystick.RightStickDown.performed += ctx => DraggedDownListener();
    }

    private void RightOneListener()
    {
        if (joystickInputs.MouseJoystick.RightOne.triggered)
        {
            Debug.Log("Right One");
            JoystickRightOne?.Invoke();
        }
    }

    private void LeftOneListener()
    {
        if (joystickInputs.MouseJoystick.LeftOne.triggered)
        {
            Debug.Log("Left ONe");
            JoystickLeftOne?.Invoke();
        }
    }

    private void DraggedUpListener()
    {
        if (joystickInputs.MouseJoystick.LeftOne.triggered && joystickInputs.MouseJoystick.RightStickUp.triggered)
        {
            Debug.Log("Left ONe Dragged Up");
            JoystickLeftDraggedUp?.Invoke();
        }

        if (joystickInputs.MouseJoystick.RightOne.triggered && joystickInputs.MouseJoystick.RightStickUp.triggered)
        {
            Debug.Log("Right One Dragged Up");
            JoystickRightDraggedUp?.Invoke();
        }
    }

    private void DraggedDownListener()
    {
        if (joystickInputs.MouseJoystick.LeftOne.triggered && joystickInputs.MouseJoystick.RightStickDown.triggered)
        {
            Debug.Log("Left One Dragged Down");
            JoystickLeftDraggedDown?.Invoke();
        }

        if (joystickInputs.MouseJoystick.RightOne.triggered && joystickInputs.MouseJoystick.RightStickDown.triggered)
        {
            Debug.Log("Right One Dragged Down");
            JoystickRightDraggedDown?.Invoke();
        }
    }

    private void OnEnable()
    {
        joystickInputs.MouseJoystick.Enable();
    }

    private void OnDisable()
    {
        joystickInputs.MouseJoystick.Disable();
    }
}
