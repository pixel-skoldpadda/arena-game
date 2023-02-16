using System;
using System.Collections.Generic;
using Infrastructure.DI.Services.Items;
using Items.Perks;

namespace Infrastructure.DI.Services.Perks
{
    public class PerksGenerator : IPerksGenerator
    {
        private const int MaxPerksToGenerate = 3;
        private List<Perk> _allPerks;
        private readonly IItemsService _items;
        
        public PerksGenerator(IItemsService items)
        {
            _items = items;
        }

        public void Init()
        {
            _allPerks = new List<Perk>(_items.AllPerks);
        }
        
        public void RemoveChosenPerk(Perk chosen)
        {
            _allPerks.Remove(chosen);
        }
        
        public List<Perk> GeneratePerks()
        {
            int perksSize = _allPerks.Count;
            if (perksSize <= 0)
            {
                return null;
            }

            if (perksSize <= MaxPerksToGenerate)
            {
                return _allPerks;
            }
            
            List<Perk> generatedPerks = new List<Perk>(MaxPerksToGenerate);

            Random random = new Random();
            int index = random.Next(0, perksSize);

            AddPerks(generatedPerks, index);
            if (generatedPerks.Count < MaxPerksToGenerate)
            {
                AddPerks(generatedPerks, 0);
            }

            return generatedPerks;
        }

        private void AddPerks(List<Perk> to, int from)
        {
            int perksSize = _allPerks.Count;
            for (int i = from; i < perksSize; i++)
            {
                to.Add(_allPerks[i]);
                if (to.Count == MaxPerksToGenerate)
                {
                    break;
                }
            }
        }
        
        public bool HasPerks()
        {
            return _allPerks.Count > 0;
        }
    }
}