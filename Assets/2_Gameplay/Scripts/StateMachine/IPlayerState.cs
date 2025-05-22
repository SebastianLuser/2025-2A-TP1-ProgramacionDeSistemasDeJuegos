using Gameplay._2_Gameplay.Scripts.StateMachine;
using UnityEngine;

namespace Gameplay._2_Gameplay.StateMachine
{
    public interface IPlayerState
    {
        void Enter();
        void Exit();
        StateTransition HandleMovement(Vector3 direction);
        StateTransition HandleJump();
        StateTransition OnCollisionEnter(Collision collision);
    }
}