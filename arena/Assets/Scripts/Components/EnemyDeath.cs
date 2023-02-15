using System;
using System.Collections;
using Components.Enemy;
using Components.Movement;
using UnityEngine;

namespace Components
{
    [RequireComponent(typeof(EnemyHealth), typeof(EnemyMovement), typeof(AnimatorWrapper))]
    public class EnemyDeath : MonoBehaviour
    {
        [SerializeField] private EnemyHealth health;
        [SerializeField] private EnemyMovement movement;
        [SerializeField] private AnimatorWrapper animator;
        
        public Action OnDie;
    
        private void Start()
        {
            health.HealthChanged += HealthChanged;
        }

        private void OnDestroy()
        {
            health.HealthChanged -= HealthChanged;
        }

        private void HealthChanged()
        {
            if (health.Current <= 0f)
            {
                Die();
            }
        }

        private void Die()
        {
            health.HealthChanged -= HealthChanged;
            movement.Pause();
            animator.PlayDeath();
            
            StartCoroutine(DestroyTime());
            
            OnDie?.Invoke();
        }
        
        private IEnumerator DestroyTime()
        {
            yield return new WaitForSeconds(1);
            Destroy(gameObject);
        }
    }
}