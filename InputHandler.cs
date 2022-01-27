using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Interactions;

namespace XenoWare
{
    public class InputHandler : MonoBehaviour, IInputHandler
    {
        [SerializeField]
        Camera _camera;

        [SerializeField]
        LayerMask directionHelperMask;

        public event EventHandler QuitApplication;
        public event EventHandler<InputButtonEventArgs> OnButtonClick;
        public event EventHandler<InputMouseEventArgs> OnMouseClick;

        BasicControls inputActions;

        Vector2 mousePosition;
        Vector2 mouseAxis;
        Vector2 cameraMovementVector = Vector2.zero;
        public float screenMouseX, screenMouseY;
        public Vector2 mouseScroll;

        Vector2 movementInput;

        public RaycastHit InteractionClickedTarget { get; private set; }

        public bool leftInteractionClickMultitapped = false;
        public bool leftInteractionHold = false;

        public Vector2 CameraMovementVector => cameraMovementVector;
        public float right;
        public float forward;
        public float up;
        public float movementAmount;
        public bool boost;

        public void Start()
        {
            if (_camera == null)
            {
                _camera = Camera.main;
            }
            mousePosition = Vector2.zero;
            mouseAxis = Vector2.zero;
        }

        public void OnEnable()
        {
            if (inputActions == null)
            {
                inputActions = new BasicControls();
                inputActions.Mouse.Interactions.started += Interactions_started;
                inputActions.Mouse.Interactions.canceled += Interactions_canceled;
                inputActions.Mouse.Interactions.performed += Interaction_performed;
                inputActions.Mouse.MousePosition.performed += p => mousePosition = p.ReadValue<Vector2>();
                inputActions.Mouse.CameraZoom.performed += i => mouseScroll = i.ReadValue<Vector2>();
                inputActions.Controller.Quit.performed += i => QuitApplication?.Invoke(this, new EventArgs());
                inputActions.Controller.Movement.performed += inputActions => movementInput = inputActions.ReadValue<Vector2>();
                inputActions.Controller.Thruster.performed += inputActions => up = inputActions.ReadValue<float>();
            }

            inputActions.Enable();
        }

        private void Interactions_canceled(InputAction.CallbackContext context)
        {
            leftInteractionHold = false;
            Debug.Log("Interactions_canceled");
        }

        private void Interactions_started(InputAction.CallbackContext context)
        {
            Debug.Log("Interactions_started");
            leftInteractionHold = false;
            HoldAction(context);
        }

        public float getMouseScroll()
        {
            float mouseScrollValue = mouseScroll.normalized.y;
            mouseScroll = Vector2.zero;
            return mouseScrollValue;
        }

        public Vector2 GetMousePosition()
        {
            return mousePosition;
        }

        public float GetMouseAxisX()
        {
            return mouseAxis.x;
        }

        public float GetMouseAxisY()
        {
            return mouseAxis.y;
        }

        //These run only after Canceled event.
        private void Interaction_performed(InputAction.CallbackContext context)
        {
            if (context.interaction is TapInteraction)
            {
                return;
            }

            if (context.interaction is MultiTapInteraction)
            {
                leftInteractionClickMultitapped = true;
                return;
            }
        }

        private void HoldAction(InputAction.CallbackContext context)
        {
            if (context.interaction is HoldInteraction)
            {
                Debug.Log("hold action");
                cameraMovementVector = Vector2.zero;
                leftInteractionHold = true;
            }
        }

        private void OnDisable()
        {
            inputActions.Disable();
        }

        public void TickInput(float delta)
        {
            MoveInput(delta);
            MoveCamera(delta);
            boost = inputActions.Controller.Boost.IsPressed();
            mouseAxis = inputActions.Mouse.MouseAxis.ReadValue<Vector2>();

            if (inputActions.Mouse.Interactions.IsPressed())
            {
                Ray ray = _camera.ScreenPointToRay(mousePosition);
                if (Physics.Raycast(ray, out RaycastHit hit))
                {
                    InteractionClickedTarget = hit;
                }
            }
        }

        private void MoveInput(float delta)
        {
            right = movementInput.x;
            forward = movementInput.y;
            movementAmount = Mathf.Clamp01(Mathf.Abs(right) + Mathf.Abs(forward));
        }

        private void MoveCamera(float delta)
        {
            if (leftInteractionHold)
            {
                cameraMovementVector.x = mouseAxis.x;
                cameraMovementVector.y = mouseAxis.y;
            }
            else
            {
                cameraMovementVector.x = 0;
                cameraMovementVector.y = 0;
            }
        }
    }
}