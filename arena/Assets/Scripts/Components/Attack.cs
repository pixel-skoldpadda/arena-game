using UnityEngine;

namespace Components
{
    [RequireComponent(typeof(AnimatorWrapper))]
    public class Attack : MonoBehaviour
    {
        [SerializeField] private float attackRadius;
        [SerializeField] private string physicsLayerName;
        [SerializeField] private float attackCooldown = 3f;
        [SerializeField] private float damage = 5f;
        [SerializeField] private AnimatorWrapper animator;

        private readonly Collider2D[] _hits = new Collider2D[8];
        private int _layerMask;
        private float _cooldown;

        private void Awake()
        {
            _layerMask = 1 << LayerMask.NameToLayer(physicsLayerName);
            _cooldown = attackCooldown;
        }

        private void Update()
        {
            UpdateCooldown();
            TryAttack();
        }

        private void OnDrawGizmos()
        {
            Gizmos.color = Color.magenta;
            Gizmos.DrawWireSphere(transform.position, attackRadius);
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

            _cooldown = attackCooldown;
            animator.PLayAttack();

            var size = Hit();
            for (int i = 0; i < size; i++)
            {
                _hits[i].transform.GetComponent<Health>().TakeDamage(damage);
            }
        }
        
        private int Hit()
        {
            return Physics2D.OverlapCircleNonAlloc(transform.position, attackRadius, _hits, _layerMask);
        }
    }
}