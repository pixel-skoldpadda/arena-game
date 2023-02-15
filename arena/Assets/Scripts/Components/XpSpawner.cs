using Infrastructure.DI.Services.Factory;
using UnityEngine;

namespace Components
{
    [RequireComponent(typeof(EnemyDeath))]
    public class XpSpawner : MonoBehaviour
    {
        [SerializeField] private EnemyDeath enemyDeath;

        private IGameFactory _gameFactory;

        public void Construct(IGameFactory gameFactory)
        {
            _gameFactory = gameFactory;
        }
        
        private void Start()
        {
            enemyDeath.OnDie += SpawnXp;
        }
        
        private void SpawnXp()
        {
            _gameFactory.CreateXp(transform.position);
        }
    }
}