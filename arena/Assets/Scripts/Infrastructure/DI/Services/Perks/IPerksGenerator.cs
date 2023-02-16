using System.Collections.Generic;
using Items.Perks;

namespace Infrastructure.DI.Services.Perks
{
    public interface IPerksGenerator : IService
    {
        bool HasPerks();
        void RemoveChosenPerk(Perk chosen);
        List<Perk> GeneratePerks();
        void Init();
    }
}