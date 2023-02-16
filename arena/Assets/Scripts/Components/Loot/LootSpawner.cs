using System;
using System.Collections.Generic;
using System.Linq;
using Infrastructure.DI.Services.Factory.Game;
using Infrastructure.DI.Services.Items;
using Items.Loot;
using UnityEngine;
using Random = System.Random;

namespace Components.Loot
{
    [RequireComponent(typeof(EnemyDeath))]
    public class LootSpawner : MonoBehaviour
    {
        [SerializeField] private EnemyDeath enemyDeath;

        private IItemsService _items;
        private IGameFactory _gameFactory;
        
        public void Construct(IItemsService items, IGameFactory gameFactory)
        {
            _gameFactory = gameFactory;
            _items = items;
        }

        private void Start()
        {
            enemyDeath.OnDie += SpawnXp;
        }
        
        private void SpawnXp()
        {
            List<LootType> types = Enum.GetValues(typeof(LootType)).Cast<LootType>().ToList();
            Random random = new Random();
            int index = random.Next(0, types.Count - 1);
            _gameFactory.CreateLoot(_items.ForLoot(types[index]), transform.position);
        }
    }
}