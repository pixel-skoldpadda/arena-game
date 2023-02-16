using Infrastructure.States;
using UnityEngine;

namespace Ui.Windows
{
    public class DeathWindow : MonoBehaviour
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