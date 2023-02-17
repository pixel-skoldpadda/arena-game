using Infrastructure.DI.Services.Factory.Game;
using Items;
using UnityEngine;

namespace Spawner
{
    public class EnemySpawner : MonoBehaviour
    {
        private IGameFactory _gameFactory;
        private GameState _gameState;
        
        private EnemyType _type;
        private int _amount;
        private float _cooldown;
        
        private bool _active;
        private float _spawnTime;

        public void Construct(IGameFactory gameFactory, EnemyType type, int amount, float cooldown, GameState gameState)
        {
            _gameFactory = gameFactory;
            _type = type;
            _amount = amount;
            _cooldown = cooldown;
            _gameState = gameState;

            _gameState.OnGameResumed += Activate;
            _gameState.OnGamePaused += Deactivate;
        }

        private void Update()
        {
            if (!_active)
            {
                return;
            }
            
            UpdateCooldown();
        }

        private void OnDestroy()
        {
            _gameState.OnGameResumed -= Activate;
            _gameState.OnGameResumed -= Deactivate;
        }

        private void Deactivate()
        {
            _active = false;
        }

        private void Activate()
        { 
            _active = true;
        }

        private void UpdateCooldown()
        {
            if (!CooldownIsUp())
            {
                _spawnTime -= Time.deltaTime;
            }
            else
            {
                SpawnEnemy();
                _spawnTime = _cooldown;
            }
        }
        
        private bool CooldownIsUp()
        {
            return _spawnTime <= 0f;
        }
        
        private void SpawnEnemy()
        {
            for (int i = 0; i < _amount; i++)
            {
                _gameFactory.CreateEnemy(_type, transform);   
            }
        }
    }
}