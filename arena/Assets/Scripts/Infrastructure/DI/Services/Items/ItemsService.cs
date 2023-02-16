using System.Collections.Generic;
using System.Linq;
using Infrastructure.DI.Services.Windows;
using Items;
using Items.Perks;
using Items.Windows;
using UnityEngine;

namespace Infrastructure.DI.Services.Items
{
    public class ItemsService : IItemsService
    {
        private const string EnemyItemsPath = "Items/Enemies";
        private const string CharactersItemsPath = "Items/Characters/Player";
        private const string PerkItemsPath = "Items/Perks";
        private const string WindowsItemsPath = "Items/Windows";
        
        private Dictionary<EnemyType, EnemyItem> _enemies;
        private Dictionary<PerkType, PerkItem> _perksItems;
        private Dictionary<WindowType, WindowItem> _windowItems;
        private CharacterItem _characterItem;
        
        public void LoadItems()
        {
            _enemies = Resources.LoadAll<EnemyItem>(EnemyItemsPath)
                .ToDictionary(k => k.type, v => v);

            _perksItems = Resources.LoadAll<PerkItem>(PerkItemsPath)
                .ToDictionary(k => k.type, v => v);
            
            _windowItems = Resources.LoadAll<WindowItem>(WindowsItemsPath)
                .ToDictionary(k => k.type, v => v);
            
            _characterItem = Resources.Load<CharacterItem>(CharactersItemsPath);
        }
        
        public EnemyItem ForEnemy(EnemyType type)
        {
            return _enemies.TryGetValue(type, out EnemyItem item) ? item : null;
        }
        
        public WindowItem ForWindow(WindowType type)
        {
            return _windowItems.TryGetValue(type, out WindowItem item) ? item : null;
        }

        public CharacterItem CharacterItem => _characterItem;
    }
}