using System;
using UnityEngine;

namespace XenoWare
{
    public class InputMouseEventArgs : EventArgs
    {
        public InputMouseEventArgs(int button, Vector3 worldCoords)
        {
            worldPosition = worldCoords;
            this.button = button;
        }

        public Vector3 worldPosition { get; private set; }
        public int button { get; private set; }
    }

    public class InputButtonEventArgs : EventArgs
    {
        public InputButtonEventArgs(int button, Vector2? inputPosition = null)
        {
            this.button = button;
            this.inputPosition = inputPosition;
        }
        public int button { get; private set; }
        public Vector2? inputPosition { get; private set; }
    }

    public interface IInputHandler
    {
        Vector2 CameraMovementVector { get; }
        RaycastHit InteractionClickedTarget { get; }

        event EventHandler QuitApplication;
        event EventHandler<InputButtonEventArgs> OnButtonClick;
        event EventHandler<InputMouseEventArgs> OnMouseClick;

        float GetMouseAxisX();
        float GetMouseAxisY();
        Vector2 GetMousePosition();
        float getMouseScroll();
        void OnEnable();
        void Start();
        void TickInput(float delta);
    }
}