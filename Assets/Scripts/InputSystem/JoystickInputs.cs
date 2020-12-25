// GENERATED AUTOMATICALLY FROM 'Assets/Scripts/InputSystem/JoystickInputs.inputactions'

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Utilities;

public class @JoystickInputs : IInputActionCollection, IDisposable
{
    public InputActionAsset asset { get; }
    public @JoystickInputs()
    {
        asset = InputActionAsset.FromJson(@"{
    ""name"": ""JoystickInputs"",
    ""maps"": [
        {
            ""name"": ""MouseJoystick"",
            ""id"": ""3d44236e-168b-4d99-85f0-198853ce2419"",
            ""actions"": [
                {
                    ""name"": ""RightOne"",
                    ""type"": ""Button"",
                    ""id"": ""983b64a8-ef1d-4660-b44d-f2c3e9f7c918"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""LeftOne"",
                    ""type"": ""Button"",
                    ""id"": ""fc0f4c33-5f0f-4791-9880-0ca783ae1bc7"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""RightStickUp"",
                    ""type"": ""Button"",
                    ""id"": ""5f5b8476-0974-487a-9597-0468e909326e"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""RightStickDown"",
                    ""type"": ""Button"",
                    ""id"": ""0c1bda4c-6203-4b7d-8d04-ddf63138984f"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                }
            ],
            ""bindings"": [
                {
                    ""name"": """",
                    ""id"": ""b6747678-d4ae-4bf5-8749-7bb0354208ab"",
                    ""path"": ""<Gamepad>/rightShoulder"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""RightOne"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""2931fbdb-8945-43a2-a9f0-a516e600890d"",
                    ""path"": ""<Gamepad>/leftShoulder"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""LeftOne"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""e7cc7392-bd35-457e-a3a3-96dc0e367a55"",
                    ""path"": ""<Gamepad>/rightStick/up"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""RightStickUp"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""a917a14d-11da-4e38-882d-086f8a12a215"",
                    ""path"": ""<Gamepad>/rightStick/down"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""RightStickDown"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        },
        {
            ""name"": ""KeyboardJoystick"",
            ""id"": ""b9e14ca5-bc31-40a3-a4f8-456323252e54"",
            ""actions"": [
                {
                    ""name"": ""RightTwo"",
                    ""type"": ""Button"",
                    ""id"": ""af26fddc-01a3-4864-bec1-cd5401345b2a"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""LeftTwo"",
                    ""type"": ""Button"",
                    ""id"": ""fdf52754-210c-46dd-bdea-ed641572866f"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""SouthButton"",
                    ""type"": ""Button"",
                    ""id"": ""5fd1fbc7-3084-4ed7-a528-c3f14283ccde"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""NorthButton"",
                    ""type"": ""Button"",
                    ""id"": ""0e5f07be-43f0-4776-ba44-763e573fac2e"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""EastButton"",
                    ""type"": ""Button"",
                    ""id"": ""ebeb2842-d9c9-4e11-b1a4-440e14ba8167"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""WestButton"",
                    ""type"": ""Button"",
                    ""id"": ""2342b977-e412-439d-83bb-b4fb28b90279"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                }
            ],
            ""bindings"": [
                {
                    ""name"": """",
                    ""id"": ""b56dc999-d533-47ee-9c71-a7bcea3b3f41"",
                    ""path"": ""<Gamepad>/rightTrigger"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""RightTwo"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""678b0cc1-c854-4cfe-a060-5b80694e6e16"",
                    ""path"": ""<Gamepad>/leftTrigger"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""LeftTwo"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""473e1cd1-4893-48f3-b7a5-64128cd2b48a"",
                    ""path"": ""<Gamepad>/buttonSouth"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""SouthButton"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""4b5ee8c1-6b7b-436c-a116-4c2a2464c02a"",
                    ""path"": ""<Gamepad>/buttonNorth"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""NorthButton"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""1e529b09-8484-4653-9d59-8afdc9525407"",
                    ""path"": ""<Gamepad>/buttonEast"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""EastButton"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""0dac3b2b-bb47-429d-985c-0f7d2a4e5573"",
                    ""path"": ""<Gamepad>/buttonWest"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""WestButton"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        }
    ],
    ""controlSchemes"": []
}");
        // MouseJoystick
        m_MouseJoystick = asset.FindActionMap("MouseJoystick", throwIfNotFound: true);
        m_MouseJoystick_RightOne = m_MouseJoystick.FindAction("RightOne", throwIfNotFound: true);
        m_MouseJoystick_LeftOne = m_MouseJoystick.FindAction("LeftOne", throwIfNotFound: true);
        m_MouseJoystick_RightStickUp = m_MouseJoystick.FindAction("RightStickUp", throwIfNotFound: true);
        m_MouseJoystick_RightStickDown = m_MouseJoystick.FindAction("RightStickDown", throwIfNotFound: true);
        // KeyboardJoystick
        m_KeyboardJoystick = asset.FindActionMap("KeyboardJoystick", throwIfNotFound: true);
        m_KeyboardJoystick_RightTwo = m_KeyboardJoystick.FindAction("RightTwo", throwIfNotFound: true);
        m_KeyboardJoystick_LeftTwo = m_KeyboardJoystick.FindAction("LeftTwo", throwIfNotFound: true);
        m_KeyboardJoystick_SouthButton = m_KeyboardJoystick.FindAction("SouthButton", throwIfNotFound: true);
        m_KeyboardJoystick_NorthButton = m_KeyboardJoystick.FindAction("NorthButton", throwIfNotFound: true);
        m_KeyboardJoystick_EastButton = m_KeyboardJoystick.FindAction("EastButton", throwIfNotFound: true);
        m_KeyboardJoystick_WestButton = m_KeyboardJoystick.FindAction("WestButton", throwIfNotFound: true);
    }

    public void Dispose()
    {
        UnityEngine.Object.Destroy(asset);
    }

    public InputBinding? bindingMask
    {
        get => asset.bindingMask;
        set => asset.bindingMask = value;
    }

    public ReadOnlyArray<InputDevice>? devices
    {
        get => asset.devices;
        set => asset.devices = value;
    }

    public ReadOnlyArray<InputControlScheme> controlSchemes => asset.controlSchemes;

    public bool Contains(InputAction action)
    {
        return asset.Contains(action);
    }

    public IEnumerator<InputAction> GetEnumerator()
    {
        return asset.GetEnumerator();
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
        return GetEnumerator();
    }

    public void Enable()
    {
        asset.Enable();
    }

    public void Disable()
    {
        asset.Disable();
    }

    // MouseJoystick
    private readonly InputActionMap m_MouseJoystick;
    private IMouseJoystickActions m_MouseJoystickActionsCallbackInterface;
    private readonly InputAction m_MouseJoystick_RightOne;
    private readonly InputAction m_MouseJoystick_LeftOne;
    private readonly InputAction m_MouseJoystick_RightStickUp;
    private readonly InputAction m_MouseJoystick_RightStickDown;
    public struct MouseJoystickActions
    {
        private @JoystickInputs m_Wrapper;
        public MouseJoystickActions(@JoystickInputs wrapper) { m_Wrapper = wrapper; }
        public InputAction @RightOne => m_Wrapper.m_MouseJoystick_RightOne;
        public InputAction @LeftOne => m_Wrapper.m_MouseJoystick_LeftOne;
        public InputAction @RightStickUp => m_Wrapper.m_MouseJoystick_RightStickUp;
        public InputAction @RightStickDown => m_Wrapper.m_MouseJoystick_RightStickDown;
        public InputActionMap Get() { return m_Wrapper.m_MouseJoystick; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(MouseJoystickActions set) { return set.Get(); }
        public void SetCallbacks(IMouseJoystickActions instance)
        {
            if (m_Wrapper.m_MouseJoystickActionsCallbackInterface != null)
            {
                @RightOne.started -= m_Wrapper.m_MouseJoystickActionsCallbackInterface.OnRightOne;
                @RightOne.performed -= m_Wrapper.m_MouseJoystickActionsCallbackInterface.OnRightOne;
                @RightOne.canceled -= m_Wrapper.m_MouseJoystickActionsCallbackInterface.OnRightOne;
                @LeftOne.started -= m_Wrapper.m_MouseJoystickActionsCallbackInterface.OnLeftOne;
                @LeftOne.performed -= m_Wrapper.m_MouseJoystickActionsCallbackInterface.OnLeftOne;
                @LeftOne.canceled -= m_Wrapper.m_MouseJoystickActionsCallbackInterface.OnLeftOne;
                @RightStickUp.started -= m_Wrapper.m_MouseJoystickActionsCallbackInterface.OnRightStickUp;
                @RightStickUp.performed -= m_Wrapper.m_MouseJoystickActionsCallbackInterface.OnRightStickUp;
                @RightStickUp.canceled -= m_Wrapper.m_MouseJoystickActionsCallbackInterface.OnRightStickUp;
                @RightStickDown.started -= m_Wrapper.m_MouseJoystickActionsCallbackInterface.OnRightStickDown;
                @RightStickDown.performed -= m_Wrapper.m_MouseJoystickActionsCallbackInterface.OnRightStickDown;
                @RightStickDown.canceled -= m_Wrapper.m_MouseJoystickActionsCallbackInterface.OnRightStickDown;
            }
            m_Wrapper.m_MouseJoystickActionsCallbackInterface = instance;
            if (instance != null)
            {
                @RightOne.started += instance.OnRightOne;
                @RightOne.performed += instance.OnRightOne;
                @RightOne.canceled += instance.OnRightOne;
                @LeftOne.started += instance.OnLeftOne;
                @LeftOne.performed += instance.OnLeftOne;
                @LeftOne.canceled += instance.OnLeftOne;
                @RightStickUp.started += instance.OnRightStickUp;
                @RightStickUp.performed += instance.OnRightStickUp;
                @RightStickUp.canceled += instance.OnRightStickUp;
                @RightStickDown.started += instance.OnRightStickDown;
                @RightStickDown.performed += instance.OnRightStickDown;
                @RightStickDown.canceled += instance.OnRightStickDown;
            }
        }
    }
    public MouseJoystickActions @MouseJoystick => new MouseJoystickActions(this);

    // KeyboardJoystick
    private readonly InputActionMap m_KeyboardJoystick;
    private IKeyboardJoystickActions m_KeyboardJoystickActionsCallbackInterface;
    private readonly InputAction m_KeyboardJoystick_RightTwo;
    private readonly InputAction m_KeyboardJoystick_LeftTwo;
    private readonly InputAction m_KeyboardJoystick_SouthButton;
    private readonly InputAction m_KeyboardJoystick_NorthButton;
    private readonly InputAction m_KeyboardJoystick_EastButton;
    private readonly InputAction m_KeyboardJoystick_WestButton;
    public struct KeyboardJoystickActions
    {
        private @JoystickInputs m_Wrapper;
        public KeyboardJoystickActions(@JoystickInputs wrapper) { m_Wrapper = wrapper; }
        public InputAction @RightTwo => m_Wrapper.m_KeyboardJoystick_RightTwo;
        public InputAction @LeftTwo => m_Wrapper.m_KeyboardJoystick_LeftTwo;
        public InputAction @SouthButton => m_Wrapper.m_KeyboardJoystick_SouthButton;
        public InputAction @NorthButton => m_Wrapper.m_KeyboardJoystick_NorthButton;
        public InputAction @EastButton => m_Wrapper.m_KeyboardJoystick_EastButton;
        public InputAction @WestButton => m_Wrapper.m_KeyboardJoystick_WestButton;
        public InputActionMap Get() { return m_Wrapper.m_KeyboardJoystick; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(KeyboardJoystickActions set) { return set.Get(); }
        public void SetCallbacks(IKeyboardJoystickActions instance)
        {
            if (m_Wrapper.m_KeyboardJoystickActionsCallbackInterface != null)
            {
                @RightTwo.started -= m_Wrapper.m_KeyboardJoystickActionsCallbackInterface.OnRightTwo;
                @RightTwo.performed -= m_Wrapper.m_KeyboardJoystickActionsCallbackInterface.OnRightTwo;
                @RightTwo.canceled -= m_Wrapper.m_KeyboardJoystickActionsCallbackInterface.OnRightTwo;
                @LeftTwo.started -= m_Wrapper.m_KeyboardJoystickActionsCallbackInterface.OnLeftTwo;
                @LeftTwo.performed -= m_Wrapper.m_KeyboardJoystickActionsCallbackInterface.OnLeftTwo;
                @LeftTwo.canceled -= m_Wrapper.m_KeyboardJoystickActionsCallbackInterface.OnLeftTwo;
                @SouthButton.started -= m_Wrapper.m_KeyboardJoystickActionsCallbackInterface.OnSouthButton;
                @SouthButton.performed -= m_Wrapper.m_KeyboardJoystickActionsCallbackInterface.OnSouthButton;
                @SouthButton.canceled -= m_Wrapper.m_KeyboardJoystickActionsCallbackInterface.OnSouthButton;
                @NorthButton.started -= m_Wrapper.m_KeyboardJoystickActionsCallbackInterface.OnNorthButton;
                @NorthButton.performed -= m_Wrapper.m_KeyboardJoystickActionsCallbackInterface.OnNorthButton;
                @NorthButton.canceled -= m_Wrapper.m_KeyboardJoystickActionsCallbackInterface.OnNorthButton;
                @EastButton.started -= m_Wrapper.m_KeyboardJoystickActionsCallbackInterface.OnEastButton;
                @EastButton.performed -= m_Wrapper.m_KeyboardJoystickActionsCallbackInterface.OnEastButton;
                @EastButton.canceled -= m_Wrapper.m_KeyboardJoystickActionsCallbackInterface.OnEastButton;
                @WestButton.started -= m_Wrapper.m_KeyboardJoystickActionsCallbackInterface.OnWestButton;
                @WestButton.performed -= m_Wrapper.m_KeyboardJoystickActionsCallbackInterface.OnWestButton;
                @WestButton.canceled -= m_Wrapper.m_KeyboardJoystickActionsCallbackInterface.OnWestButton;
            }
            m_Wrapper.m_KeyboardJoystickActionsCallbackInterface = instance;
            if (instance != null)
            {
                @RightTwo.started += instance.OnRightTwo;
                @RightTwo.performed += instance.OnRightTwo;
                @RightTwo.canceled += instance.OnRightTwo;
                @LeftTwo.started += instance.OnLeftTwo;
                @LeftTwo.performed += instance.OnLeftTwo;
                @LeftTwo.canceled += instance.OnLeftTwo;
                @SouthButton.started += instance.OnSouthButton;
                @SouthButton.performed += instance.OnSouthButton;
                @SouthButton.canceled += instance.OnSouthButton;
                @NorthButton.started += instance.OnNorthButton;
                @NorthButton.performed += instance.OnNorthButton;
                @NorthButton.canceled += instance.OnNorthButton;
                @EastButton.started += instance.OnEastButton;
                @EastButton.performed += instance.OnEastButton;
                @EastButton.canceled += instance.OnEastButton;
                @WestButton.started += instance.OnWestButton;
                @WestButton.performed += instance.OnWestButton;
                @WestButton.canceled += instance.OnWestButton;
            }
        }
    }
    public KeyboardJoystickActions @KeyboardJoystick => new KeyboardJoystickActions(this);
    public interface IMouseJoystickActions
    {
        void OnRightOne(InputAction.CallbackContext context);
        void OnLeftOne(InputAction.CallbackContext context);
        void OnRightStickUp(InputAction.CallbackContext context);
        void OnRightStickDown(InputAction.CallbackContext context);
    }
    public interface IKeyboardJoystickActions
    {
        void OnRightTwo(InputAction.CallbackContext context);
        void OnLeftTwo(InputAction.CallbackContext context);
        void OnSouthButton(InputAction.CallbackContext context);
        void OnNorthButton(InputAction.CallbackContext context);
        void OnEastButton(InputAction.CallbackContext context);
        void OnWestButton(InputAction.CallbackContext context);
    }
}
