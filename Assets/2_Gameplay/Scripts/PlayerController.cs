using Gameplay._2_Gameplay.StateMachine.States;
using UnityEngine;
using UnityEngine.InputSystem;

namespace Gameplay
{
    [RequireComponent(typeof(Character))]
    public class PlayerController : MonoBehaviour
    {
        [SerializeField] private InputActionReference moveInput;
        [SerializeField] private InputActionReference jumpInput;
        [SerializeField] private float airborneSpeedMultiplier = .5f;
        [SerializeField] private int maxJumps = 2;
        
        //TODO: This booleans are not flexible enough. If we want to have a third jump or other things, it will become a hazzle.
        private PlayerStateMachine _stateMachine;
        private Character _character;

        public Character Character => _character;
        public float AirborneSpeedMultiplier => airborneSpeedMultiplier;
        public int MaxJumps => maxJumps;

        private void Awake()
        {
            _character = GetComponent<Character>();
            _stateMachine = new PlayerStateMachine();
            _stateMachine.Initialize(new GroundedState(this, _stateMachine));
        }

        private void OnEnable()
        {
            if (moveInput?.action != null)
            {
                moveInput.action.started += HandleMoveInput;
                moveInput.action.performed += HandleMoveInput;
                moveInput.action.canceled += HandleMoveInput;
            }
            if (jumpInput?.action != null)
                jumpInput.action.performed += HandleJumpInput;
        }
        
        private void OnDisable()
        {
            if (moveInput?.action != null)
            {
                moveInput.action.started -= HandleMoveInput;
                moveInput.action.performed -= HandleMoveInput;
                moveInput.action.canceled -= HandleMoveInput;
            }
            if (jumpInput?.action != null)
                jumpInput.action.performed -= HandleJumpInput;
        }

        private void HandleMoveInput(InputAction.CallbackContext ctx)
        {
            var direction = ctx.ReadValue<Vector2>().ToHorizontalPlane();
            _stateMachine.HandleMovement(direction);
        }

        private void HandleJumpInput(InputAction.CallbackContext ctx)
        {
            //TODO: This function is barely readable. We need to refactor how we control the jumping
            _stateMachine.HandleJump();
        }

        private void OnCollisionEnter(Collision collision)
        {
            _stateMachine.OnCollisionEnter(collision);
        }
    }
}