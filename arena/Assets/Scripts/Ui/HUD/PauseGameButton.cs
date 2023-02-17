using Infrastructure.DI;
using Infrastructure.DI.Services.StateService;
using Infrastructure.DI.Services.Windows;
using UnityEngine;
using UnityEngine.UI;

namespace Ui.HUD
{
    public class PauseGameButton : MonoBehaviour
    {
        [SerializeField] private Button button;
        
        private GameState _gameState;

        public void Construct(IGameStateService gameStateService)
        {
            _gameState = gameStateService.State;
        }

        public void OnButtonPressed()
        {
            DiContainer.Container.Get<IWindowsService>().Open(WindowType.Pause);
            _gameState.IsGameRunning = false;
        }

        public void Disable()
        {
            button.enabled = false;
        }

        public void Enable()
        {
            button.enabled = true;
        }
    }
}