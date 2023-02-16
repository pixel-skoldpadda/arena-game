using Infrastructure.DI.Services.StateService;
using TMPro;
using UnityEngine;

namespace Ui.HUD
{
    public class CoinsContainer : MonoBehaviour
    {
        [SerializeField] private TextMeshProUGUI coinsCounter;

        private GameState _gameState;
        
        public void Construct(IGameStateService gameStateService)
        {
            _gameState = gameStateService.State;
            _gameState.CoinsChanged += UpdateCounter;
        }

        private void UpdateCounter()
        {
            coinsCounter.text = $"{_gameState.Coins}";
        }

        private void OnDestroy()
        {
            _gameState.CoinsChanged -= UpdateCounter;
        }
    }
}