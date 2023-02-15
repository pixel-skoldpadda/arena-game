using Items;

namespace Infrastructure.DI.Services.Items.Items
{
    public interface IItemsService : IService
    {
        void LoadItems();
        EnemyItem ForEnemy(EnemyType type);
        CharacterItem CharacterItem { get; }
    }
}