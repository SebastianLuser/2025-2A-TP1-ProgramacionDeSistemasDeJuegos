using Gameplay._2_Gameplay.StateMachine;
using UnityEngine;

namespace Gameplay
{
    public class PlayerStateMachine
    {
        private IPlayerState _currentState;
        private readonly PlayerController _context;

        public PlayerStateMachine(PlayerController context)
        {
            _context = context;
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
    }
}