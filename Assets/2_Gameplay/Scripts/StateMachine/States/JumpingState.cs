using Gameplay._2_Gameplay.Scripts.StateMachine;
using UnityEngine;

namespace Gameplay._2_Gameplay.StateMachine.States
{
    public class JumpingState : IPlayerState
    {
        private readonly PlayerController _controller;
        private Coroutine _jumpCoroutine;
        private readonly int _jumpCount;

        public JumpingState(PlayerController controller) : this(controller, 1)
        {
        }

        public JumpingState(PlayerController controller, int jumpCount)
        {
            _controller = controller;
            _jumpCount = jumpCount;
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

        public StateTransition HandleMovement(Vector3 direction)
        {
            _controller.Character.SetDirection(direction * _controller.AirborneSpeedMultiplier);
            return null;
        }

        public StateTransition HandleJump()
        {
            if (_jumpCount < _controller.MaxJumps)
            {
                return new StateTransition(StateType.Jumping, _jumpCount + 1);
            }

            return null;
        }

        public StateTransition OnCollisionEnter(Collision collision)
        {
            foreach (var contact in collision.contacts)
            {
                if (Vector3.Angle(contact.normal, Vector3.up) < 5)
                {
                    return new StateTransition(StateType.Grounded);
                }
            }

            return null;
        }
    }
}