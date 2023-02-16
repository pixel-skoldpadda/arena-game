using System;
using System.Collections;
using UnityEngine;

namespace Components.Player
{
    [RequireComponent(typeof(PlayerHealth), typeof(Movement.Movement), typeof(AnimatorWrapper))]
    public class PlayerDeath : MonoBehaviour
    {
        [SerializeField] private PlayerHealth health;
        [SerializeField] private Movement.Movement movement;
        [SerializeField] private AnimatorWrapper animator;
        
        private Action _onDie;
        
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
            OnDie?.Invoke();
        }

        public Action OnDie
        {
            get => _onDie;
            set => _onDie = value;
        }
    }
}