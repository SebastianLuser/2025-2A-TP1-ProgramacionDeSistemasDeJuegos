using UnityEngine;

namespace Gameplay._2_Gameplay.StateMachine.States
{
    public class GroundedState : IPlayerState
    {
        private readonly PlayerController _controller;
        private readonly PlayerStateMachine _stateMachine;

        public GroundedState(PlayerController controller, PlayerStateMachine stateMachine)
        {
            _controller = controller;
            _stateMachine = stateMachine;
        }

        public void Enter() { }

        public void Exit() { }

        public void HandleMovement(Vector3 direction)
        {
            _controller.Character.SetDirection(direction);
        }

        public void HandleJump()
        {
            _stateMachine.SetState(new JumpingState(_controller, _stateMachine));
        }
    }
}