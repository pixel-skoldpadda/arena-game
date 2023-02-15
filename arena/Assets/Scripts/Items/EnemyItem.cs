using UnityEngine;

namespace Items
{
    [CreateAssetMenu(fileName = "Enemy", menuName = "Items/Enemy", order = 0)]
    public class EnemyItem : ScriptableObject
    {
        public EnemyType type;
        
        public GameObject prefab;
        
        [Range(1, 500)]
        public int health;
        
        [Range(1, 100)]
        public int damage;

        [Range(1f, 10f)]
        public float attackCooldown;

        [Range(.1f, 1f)]
        public float attackRadius;
        
        [Range(.5f, 5f)]
        public float speed;

        public int xp;
    }
}