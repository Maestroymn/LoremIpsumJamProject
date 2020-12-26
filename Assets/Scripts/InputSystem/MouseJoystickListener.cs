using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class MouseJoystickListener : MonoBehaviour
{
    public event Action JoystickRightOne;
    public event Action JoystickLeftOne;
    public event Action JoystickLeftDraggedUp;
    public event Action JoystickLeftDraggedDown;
    public event Action JoystickRightDraggedUp;
    public event Action JoystickRightDraggedDown;

    //JoystickInputs joystickInputs;

    private float stickVertical;

    //public void Initialized()
    //{
    //    //joystickInputs = input;

    //    //joystickInputs.MouseJoystick.RightOne.performed += ctx => RightOneListener();
    //    //joystickInputs.MouseJoystick.RightOne.canceled += ctx => RightOneListener();

    //    //joystickInputs.MouseJoystick.LeftOne.performed += ctx => LeftOneListener();
    //    //joystickInputs.MouseJoystick.LeftOne.canceled += ctx => LeftOneListener();

    //    //joystickInputs.MouseJoystick.RightStickUp.performed += ctx => DraggedUpListener();
    //    //joystickInputs.MouseJoystick.RightStickUp.canceled += ctx => DraggedUpListener();

    //    //joystickInputs.MouseJoystick.RightStickDown.performed += ctx => DraggedDownListener();
    //    //joystickInputs.MouseJoystick.RightStickDown.canceled += ctx => DraggedDownListener();
    //}

    private void Update()
    {
        RightButtonListener();
        LeftButtonListener();
        DraggedUpListener();
        DraggedDownListener();
    }

    private void RightButtonListener()
    {
        if (Input.GetButton("RB2"))
        {
            Debug.Log("Right Button");
            JoystickRightOne?.Invoke();
        }
    }

    private void LeftButtonListener()
    {
        if (Input.GetButton("LB2"))
        {
            Debug.Log("Left Button");
            JoystickLeftOne?.Invoke();
        }
    }
    
    private void DraggedUpListener()
    {
        stickVertical = Input.GetAxisRaw("RStickVertical2");
        if (Input.GetButton("LB2") && stickVertical > 0.0f)
        {
            Debug.Log("Left ONe Dragged Up");
            JoystickLeftDraggedUp?.Invoke();
        }

        if (Input.GetButton("RB2") && stickVertical > 0.0f)
        {
            Debug.Log("Right One Dragged Up");
            JoystickRightDraggedUp?.Invoke();
        }
    }

    private void DraggedDownListener()
    {
        stickVertical = Input.GetAxisRaw("RStickVertical2");
        if (Input.GetButton("LB2") && stickVertical < 0.0f)
        {
            Debug.Log("Left One Dragged Down");
            JoystickLeftDraggedDown?.Invoke();
        }

        if (Input.GetButton("RB2") && stickVertical < 0.0f)
        {
            Debug.Log("Right One Dragged Down");
            JoystickRightDraggedDown?.Invoke();
        }
    }

}
