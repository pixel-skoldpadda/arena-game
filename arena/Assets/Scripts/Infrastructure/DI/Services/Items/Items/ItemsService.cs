using System.Collections.Generic;
using System.Linq;
using Items;
using UnityEngine;

namespace Infrastructure.DI.Services.Items.Items
{
    public class ItemsService : IItemsService
    {
        private const string EnemyItemsPath = "Items/Enemies";
        private const string CharactersItemsPath = "Items/Characters/Player";
        
        private Dictionary<EnemyType, EnemyItem> _enemies;
        private CharacterItem _characterItem;
        
        public void LoadItems()
        {
            _enemies = Resources.LoadAll<EnemyItem>(EnemyItemsPath)
                .ToDictionary(k => k.type, v => v);

            _characterItem = Resources.Load<CharacterItem>(CharactersItemsPath);
        }
        
        public EnemyItem ForEnemy(EnemyType type)
        {
            return _enemies.TryGetValue(type, out EnemyItem item) ? item : null;
        }

        public CharacterItem CharacterItem => _characterItem;
    }
}