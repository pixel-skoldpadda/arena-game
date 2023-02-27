using Infrastructure.DI.Services.StateService;
using Items.Perks;
using UnityEngine;

namespace Ui.HUD
{
    public class ActivePerksContainer : MonoBehaviour
    {
        [SerializeField] private Transform gridTransform;
        [SerializeField] private GameObject gridItemPrefab;
        
        private GameState _gameState;

        public void Construct(IGameStateService gameStateService)
        {
            _gameState = gameStateService.State;
            _gameState.OnNewPerkAdded += AddNewPerk;
        }

        private void OnDestroy()
        {
            _gameState.OnNewPerkAdded -= AddNewPerk;
        }

        private void AddNewPerk(Perk perk)
        {
            Instantiate(gridItemPrefab, gridTransform).GetComponent<ActivePerk>().SetIcon(perk.Icon);
        }
    }
}