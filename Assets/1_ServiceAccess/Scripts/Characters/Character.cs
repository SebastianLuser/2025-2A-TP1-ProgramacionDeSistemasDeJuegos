using UnityEngine;

namespace Excercise1
{
    public class Character : MonoBehaviour, ICharacter
    {
        [SerializeField] protected string id;
        public string Id => id;
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
            CharacterService.Instance.TryAddCharacter(id, this);
        }
        
        private void UnregisterFromService()
        {
            if (string.IsNullOrEmpty(id))
                return;
                
            CharacterService.Instance.TryRemoveCharacter(id);
        }
        
    }
}