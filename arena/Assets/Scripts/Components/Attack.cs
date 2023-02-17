using UnityEngine;

namespace Components
{
    [RequireComponent(typeof(AnimatorWrapper))]
    public class Attack : MonoBehaviour
    {
        [SerializeField] private string physicsLayerName;
        [SerializeField] private AnimatorWrapper animator;
        [SerializeField] private AudioSource audioSource;
        
        private readonly Collider2D[] _hits = new Collider2D[8];
        private int _layerMask;
        protected float Cooldown;
        
        protected float CurrentAttackCooldown;
        protected float CurrentAttackRadius;
        protected int CurrentDamage;

        private void Awake()
        {
            _layerMask = 1 << LayerMask.NameToLayer(physicsLayerName);
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
                Cooldown -= Time.deltaTime;
            }
        }

        private bool CooldownIsUp()
        {
            return Cooldown <= 0f;
        }

        private void TryAttack()
        {
            if (!CooldownIsUp())
            {
                return;
            }

            Cooldown = AttackCooldown;
            animator.PLayAttack();
            
            var size = Hit();
            if (size > 0)
            {
                if (audioSource != null)
                {
                    audioSource.Play();    
                }
                
                for (int i = 0; i < size; i++)
                {
                    _hits[i].transform.parent.GetComponent<IHealth>().TakeDamage(Damage);
                }
            }
        }

        private int Hit()
        {
            return Physics2D.OverlapCircleNonAlloc(transform.position, AttackRadius, _hits, _layerMask);
        }

        public virtual float AttackRadius
        {
            set => CurrentAttackRadius = value;
            get => CurrentAttackRadius;
        }

        public virtual float AttackCooldown
        {
            set
            {
                CurrentAttackCooldown = value;
                Cooldown = value;
            }
            get => CurrentAttackCooldown;
        }

        public virtual int Damage
        {
            set => CurrentDamage = value;
            get => CurrentDamage;
        }
    }
}