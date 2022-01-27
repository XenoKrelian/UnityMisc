using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace XenoWare
{
    public abstract class BaseStateMachine
    {
        protected IState currentRunningState;
        protected IState previousState;
        protected bool enteringState = false;

        public virtual void ChangeState(IState newState)
        {
            if (enteringState)
            {
#if DEBUG
                Debug.Log("Already entering State");
#endif
                return;
            }

            if (currentRunningState != null)
            {
                currentRunningState.Exit();
                previousState = currentRunningState;
            }
            currentRunningState = newState;
            currentRunningState.Enter();
        }
        IEnumerator PauseBeforeChangeStateCoroutine(float pause, IState nextState)
        {
            enteringState = true;
            yield return new WaitForSeconds(pause);
            enteringState = false;
            ChangeState(nextState);
        }

        public void ExecuteStateUpdate()
        {
            if (currentRunningState != null)
            {
                currentRunningState.Execute();
            }
        }

        public virtual void SwitchToPreviousState()
        {
            if (currentRunningState == null) return;
            currentRunningState.Exit();
            currentRunningState = previousState;
            currentRunningState.Enter();
        }
    }
}