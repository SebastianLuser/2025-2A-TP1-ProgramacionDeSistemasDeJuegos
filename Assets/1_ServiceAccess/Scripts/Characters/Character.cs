using UnityEngine;

namespace Excercise1
{
    public class Character : MonoBehaviour, ICharacter
    {
        [SerializeField] protected string id;
        private void Awake()
        {
            if (string.IsNullOrWhiteSpace(id)) 
            {
                Debug.LogError($"Character ID cannot be null or empty. Current value: '{id}'");
            }
        }
        protected virtual void OnEnable()
        {
            //TODO: Add to CharacterService. The id should be the given serialized field. 
            RegisterWithService();
        }
        
        protected virtual void OnDisable()
        {
            //TODO: Remove from CharacterService.
            UnregisterFromService();
        }
        
        private void RegisterWithService()
        {
            if (!CharacterService.Instance.TryAddCharacter(id, this))
            {
                Debug.LogError($"Error in TryAddCharacter - Can't add character with ID: {id}");
            }
        }
        
        private void UnregisterFromService()
        {
            if (!CharacterService.Instance.TryRemoveCharacter(id))
            {
                Debug.LogError($"Error in TryRemoveCharacter - Can't remove character with ID: {id}");
            }
        }
        
    }
}