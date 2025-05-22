using System.Collections.Generic;
using Gameplay._2_Gameplay.Scripts.StateMachine;
using Gameplay._2_Gameplay.StateMachine;
using Gameplay._2_Gameplay.StateMachine.States;
using UnityEngine;

namespace Gameplay
{
    public class PlayerStateMachine
    {
        private IPlayerState _currentState;
        private readonly PlayerController _controller;
        private readonly Dictionary<StateType, IPlayerState> _states;
        public PlayerStateMachine(PlayerController controller)
      
        {
            _controller = controller;
            _states = new Dictionary<StateType, IPlayerState>();
            InitializeStates();
        }
        
        private void InitializeStates()
        {
            _states[StateType.Grounded] = new GroundedState(_controller);
            _states[StateType.Jumping] = new JumpingState(_controller);
        }
        
        public void Initialize(StateType firstStateType)
        {
            if (!_states.ContainsKey(firstStateType)) return;
            _currentState = _states[firstStateType];
            _currentState.Enter();
        }
        private void TransitionTo(StateTransition transition)
        {
            if (transition != null && _states.ContainsKey(transition.ToState))
            {
                _currentState?.Exit();
                
                if (transition.Data != null && transition.ToState == StateType.Jumping)
                {
                    var jumpCount = (int)transition.Data;
                    _currentState = new JumpingState(_controller, jumpCount);
                }
                else
                {
                    _currentState = _states[transition.ToState];
                }
                
                _currentState?.Enter();
            }
        }
        
        public void HandleMovement(Vector3 direction)
        {
            var transition = _currentState?.HandleMovement(direction);
            TransitionTo(transition);
        }

        public void HandleJump()
        {
            var transition = _currentState?.HandleJump();
            TransitionTo(transition);
        }

        public void OnCollisionEnter(Collision collision)
        {
            var transition = _currentState?.OnCollisionEnter(collision);
            TransitionTo(transition);
        }
        
    }
}