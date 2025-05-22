using Gameplay._2_Gameplay.Scripts.StateMachine;
using UnityEngine;

namespace Gameplay._2_Gameplay.StateMachine.States
{
    public class GroundedState : IPlayerState
    {
        private readonly PlayerController _controller;
        public GroundedState(PlayerController controller)
        {
            _controller = controller;
        }

        public void Enter() { }

        public void Exit() { }

        public StateTransition HandleMovement(Vector3 direction)
        {
            _controller.Character.SetDirection(direction);
            return null; 
        }

        public StateTransition HandleJump()
        {
            return new StateTransition(StateType.Jumping, 1);
        }

        public StateTransition OnCollisionEnter(Collision collision)
        {
            return null;
        }
    }
}