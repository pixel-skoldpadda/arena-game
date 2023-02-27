using UnityEngine;

namespace Items
{
    [CreateAssetMenu(fileName = "Enemy", menuName = "Items/Enemy", order = 0)]
    public class EnemyItem : ScriptableObject
    {
        [SerializeField] private EnemyType type;
        
        [SerializeField] private GameObject prefab;
        
        [Range(1, 500)]
        [SerializeField] private int health;
        
        [Range(1, 100)]
        [SerializeField] private int damage;

        [Range(1f, 10f)]
        [SerializeField] private float attackCooldown;

        [Range(.1f, 1f)] 
        [SerializeField] private float attackRadius;
        
        [Range(.5f, 5f)]
        [SerializeField] private float speed;

        public EnemyType Type => type;

        public GameObject Prefab => prefab;

        public int Health => health;

        public int Damage => damage;

        public float AttackCooldown => attackCooldown;

        public float AttackRadius => attackRadius;

        public float Speed => speed;
    }
}