using UnityEngine;

namespace Gameplay._2_Gameplay.StateMachine.States
{
    public class DoubleJumpingState : IPlayerState
    {
        private readonly PlayerController _controller;
        private readonly PlayerStateMachine _stateMachine;
        private Coroutine _jumpCoroutine;

        public DoubleJumpingState(PlayerController controller, PlayerStateMachine stateMachine)
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
        }
        public void OnCollisionEnter(Collision collision)
        {
            foreach (var contact in collision.contacts)
            {
                if (Vector3.Angle(contact.normal, Vector3.up) < 5)
                {
                    _stateMachine.SetState(new GroundedState(_controller, _stateMachine));
                    break;
                }
            }
        }
        
    }
}