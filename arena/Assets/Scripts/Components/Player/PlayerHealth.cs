using System;
using Items.Perks;
using UnityEngine;
using UnityEngine.UI;

namespace Components.Player
{
    public class PlayerHealth : MonoBehaviour, IHealth
    {
        [SerializeField] private Image progressBar;
        
        private float _maxHp;
        private float _current;
        private GameState _gameState;

        private Action _healthChanged;

        public void Construct(GameState gameState)
        {
            _gameState = gameState;
            _gameState.OnHealthAdded += AddHealth;
        }

        private void OnDestroy()
        {
            _gameState.OnHealthAdded -= AddHealth;
        }

        private void AddHealth(int amount)
        {
            _current = Math.Min(_current + amount, MaxHp);
            _healthChanged?.Invoke();
            progressBar.fillAmount = _current / MaxHp;
        }

        public void TakeDamage(int damage)
        {
            _current -= damage;
            _healthChanged?.Invoke();
            progressBar.fillAmount = _current / MaxHp;
        }
        
        public float Current => _current;

        public float MaxHp
        {
            set
            {
                _maxHp = value;
                _current = value;
            }
            get
            {
                HealthPerk healthPerk = _gameState.GetPerk<HealthPerk>();
                return healthPerk != null ? _maxHp + healthPerk.healthAmount : _maxHp;
            }
        }

        public Action HealthChanged
        {
            get => _healthChanged;
            set => _healthChanged = value;
        }
    }
}