using System.Collections.Generic;
using Infrastructure.DI.Services.Windows;
using Items;
using Items.Perks;
using Items.Windows;

namespace Infrastructure.DI.Services.Items
{
    public interface IItemsService : IService
    {
        void LoadItems();
        EnemyItem ForEnemy(EnemyType type);
        CharacterItem CharacterItem { get; }
        List<Perk> AllPerks { get; }
        WindowItem ForWindow(WindowType type);
    }
}