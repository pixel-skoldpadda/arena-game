using Infrastructure.DI.Services.Factory.Game;
using Items;
using UnityEngine;

namespace Spawner
{
    // todo: Улучшить спавнеры
    public class EnemySpawner : MonoBehaviour
    {
        private EnemyType _type;
        private IGameFactory _gameFactory;

        public void Construct(IGameFactory gameFactory, EnemyType type)
        {
            _gameFactory = gameFactory;
            _type = type;
        }

        public void SpawnEnemy()
        {
            for (int i = 0; i < 5; i++)
            {
                _gameFactory.CreateEnemy(_type, transform);   
            }
        }
    }
}