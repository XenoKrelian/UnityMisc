using UnityEngine;

namespace XenoWare
{
    public interface IGameState : IState
    {
        /// <summary>
        /// Method to execute on key press
        /// </summary>
        void OnKeyPressDown(int button, Vector2? inputPosition = null);
        /// <summary>
        /// Method to execute on mouse click
        /// </summary>
        void OnMouseButtonClick(int button, Vector3 worldPosition);

        /// <summary>
        /// Add a IEvaluateOnMouseClick method to our state, which will (default) be run though on mouse click, it will not add duplicates, and most should be added via constructor
        /// </summary>
        void AddIEvaluateOnMouseClick(IEvaluateOnMouseClick evaluator);
        void TriggerEvent(int eventId);
    }
}