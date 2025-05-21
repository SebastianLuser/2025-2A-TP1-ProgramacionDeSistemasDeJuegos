using System;
using UnityEngine;

namespace Excercise1
{
    [RequireComponent(typeof(EnemyMovement))]
    public class Enemy : Character
    {
        [SerializeField] private float speed = 5;
        [SerializeField] private string playerId = "Player";
        private ICharacter _player;
        private EnemyMovement _movementController;
        private string _logTag;

        private void Reset()
            => id = nameof(Enemy);

        private void Awake()
        {
            _logTag = $"{name}({nameof(Enemy).Colored("#555555")}):";
            _movementController = GetComponent<EnemyMovement>();
            if (_movementController != null)
            {
                _movementController.SetSpeed(speed);
            }
        }

        protected override void OnEnable()
        {
            base.OnEnable();
            //TODO: Get the reference to the player.
            FindTarget();
        }
        
        private void FindTarget()
        {
            if (CharacterService.Instance.TryGetCharacter(playerId, out ICharacter character))
            {
                _player = character;
                Debug.Log($"{_logTag} Target '{playerId}' found successfully!");
            }
            else
            {
                Debug.LogError($"{_logTag} Target '{playerId}' not found!");
            }
        }

        private void Update()
        {
            if (_player != null && _movementController != null)
            {
                _movementController.MoveTo(_player.transform.position);
            }
        }
    }
}