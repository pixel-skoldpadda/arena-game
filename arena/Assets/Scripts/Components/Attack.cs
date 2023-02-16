using UnityEngine;

namespace Components
{
    [RequireComponent(typeof(AnimatorWrapper))]
    public class Attack : MonoBehaviour
    {
        [SerializeField] private string physicsLayerName;
        [SerializeField] private AnimatorWrapper animator;

        private float _attackCooldown;
        protected float CurrentAttackRadius;
        protected int CurrentDamage;

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
            Gizmos.DrawWireSphere(transform.position, AttackRadius);
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
                _hits[i].transform.parent.GetComponent<IHealth>().TakeDamage(Damage);
            }
        }
        
        private int Hit()
        {
            return Physics2D.OverlapCircleNonAlloc(transform.position, AttackRadius, _hits, _layerMask);
        }

        public  virtual float AttackRadius
        {
            set => CurrentAttackRadius = value;
            get => CurrentAttackRadius;
        }

        public float AttackCooldown
        {
            set
            {
                _attackCooldown = value;
                _cooldown = value;
            }
        }

        public virtual int Damage
        {
            set => CurrentDamage = value;
            get => CurrentDamage;
        }
    }
}