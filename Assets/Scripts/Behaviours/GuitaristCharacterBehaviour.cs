using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.InputSystem;

public class GuitaristCharacterBehaviour : MonoBehaviour
{
    private bool _isJoystickClaimed, _isJoystickPressed, _isMouseClaimed;
    [SerializeField] private MouseJoystickListener joystickListener;
    [SerializeField] private MouseListener mouseListener;

    JoystickInputs joystickInputs;
    private void Awake()
    {
        joystickInputs = new JoystickInputs();

        joystickInputs.MouseJoystick.RightOne.performed += ctx => SelectJoystick();
        joystickInputs.MouseJoystick.RightOne.canceled += ctx => SelectJoystick();
        
    }

    private void Start()
    {
        StartCoroutine(SelectInput());
    }

    private IEnumerator SelectInput()
    {
        while (true)
        {
            if (Input.GetMouseButton(0) && !_isMouseClaimed)
            {
                _isMouseClaimed = true;
                Debug.Log("Tıkladım Mouse");
                mouseListener.LeftClick += OnLeftClick;
                mouseListener.RightClick += OnRightClick;
                mouseListener.LeftClickDraggedUp += OnLeftClickDragUp;
                mouseListener.LeftClickDraggedDown += OnLeftClickDragDown;
                mouseListener.RightClickDraggedUp += OnRightClickDragUp;
                mouseListener.RightClickDraggedDown += OnRightClickDragDown;
                _isJoystickClaimed = false;
                _isJoystickPressed = false;
            }

            if (_isJoystickPressed && !_isJoystickClaimed)
            {
                _isJoystickClaimed = true;
                Debug.Log("Joystick Added");
                joystickListener.Initialized(joystickInputs);
                joystickListener.JoystickLeftOne += OnJoystickLeftOne;
                joystickListener.JoystickRightOne += OnJoystickRightOne;
                joystickListener.JoystickLeftDraggedUp += OnJoystickLeftDragUp;
                joystickListener.JoystickLeftDraggedDown += OnJoystickLeftDragDown;
                joystickListener.JoystickRightDraggedUp += OnJoystickRightDragUp;
                joystickListener.JoystickRightDraggedDown += OnJoystickRightDragDown;
                _isMouseClaimed = false;
            }
            yield return null;
        }
    }

    // Mouse Inputs
    private void OnLeftClick(PointerEventData eventData)
    {

    }

    private void OnRightClick(PointerEventData eventData)
    {

    }
    
    private void OnLeftClickDragUp(PointerEventData eventData)
    {

    }

    private void OnLeftClickDragDown(PointerEventData eventData)
    {

    }

    private void OnRightClickDragUp(PointerEventData eventData)
    {

    }

    private void OnRightClickDragDown(PointerEventData eventData)
    {

    }

    // Joystick Inputs
    private void OnJoystickRightOne()
    {

    }

    private void OnJoystickLeftOne()
    {

    }

    private void OnJoystickLeftDragUp()
    {

    }

    private void OnJoystickLeftDragDown()
    {

    }

    private void OnJoystickRightDragUp()
    {

    }

    private void OnJoystickRightDragDown()
    {

    }

    // Joystick Click Control
    private void SelectJoystick()
    {
        if (joystickInputs.MouseJoystick.RightOne.triggered && !_isJoystickClaimed)
        {
            _isJoystickPressed = true;
            Debug.Log("Joystick");
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
