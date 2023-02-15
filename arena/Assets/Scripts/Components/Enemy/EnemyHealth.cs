using System;
using Infrastructure.DI.Services.Factory;
using UnityEngine;

namespace Components.Enemy
{
    public class EnemyHealth : MonoBehaviour, IHealth 
    {
        public event Action HealthChanged;
        private float _current;

        private IGameFactory _gameFactory;

        public void Construct(IGameFactory gameFactory)
        {
            _gameFactory = gameFactory;
        }

        public void TakeDamage(int damage)
        {
            _current -= damage;
            HealthChanged?.Invoke();
            
            FloatingText floatingText = _gameFactory.CreateFloatingText(transform);
            floatingText.Play($"{damage}");
        }
        
        public float Current => _current;

        public float MaxHp
        {
            set => _current = value;
        }
    }
}