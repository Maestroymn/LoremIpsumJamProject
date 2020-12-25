using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeyboardListener : MonoBehaviour
{
    [SerializeField] KeyCode firstKey;
    [SerializeField] KeyCode secondKey;
    [SerializeField] KeyCode thirdKey;
    [SerializeField] KeyCode fourthKey;
    [SerializeField] KeyCode fifthKey;
    [SerializeField] KeyCode sixthKey;
    public static event Action FirstKeyPressed;
    public static event Action SecondKeyPressed;
    public static event Action ThirdKeyPressed;
    public static event Action FourthKeyPressed;
    public static event Action FifthKeyPressed;
    public static event Action SixthKeyPressed;

    void Update()
    {
        if (Input.anyKeyDown)
        {
            KeyPressed();
        }
    }

    void KeyPressed()
    {
        if (Input.GetKeyDown(firstKey))
        {
            FirstKeyPressed?.Invoke();
            Debug.Log(firstKey + " basıldı");
        }

        if (Input.GetKeyDown(secondKey))
        {
            SecondKeyPressed?.Invoke();
            Debug.Log(secondKey + " basıldı");
        }

        if (Input.GetKeyDown(thirdKey))
        {
            ThirdKeyPressed?.Invoke();
            Debug.Log(thirdKey + " basıldı");
        }

        if (Input.GetKeyDown(fourthKey))
        {
            FourthKeyPressed?.Invoke();
            Debug.Log(fourthKey + " basıldı");
        }

        if (Input.GetKeyDown(fifthKey))
        {
            FifthKeyPressed?.Invoke();
            Debug.Log(fifthKey + " basıldı");
        }

        if (Input.GetKeyDown(sixthKey))
        {
            SixthKeyPressed?.Invoke();
            Debug.Log(sixthKey + " basıldı");
        }
    }
}
