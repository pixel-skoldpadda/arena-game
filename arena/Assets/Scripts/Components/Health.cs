using System;
using UnityEngine;
using UnityEngine.UI;

namespace Components
{
    public class Health : MonoBehaviour
    {
        [SerializeField] private Image progressBar;
        [SerializeField] protected float max;
        [SerializeField] protected float current;

        private event Action _healthChanged;

        public void TakeDamage(float damage)
        {
            current -= damage;
            _healthChanged?.Invoke();
            progressBar.fillAmount = current / max;
        }

        private Action HealthChanged => _healthChanged;
    }
}