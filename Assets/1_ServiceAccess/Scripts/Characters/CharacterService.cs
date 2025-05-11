using System.Collections.Generic;
using UnityEngine;

namespace Excercise1
{
    public class CharacterService : MonoBehaviour
    {
        private static CharacterService _instance;
        
        private readonly Dictionary<string, ICharacter> _charactersById = new();
        
        public static CharacterService Instance 
        {
            get
            {
                if (_instance == null)
                {
                    _instance = FindObjectOfType<CharacterService>();
                    
                    if (_instance == null)
                    {
                        Debug.LogError("CharacterService not found in scene!");
                    }
                }
                return _instance;
            }
        }
        
        private void Awake()
        {
            InitializeSingleton();
        }
        
        private void InitializeSingleton()
        {
            if (_instance != null && _instance != this)
            {
                Destroy(gameObject);
                return;
            }
            
            _instance = this;
        }

        public void TryAddCharacter(string id, ICharacter character)
        {
            if (string.IsNullOrEmpty(id))
            {
                Debug.LogError("Cannot add character with empty ID");
                return;
            }

            _charactersById.TryAdd(id, character);
        }
        public void TryRemoveCharacter(string id)
        {
            if (string.IsNullOrEmpty(id))
            {
                Debug.LogWarning("Attempted to remove character with empty ID");
                return;
            }

            _charactersById.Remove(id);
        }
        
        public bool TryGetCharacter(string id, out ICharacter character)
        {
            if (string.IsNullOrEmpty(id))
            {
                character = null;
                return false;
            }
            
            return _charactersById.TryGetValue(id, out character);
        }
    }
}
