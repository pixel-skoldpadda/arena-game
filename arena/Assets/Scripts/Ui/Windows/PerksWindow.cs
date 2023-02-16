using Infrastructure.DI.Services.StateService;
using UnityEngine;

namespace Ui.Windows
{
    public class PerksWindow : MonoBehaviour
    {
        [SerializeField] private GameObject girdItemPrefab;
        [SerializeField] private GameObject grid;

        private GameState _gameState;

        public void Construct(IGameStateService gameStateService)
        {
            _gameState = gameStateService.State;

            Init();
        }

        private void Init()
        {
            for (int i = 0; i < 3; i++)
            {
                PerkGridItem perkGridItem = Instantiate(girdItemPrefab, grid.transform).GetComponent<PerkGridItem>();
                perkGridItem.Construct(this);
            }
        }

        public void Close()
        {
            _gameState.AddPerk();
            Destroy(gameObject);
        }
    }
}