using System;
using UnityEngine;
using UnityEngine.UI;

namespace Components
{
    public class Health : MonoBehaviour
    {
        [SerializeField] private Image progressBar;
        private float _maxHp;
        private float _current;

        public event Action HealthChanged;

        public void TakeDamage(float damage)
        {
            _current -= damage;
            HealthChanged?.Invoke();
            progressBar.fillAmount = _current / _maxHp;
        }

        public float Current => _current;

        public float MaxHp
        {
            set
            {
                _maxHp = value;
                _current = value;
            }
        }
    }
}