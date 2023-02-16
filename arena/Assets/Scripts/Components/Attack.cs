using UnityEngine;

namespace Components
{
    [RequireComponent(typeof(AnimatorWrapper))]
    public class Attack : MonoBehaviour
    {
        [SerializeField] private string physicsLayerName;
        [SerializeField] private AnimatorWrapper animator;
        
        private float _attackRadius;
        private float _attackCooldown;
        private int _damage;

        private readonly Collider2D[] _hits = new Collider2D[8];
        private int _layerMask;
        private float _cooldown;
        
        private void Awake()
        {
            _layerMask = 1 << LayerMask.NameToLayer(physicsLayerName);
            _cooldown = _attackCooldown;
        }

        private void Update()
        {
            UpdateCooldown();
            TryAttack();
        }

        private void OnDrawGizmos()
        {
            Gizmos.color = Color.magenta;
            Gizmos.DrawWireSphere(transform.position, _attackRadius);
        }
        
        private void UpdateCooldown()
        {
            if (!CooldownIsUp())
            {
                _cooldown -= Time.deltaTime;
            }
        }

        private bool CooldownIsUp()
        {
            return _cooldown <= 0f;
        }

        private void TryAttack()
        {
            if (!CooldownIsUp())
            {
                return;
            }

            _cooldown = _attackCooldown;
            animator.PLayAttack();
        }

        public void OnAttack()
        {
            var size = Hit();
            for (int i = 0; i < size; i++)
            {
                _hits[i].transform.parent.GetComponent<IHealth>().TakeDamage(_damage);
            }
        }
        
        private int Hit()
        {
            return Physics2D.OverlapCircleNonAlloc(transform.position, _attackRadius, _hits, _layerMask);
        }

        public float AttackRadius
        {
            set => _attackRadius = value;
        }

        public float AttackCooldown
        {
            set
            {
                _attackCooldown = value;
                _cooldown = value;
            }
        }

        public int Damage
        {
            set => _damage = value;
        }
    }
}