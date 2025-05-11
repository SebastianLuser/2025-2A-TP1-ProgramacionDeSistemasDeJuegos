using UnityEngine;

namespace Gameplay._2_Gameplay.StateMachine.States
{
    public class JumpingState : IPlayerState
    {
        private readonly PlayerController _controller;
        private readonly PlayerStateMachine _stateMachine;
        private Coroutine _jumpCoroutine;

        public JumpingState(PlayerController controller, PlayerStateMachine stateMachine)
        {
            _controller = controller;
            _stateMachine = stateMachine;
        }

        public void Enter()
        {
            _jumpCoroutine = _controller.StartCoroutine(_controller.Character.Jump());
        }

        public void Exit()
        {
            if (_jumpCoroutine != null)
                _controller.StopCoroutine(_jumpCoroutine);
        }

        public void HandleMovement(Vector3 direction)
        {
            _controller.Character.SetDirection(direction * _controller.AirborneSpeedMultiplier);
        }

        public void HandleJump()
        {
            _stateMachine.SetState(new DoubleJumpingState(_controller, _stateMachine));
        }
    }
}