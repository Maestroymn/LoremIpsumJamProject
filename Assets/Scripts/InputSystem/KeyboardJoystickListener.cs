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
        

        private void Update()
        {
            RightTriggerListener();
            LeftTriggerListener();
            SouthButtonListener();
            NorthButtonListener();
            EastButtonListener();
            WestButtonListener();
        }

        private void RightTriggerListener()
        {
            if (Input.GetAxisRaw("RT1") > 0.0f)
            {
                Debug.Log("Right Trigger");
                JoystickRightTwo?.Invoke();
            }
        }

        private void LeftTriggerListener()
        {
            if (Input.GetAxisRaw("LT1") > 0.0f)
            {
                Debug.Log("Left Trigger");
                JoystickLeftTwo?.Invoke();
            }
        }
        private void SouthButtonListener()
        {
            if (Input.GetButton("SouthButton1"))
            {
                Debug.Log("South Button");
                JoystickSouthButton?.Invoke();
            }
        }
        private void NorthButtonListener()
        {
            if (Input.GetButton("NorthButton1"))
            {
                Debug.Log("North Button");
                JoystickNorthButton?.Invoke();

            }
        }
        private void EastButtonListener()
        {
            if (Input.GetButton("EastButton1"))
            {
                Debug.Log("East Button");
                JoystickEastButton?.Invoke();

            }
        }
        private void WestButtonListener()
        {
            if (Input.GetButton("WestButton1"))
            {
                Debug.Log("West Button");
                JoystickWestButton?.Invoke();
            }
        }
    }
}
