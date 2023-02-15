using UnityEngine;

namespace Items
{
    [CreateAssetMenu(fileName = "Character", menuName = "Items/Character", order = 0)]
    public class CharacterItem : ScriptableObject
    {
        public GameObject prefab;
        
        [Range(1, 500)]
        public int health;
        
        [Range(1f, 100f)]
        public float damage;

        [Range(1f, 10f)]
        public float attackCooldown;

        [Range(.1f, 1f)]
        public float attackRadius;
        
        [Range(.5f, 5f)]
        public float speed;
    }
}