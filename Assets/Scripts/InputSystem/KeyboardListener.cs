using System;
using UnityEngine;

namespace InputSystem
{
    public class KeyboardListener : MonoBehaviour
    {
        public KeyCode FirstKey;
        public KeyCode SecondKey;
        public KeyCode ThirdKey;
        public KeyCode FourthKey;
        public KeyCode FifthKey;
        public KeyCode SixthKey;
        public event Action FirstKeyPressed;
        public event Action SecondKeyPressed;
        public event Action ThirdKeyPressed;
        public event Action FourthKeyPressed;
        public event Action FifthKeyPressed;
        public event Action SixthKeyPressed;

        void Update()
        { 
            if (Input.anyKeyDown)
            {
                KeyPressed();
            }
        }

        void KeyPressed()
        {
            if (Input.GetKeyDown(FirstKey))
            {
                FirstKeyPressed?.Invoke();
            }

            if (Input.GetKeyDown(SecondKey))
            {
                SecondKeyPressed?.Invoke();
            }

            if (Input.GetKeyDown(ThirdKey))
            {
                ThirdKeyPressed?.Invoke();
            }

            if (Input.GetKeyDown(FourthKey))
            {
                FourthKeyPressed?.Invoke();
            }

            if (Input.GetKeyDown(FifthKey))
            {
                FifthKeyPressed?.Invoke();
            }

            if (Input.GetKeyDown(SixthKey))
            {
                SixthKeyPressed?.Invoke();
            }
        }
    }
}
