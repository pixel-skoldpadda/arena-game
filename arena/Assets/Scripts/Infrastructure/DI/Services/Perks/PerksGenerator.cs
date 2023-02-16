using System;
using System.Collections.Generic;
using System.Linq;
using Infrastructure.DI.Services.Items;
using Items.Perks;

namespace Infrastructure.DI.Services.Perks
{
    public class PerksGenerator : IPerksGenerator
    {
        private readonly List<Perk> _allPerks;

        public PerksGenerator(IItemsService itemsService)
        {
            _allPerks = new List<Perk>(itemsService.AllPerks);
        }

        public Perk GenerateRandomPerk()
        {
            int perksSize = _allPerks.Count();
            if (perksSize <= 0)
            {
                return null;
            }

            Random random = new Random();
            int generatedIndex = random.Next(0, perksSize);

            Perk perk = _allPerks[generatedIndex];
            _allPerks.RemoveAt(generatedIndex);
            
            return perk;
        }

        public bool HasPerks()
        {
            return _allPerks.Count > 0;
        }
    }
}