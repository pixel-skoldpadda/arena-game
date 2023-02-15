using System;
using UnityEngine;
using UnityEngine.UI;

namespace Components.Player
{
    public class PlayerHealth : MonoBehaviour, IHealth
    {
        [SerializeField] private Image progressBar;
        private float _maxHp;
        private float _current;

        public event Action HealthChanged;

        public void TakeDamage(int damage)
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