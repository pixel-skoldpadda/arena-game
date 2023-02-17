using Infrastructure.DI.Services.StateService;
using Infrastructure.States;

namespace Ui.Windows
{
    public class PauseWindow : Window
    {
        private GameState _gameState;
        private IGameStateMachine _gameStateMachine;

        public void Construct(IGameStateService gameStateService, IGameStateMachine gameStateMachine)
        {
            _gameState = gameStateService.State;
            _gameStateMachine = gameStateMachine;
        }
        
        public void OnQuitButtonPressed(string sceneName)
        {
            _gameStateMachine.Enter<LoadSceneState, string>(sceneName);
        }

        public void OnResumeButtonPressed()
        {
            _gameState.IsGameRunning = true;
            Close();
        }
    }
}