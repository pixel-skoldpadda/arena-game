using Infrastructure.DI.Services.Windows;
using Items;
using Items.Windows;

namespace Infrastructure.DI.Services.Items
{
    public interface IItemsService : IService
    {
        void LoadItems();
        EnemyItem ForEnemy(EnemyType type);
        CharacterItem CharacterItem { get; }
        WindowItem ForWindow(WindowType type);
    }
}