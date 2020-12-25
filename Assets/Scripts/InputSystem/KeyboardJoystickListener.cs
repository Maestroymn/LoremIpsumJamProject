using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeyboardJoystickListener : MonoBehaviour
{
    public static event Action JoystickRightTwo;
    public static event Action JoystickLeftTwo;
    public static event Action JoystickSouthButton;
    public static event Action JoystickNorthButton;
    public static event Action JoystickEastButton;
    public static event Action JoystickWestButton;

    JoystickInputs joysticksInputs;

    private void Awake()
    {
        joysticksInputs = new JoystickInputs();

        joysticksInputs.KeyboardJoystick.RightTwo.performed += ctx => RightTwoListener();
        joysticksInputs.KeyboardJoystick.LeftTwo.performed += ctx => LeftTwoListener();
        joysticksInputs.KeyboardJoystick.SouthButton.performed += ctx => SouthButtonListener();
        joysticksInputs.KeyboardJoystick.NorthButton.performed += ctx => NorthButtonListener();
        joysticksInputs.KeyboardJoystick.EastButton.performed += ctx => EastButtonListener();
        joysticksInputs.KeyboardJoystick.WestButton.performed += ctx => WestButtonListener();
    }

    private void RightTwoListener()
    {
        if (joysticksInputs.KeyboardJoystick.RightTwo.triggered)
        {
            Debug.Log("Right Two");
            JoystickRightTwo?.Invoke();
        }
    }

    private void LeftTwoListener()
    {
        if (joysticksInputs.KeyboardJoystick.LeftTwo.triggered)
        {
            Debug.Log("Left Two");
            JoystickLeftTwo?.Invoke();
        }
    }

    private void SouthButtonListener()
    {
        if (joysticksInputs.KeyboardJoystick.SouthButton.triggered)
        {
            Debug.Log("South Button");
            JoystickSouthButton?.Invoke();
        }
    }

    private void NorthButtonListener()
    {
        if (joysticksInputs.KeyboardJoystick.NorthButton.triggered)
        {
            Debug.Log("North Button");
            JoystickNorthButton?.Invoke();
        }
    }

    private void EastButtonListener()
    {
        if (joysticksInputs.KeyboardJoystick.EastButton.triggered)
        {
            Debug.Log("East Button");
            JoystickEastButton?.Invoke();
        }
    }

    private void WestButtonListener()
    {
        if (joysticksInputs.KeyboardJoystick.WestButton.triggered)
        {
            Debug.Log("West Button");
            JoystickWestButton?.Invoke();
        }
    }

    private void OnEnable()
    {
        joysticksInputs.KeyboardJoystick.Enable();
    }

    private void OnDisable()
    {
        joysticksInputs.KeyboardJoystick.Disable();
    }
}
