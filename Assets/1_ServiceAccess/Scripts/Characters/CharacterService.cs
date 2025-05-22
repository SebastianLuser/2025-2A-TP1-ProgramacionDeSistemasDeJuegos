using System.Collections.Generic;
using UnityEngine;

namespace Excercise1
{
    public class CharacterService : MonoBehaviour
    {
        private readonly Dictionary<string, ICharacter> _charactersById = new();
        public static CharacterService Instance { get; private set; }
        
        private void Awake()
        {
            InitializeSingleton();
        }
        
        private void InitializeSingleton()
        {
            if (Instance != null && Instance != this)
            {
                Destroy(gameObject);
                return;
            }
            
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }

        public bool TryAddCharacter(string id, ICharacter character)
        {
            if (string.IsNullOrEmpty(id))
            {
                Debug.LogError("Cannot add character with empty ID");
                return false;
            }

            return  _charactersById.TryAdd(id, character);
        }
        public bool TryRemoveCharacter(string id)
        {
            if (string.IsNullOrEmpty(id))
            {
                Debug.LogWarning("Attempted to remove character with empty ID");
                return false;
            }

            return  _charactersById.Remove(id);
        }
        
        public bool TryGetCharacter(string id, out ICharacter character)
        {
            if (string.IsNullOrEmpty(id))
            {
                character = null;
                Debug.LogWarning("TryGetCharacter get an empty ID");
                return false;
            }
            
            return _charactersById.TryGetValue(id, out character);
        }
    }
}
