using UnityEngine;

namespace Gameplay._2_Gameplay.StateMachine
{
    public interface IPlayerState
    {
        void Enter();
        void Exit();
        void HandleMovement(Vector3 direction);
        void HandleJump();
        void OnCollisionEnter(Collision collision);
    }
}