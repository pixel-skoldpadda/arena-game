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

        public event Action HealthChanged;

        public void TakeDamage(float damage)
        {
            current -= damage;
            HealthChanged?.Invoke();
            progressBar.fillAmount = current / max;
        }

        public float Current => current;
    }
}