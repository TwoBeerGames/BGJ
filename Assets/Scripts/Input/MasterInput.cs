// GENERATED AUTOMATICALLY FROM 'Assets/Scripts/MasterInput.inputactions'

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Utilities;

public class @MasterInput : IInputActionCollection, IDisposable
{
    public InputActionAsset asset { get; }
    public @MasterInput()
    {
        asset = InputActionAsset.FromJson(@"{
    ""name"": ""MasterInput"",
    ""maps"": [
        {
            ""name"": ""Movement"",
            ""id"": ""a3960b07-9dfc-4777-8da9-abbd71adea1f"",
            ""actions"": [
                {
                    ""name"": ""ForwardDown"",
                    ""type"": ""Button"",
                    ""id"": ""5a7d4ddd-9b76-451e-8c76-4696c39d2864"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""BackwardDown"",
                    ""type"": ""Button"",
                    ""id"": ""c67d8571-0222-4e73-bf64-93651dd50873"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""BackwardUp"",
                    ""type"": ""Button"",
                    ""id"": ""09a22176-ccc9-47e3-bee9-3e626b58f5a1"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""ForwardUp"",
                    ""type"": ""Button"",
                    ""id"": ""ab877977-6871-49db-af8a-391dfd59dca1"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""RightDown"",
                    ""type"": ""Button"",
                    ""id"": ""bc77d7c0-3ede-4547-85cb-00e507822ccb"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""RightUp"",
                    ""type"": ""Button"",
                    ""id"": ""52ab0e1d-6679-4f0b-99e8-a8345847fe52"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""LeftUp"",
                    ""type"": ""Button"",
                    ""id"": ""a5bdf0f9-0d7c-4c99-8087-ea7287168b55"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""LeftDown"",
                    ""type"": ""Value"",
                    ""id"": ""1ffd5768-2053-4dd7-9a27-ff050c404de8"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                }
            ],
            ""bindings"": [
                {
                    ""name"": """",
                    ""id"": ""c1f7ed1e-b37d-4707-841a-a250f31c510e"",
                    ""path"": ""<Keyboard>/w"",
                    ""interactions"": ""Press"",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""ForwardDown"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""59090a3e-b6c4-4b48-b5c0-54ab4a33b8bf"",
                    ""path"": ""<Keyboard>/w"",
                    ""interactions"": ""Press(behavior=1)"",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""ForwardUp"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""a3c66d83-d1d2-4867-be22-83ddb19de4bf"",
                    ""path"": ""<Keyboard>/s"",
                    ""interactions"": ""Press"",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""BackwardDown"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""416b09e2-dcf7-4b04-b7d7-bcb0abb5e6a8"",
                    ""path"": ""<Keyboard>/s"",
                    ""interactions"": ""Press(behavior=1)"",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""BackwardUp"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""4879f37f-2ba3-4a23-83da-b07bf2f2d53b"",
                    ""path"": ""<Keyboard>/s"",
                    ""interactions"": ""Press"",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""ForwardUp"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""2c3694f7-9675-4620-ae0a-75ffda801aee"",
                    ""path"": ""<Keyboard>/d"",
                    ""interactions"": ""Press"",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""RightDown"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""5c1c0a13-d6b6-4de7-abcc-b07d7deb82d7"",
                    ""path"": ""<Keyboard>/d"",
                    ""interactions"": ""Press(behavior=1)"",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""RightUp"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""fda68d94-afe2-4f3b-be0b-22c7da301169"",
                    ""path"": ""<Keyboard>/a"",
                    ""interactions"": ""Press(behavior=1)"",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""LeftUp"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""c26b25e2-a3ad-4c5e-b49c-ec9fdf314855"",
                    ""path"": ""<Keyboard>/a"",
                    ""interactions"": ""Press"",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""LeftDown"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        },
        {
            ""name"": ""Mouse"",
            ""id"": ""30ab4091-4e06-42ad-9587-68a6ded685ef"",
            ""actions"": [
                {
                    ""name"": ""MousePosition"",
                    ""type"": ""PassThrough"",
                    ""id"": ""2d0e900e-30e4-4c7d-bf39-4abfd956bf64"",
                    ""expectedControlType"": ""Vector2"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""MouseDelta"",
                    ""type"": ""PassThrough"",
                    ""id"": ""1b9c6751-56bb-42f3-b90f-bc6eabf7d750"",
                    ""expectedControlType"": ""Vector2"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Scroll"",
                    ""type"": ""PassThrough"",
                    ""id"": ""aa64530c-158d-46cd-a15f-48562f12b50d"",
                    ""expectedControlType"": ""Axis"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""LeftClick"",
                    ""type"": ""Button"",
                    ""id"": ""8930d24e-af3c-4ad6-ac60-8ee37b391131"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                }
            ],
            ""bindings"": [
                {
                    ""name"": """",
                    ""id"": ""505dc625-d753-4c7c-890b-fec18a300915"",
                    ""path"": ""<Mouse>/delta"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""MouseDelta"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""b693bd15-cd8b-48c9-9062-4e2978225ace"",
                    ""path"": ""<Mouse>/position"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""MousePosition"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""f0666614-d4ac-4c6f-96cb-f21930889813"",
                    ""path"": ""<Mouse>/scroll/y"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Scroll"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""39020961-9008-48c7-aed1-665b0f702b54"",
                    ""path"": ""<Mouse>/leftButton"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""LeftClick"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        }
    ],
    ""controlSchemes"": []
}");
        // Movement
        m_Movement = asset.FindActionMap("Movement", throwIfNotFound: true);
        m_Movement_ForwardDown = m_Movement.FindAction("ForwardDown", throwIfNotFound: true);
        m_Movement_BackwardDown = m_Movement.FindAction("BackwardDown", throwIfNotFound: true);
        m_Movement_BackwardUp = m_Movement.FindAction("BackwardUp", throwIfNotFound: true);
        m_Movement_ForwardUp = m_Movement.FindAction("ForwardUp", throwIfNotFound: true);
        m_Movement_RightDown = m_Movement.FindAction("RightDown", throwIfNotFound: true);
        m_Movement_RightUp = m_Movement.FindAction("RightUp", throwIfNotFound: true);
        m_Movement_LeftUp = m_Movement.FindAction("LeftUp", throwIfNotFound: true);
        m_Movement_LeftDown = m_Movement.FindAction("LeftDown", throwIfNotFound: true);
        // Mouse
        m_Mouse = asset.FindActionMap("Mouse", throwIfNotFound: true);
        m_Mouse_MousePosition = m_Mouse.FindAction("MousePosition", throwIfNotFound: true);
        m_Mouse_MouseDelta = m_Mouse.FindAction("MouseDelta", throwIfNotFound: true);
        m_Mouse_Scroll = m_Mouse.FindAction("Scroll", throwIfNotFound: true);
        m_Mouse_LeftClick = m_Mouse.FindAction("LeftClick", throwIfNotFound: true);
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

    // Movement
    private readonly InputActionMap m_Movement;
    private IMovementActions m_MovementActionsCallbackInterface;
    private readonly InputAction m_Movement_ForwardDown;
    private readonly InputAction m_Movement_BackwardDown;
    private readonly InputAction m_Movement_BackwardUp;
    private readonly InputAction m_Movement_ForwardUp;
    private readonly InputAction m_Movement_RightDown;
    private readonly InputAction m_Movement_RightUp;
    private readonly InputAction m_Movement_LeftUp;
    private readonly InputAction m_Movement_LeftDown;
    public struct MovementActions
    {
        private @MasterInput m_Wrapper;
        public MovementActions(@MasterInput wrapper) { m_Wrapper = wrapper; }
        public InputAction @ForwardDown => m_Wrapper.m_Movement_ForwardDown;
        public InputAction @BackwardDown => m_Wrapper.m_Movement_BackwardDown;
        public InputAction @BackwardUp => m_Wrapper.m_Movement_BackwardUp;
        public InputAction @ForwardUp => m_Wrapper.m_Movement_ForwardUp;
        public InputAction @RightDown => m_Wrapper.m_Movement_RightDown;
        public InputAction @RightUp => m_Wrapper.m_Movement_RightUp;
        public InputAction @LeftUp => m_Wrapper.m_Movement_LeftUp;
        public InputAction @LeftDown => m_Wrapper.m_Movement_LeftDown;
        public InputActionMap Get() { return m_Wrapper.m_Movement; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(MovementActions set) { return set.Get(); }
        public void SetCallbacks(IMovementActions instance)
        {
            if (m_Wrapper.m_MovementActionsCallbackInterface != null)
            {
                @ForwardDown.started -= m_Wrapper.m_MovementActionsCallbackInterface.OnForwardDown;
                @ForwardDown.performed -= m_Wrapper.m_MovementActionsCallbackInterface.OnForwardDown;
                @ForwardDown.canceled -= m_Wrapper.m_MovementActionsCallbackInterface.OnForwardDown;
                @BackwardDown.started -= m_Wrapper.m_MovementActionsCallbackInterface.OnBackwardDown;
                @BackwardDown.performed -= m_Wrapper.m_MovementActionsCallbackInterface.OnBackwardDown;
                @BackwardDown.canceled -= m_Wrapper.m_MovementActionsCallbackInterface.OnBackwardDown;
                @BackwardUp.started -= m_Wrapper.m_MovementActionsCallbackInterface.OnBackwardUp;
                @BackwardUp.performed -= m_Wrapper.m_MovementActionsCallbackInterface.OnBackwardUp;
                @BackwardUp.canceled -= m_Wrapper.m_MovementActionsCallbackInterface.OnBackwardUp;
                @ForwardUp.started -= m_Wrapper.m_MovementActionsCallbackInterface.OnForwardUp;
                @ForwardUp.performed -= m_Wrapper.m_MovementActionsCallbackInterface.OnForwardUp;
                @ForwardUp.canceled -= m_Wrapper.m_MovementActionsCallbackInterface.OnForwardUp;
                @RightDown.started -= m_Wrapper.m_MovementActionsCallbackInterface.OnRightDown;
                @RightDown.performed -= m_Wrapper.m_MovementActionsCallbackInterface.OnRightDown;
                @RightDown.canceled -= m_Wrapper.m_MovementActionsCallbackInterface.OnRightDown;
                @RightUp.started -= m_Wrapper.m_MovementActionsCallbackInterface.OnRightUp;
                @RightUp.performed -= m_Wrapper.m_MovementActionsCallbackInterface.OnRightUp;
                @RightUp.canceled -= m_Wrapper.m_MovementActionsCallbackInterface.OnRightUp;
                @LeftUp.started -= m_Wrapper.m_MovementActionsCallbackInterface.OnLeftUp;
                @LeftUp.performed -= m_Wrapper.m_MovementActionsCallbackInterface.OnLeftUp;
                @LeftUp.canceled -= m_Wrapper.m_MovementActionsCallbackInterface.OnLeftUp;
                @LeftDown.started -= m_Wrapper.m_MovementActionsCallbackInterface.OnLeftDown;
                @LeftDown.performed -= m_Wrapper.m_MovementActionsCallbackInterface.OnLeftDown;
                @LeftDown.canceled -= m_Wrapper.m_MovementActionsCallbackInterface.OnLeftDown;
            }
            m_Wrapper.m_MovementActionsCallbackInterface = instance;
            if (instance != null)
            {
                @ForwardDown.started += instance.OnForwardDown;
                @ForwardDown.performed += instance.OnForwardDown;
                @ForwardDown.canceled += instance.OnForwardDown;
                @BackwardDown.started += instance.OnBackwardDown;
                @BackwardDown.performed += instance.OnBackwardDown;
                @BackwardDown.canceled += instance.OnBackwardDown;
                @BackwardUp.started += instance.OnBackwardUp;
                @BackwardUp.performed += instance.OnBackwardUp;
                @BackwardUp.canceled += instance.OnBackwardUp;
                @ForwardUp.started += instance.OnForwardUp;
                @ForwardUp.performed += instance.OnForwardUp;
                @ForwardUp.canceled += instance.OnForwardUp;
                @RightDown.started += instance.OnRightDown;
                @RightDown.performed += instance.OnRightDown;
                @RightDown.canceled += instance.OnRightDown;
                @RightUp.started += instance.OnRightUp;
                @RightUp.performed += instance.OnRightUp;
                @RightUp.canceled += instance.OnRightUp;
                @LeftUp.started += instance.OnLeftUp;
                @LeftUp.performed += instance.OnLeftUp;
                @LeftUp.canceled += instance.OnLeftUp;
                @LeftDown.started += instance.OnLeftDown;
                @LeftDown.performed += instance.OnLeftDown;
                @LeftDown.canceled += instance.OnLeftDown;
            }
        }
    }
    public MovementActions @Movement => new MovementActions(this);

    // Mouse
    private readonly InputActionMap m_Mouse;
    private IMouseActions m_MouseActionsCallbackInterface;
    private readonly InputAction m_Mouse_MousePosition;
    private readonly InputAction m_Mouse_MouseDelta;
    private readonly InputAction m_Mouse_Scroll;
    private readonly InputAction m_Mouse_LeftClick;
    public struct MouseActions
    {
        private @MasterInput m_Wrapper;
        public MouseActions(@MasterInput wrapper) { m_Wrapper = wrapper; }
        public InputAction @MousePosition => m_Wrapper.m_Mouse_MousePosition;
        public InputAction @MouseDelta => m_Wrapper.m_Mouse_MouseDelta;
        public InputAction @Scroll => m_Wrapper.m_Mouse_Scroll;
        public InputAction @LeftClick => m_Wrapper.m_Mouse_LeftClick;
        public InputActionMap Get() { return m_Wrapper.m_Mouse; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(MouseActions set) { return set.Get(); }
        public void SetCallbacks(IMouseActions instance)
        {
            if (m_Wrapper.m_MouseActionsCallbackInterface != null)
            {
                @MousePosition.started -= m_Wrapper.m_MouseActionsCallbackInterface.OnMousePosition;
                @MousePosition.performed -= m_Wrapper.m_MouseActionsCallbackInterface.OnMousePosition;
                @MousePosition.canceled -= m_Wrapper.m_MouseActionsCallbackInterface.OnMousePosition;
                @MouseDelta.started -= m_Wrapper.m_MouseActionsCallbackInterface.OnMouseDelta;
                @MouseDelta.performed -= m_Wrapper.m_MouseActionsCallbackInterface.OnMouseDelta;
                @MouseDelta.canceled -= m_Wrapper.m_MouseActionsCallbackInterface.OnMouseDelta;
                @Scroll.started -= m_Wrapper.m_MouseActionsCallbackInterface.OnScroll;
                @Scroll.performed -= m_Wrapper.m_MouseActionsCallbackInterface.OnScroll;
                @Scroll.canceled -= m_Wrapper.m_MouseActionsCallbackInterface.OnScroll;
                @LeftClick.started -= m_Wrapper.m_MouseActionsCallbackInterface.OnLeftClick;
                @LeftClick.performed -= m_Wrapper.m_MouseActionsCallbackInterface.OnLeftClick;
                @LeftClick.canceled -= m_Wrapper.m_MouseActionsCallbackInterface.OnLeftClick;
            }
            m_Wrapper.m_MouseActionsCallbackInterface = instance;
            if (instance != null)
            {
                @MousePosition.started += instance.OnMousePosition;
                @MousePosition.performed += instance.OnMousePosition;
                @MousePosition.canceled += instance.OnMousePosition;
                @MouseDelta.started += instance.OnMouseDelta;
                @MouseDelta.performed += instance.OnMouseDelta;
                @MouseDelta.canceled += instance.OnMouseDelta;
                @Scroll.started += instance.OnScroll;
                @Scroll.performed += instance.OnScroll;
                @Scroll.canceled += instance.OnScroll;
                @LeftClick.started += instance.OnLeftClick;
                @LeftClick.performed += instance.OnLeftClick;
                @LeftClick.canceled += instance.OnLeftClick;
            }
        }
    }
    public MouseActions @Mouse => new MouseActions(this);
    public interface IMovementActions
    {
        void OnForwardDown(InputAction.CallbackContext context);
        void OnBackwardDown(InputAction.CallbackContext context);
        void OnBackwardUp(InputAction.CallbackContext context);
        void OnForwardUp(InputAction.CallbackContext context);
        void OnRightDown(InputAction.CallbackContext context);
        void OnRightUp(InputAction.CallbackContext context);
        void OnLeftUp(InputAction.CallbackContext context);
        void OnLeftDown(InputAction.CallbackContext context);
    }
    public interface IMouseActions
    {
        void OnMousePosition(InputAction.CallbackContext context);
        void OnMouseDelta(InputAction.CallbackContext context);
        void OnScroll(InputAction.CallbackContext context);
        void OnLeftClick(InputAction.CallbackContext context);
    }
}
