using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace XenoWare
{
    public class GameStateMachine : BaseStateMachine
    {
        protected new IGameState currentRunningState;
        protected new IGameState previousState;
        protected IInputHandler inputHandler;

        public GameStateMachine(IInputHandler inputController)
        {
            this.inputHandler = inputController;
            //Each state can have diffenrent Evaluators attached the react either a mouse or button event.
            this.inputHandler.OnMouseClick += (object sender, InputMouseEventArgs e) => OnMouseButtonClick(e.button, e.worldPosition);
            this.inputHandler.OnButtonClick += (object sender, InputButtonEventArgs e) => OnKeyPressDown(e.button, e.inputPosition);
        }

        public void OnMouseButtonClick(int button, Vector3 worldPosition)
        {
            currentRunningState?.OnMouseButtonClick(button, worldPosition);
        }

        public void OnKeyPressDown(int button, Vector2? inputPosition = null)
        {
            currentRunningState?.OnKeyPressDown(button, inputPosition);
        }

        public override void ChangeState(IState newState)
        {
            base.ChangeState(newState);
            currentRunningState = base.currentRunningState as IGameState;
            previousState = base.previousState as IGameState;
        }

        public override void SwitchToPreviousState()
        {
            base.SwitchToPreviousState();
            currentRunningState = base.currentRunningState as IGameState;
            previousState = base.previousState as IGameState;
        }

        public string GetCurrentState()
        {
            return currentRunningState.ToString();
        }

        public void TriggerEvent(int eventId)
        {
            currentRunningState.TriggerEvent(eventId);
        }
    }
}
