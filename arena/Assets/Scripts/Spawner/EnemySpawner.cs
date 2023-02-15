using Infrastructure.DI.Services.Factory;
using Infrastructure.DI.Services.Factory.Game;
using Items;
using UnityEngine;

namespace Spawner
{
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
            _gameFactory.CreateEnemy(_type, transform);
        }
    }
}