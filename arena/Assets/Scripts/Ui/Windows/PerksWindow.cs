using Infrastructure.DI.Services.Perks;
using Infrastructure.DI.Services.StateService;
using Items.Perks;
using UnityEngine;

namespace Ui.Windows
{
    public class PerksWindow : MonoBehaviour
    {
        [SerializeField] private GameObject girdItemPrefab;
        [SerializeField] private GameObject grid;

        private GameState _gameState;
        private IPerksGenerator _perksGenerator;
        
        public void Construct(IGameStateService gameStateService, IPerksGenerator perksGenerator)
        {
            _gameState = gameStateService.State;
            _perksGenerator = perksGenerator;

            Init();
        }

        private void Init()
        {
            Perk perk = _perksGenerator.GenerateRandomPerk();
            PerkGridItem perkGridItem = Instantiate(girdItemPrefab, grid.transform).GetComponent<PerkGridItem>();
            perkGridItem.Construct(this);
            perkGridItem.Init(perk);
        }

        public void OnPerkTaken(Perk perk)
        {
            _gameState.AddPerk(perk);
            Close();
            
        }
        
        private void Close()
        {
            Destroy(gameObject);
        }
    }
}