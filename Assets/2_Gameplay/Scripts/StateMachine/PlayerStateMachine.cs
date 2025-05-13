using Gameplay._2_Gameplay.StateMachine;
using UnityEngine;

namespace Gameplay
{
    public class PlayerStateMachine
    {
        private IPlayerState _currentState;

        public void Initialize(IPlayerState  firstState)
        {
            _currentState = firstState;
            _currentState.Enter();
        }

        public void SetState(IPlayerState newState)
        {
            _currentState?.Exit();
            _currentState = newState;
            _currentState?.Enter();
        }

        public void HandleMovement(Vector3 direction)
        {
            _currentState?.HandleMovement(direction);
        }

        public void HandleJump()
        {
            _currentState?.HandleJump();
        }

        public void OnCollisionEnter(Collision collision)
        {
            _currentState?.OnCollisionEnter(collision);
        }
        
    }
}