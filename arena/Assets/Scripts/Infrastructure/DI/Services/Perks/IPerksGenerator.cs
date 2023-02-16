using Items.Perks;

namespace Infrastructure.DI.Services.Perks
{
    public interface IPerksGenerator : IService
    {
        Perk GenerateRandomPerk();
        bool HasPerks();
    }
}