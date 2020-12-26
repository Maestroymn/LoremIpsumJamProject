using System;
using UnityEngine;

namespace InputSystem
{
    public class KeyboardJoystickListener : MonoBehaviour
    {
        public event Action JoystickRightTwo;
        public event Action JoystickLeftTwo;
        public event Action JoystickSouthButton;
        public event Action JoystickNorthButton;
        public event Action JoystickEastButton;
        public event Action JoystickWestButton;

        JoystickInputs joysticksInputs;

        public void Initialized(JoystickInputs input)
        {
            joysticksInputs = input;

            joysticksInputs.KeyboardJoystick.RightTwo.performed += ctx => RightTwoListener();
            joysticksInputs.KeyboardJoystick.RightTwo.canceled += ctx => RightTwoListener();

            joysticksInputs.KeyboardJoystick.LeftTwo.performed += ctx => LeftTwoListener();
            joysticksInputs.KeyboardJoystick.LeftTwo.canceled += ctx => LeftTwoListener();

            joysticksInputs.KeyboardJoystick.SouthButton.performed += ctx => SouthButtonListener();
            joysticksInputs.KeyboardJoystick.SouthButton.canceled += ctx => SouthButtonListener();

            joysticksInputs.KeyboardJoystick.NorthButton.performed += ctx => NorthButtonListener();
            joysticksInputs.KeyboardJoystick.NorthButton.canceled += ctx => NorthButtonListener();

            joysticksInputs.KeyboardJoystick.EastButton.performed += ctx => EastButtonListener();
            joysticksInputs.KeyboardJoystick.EastButton.canceled += ctx => EastButtonListener();

            joysticksInputs.KeyboardJoystick.WestButton.performed += ctx => WestButtonListener();
            joysticksInputs.KeyboardJoystick.WestButton.canceled += ctx => WestButtonListener();
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
    }
}
