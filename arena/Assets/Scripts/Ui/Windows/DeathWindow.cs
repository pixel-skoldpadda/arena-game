using Infrastructure.States;

namespace Ui.Windows
{
    public class DeathWindow : Window
    {
        private IGameStateMachine _gameStateMachine;
        
        public void Construct(IGameStateMachine gameStateMachine)
        {
            _gameStateMachine = gameStateMachine;
        }
        
        public void OnQuitButtonPressed(string sceneName)
        {
            _gameStateMachine.Enter<LoadSceneState, string>(sceneName);
        }
    }
}