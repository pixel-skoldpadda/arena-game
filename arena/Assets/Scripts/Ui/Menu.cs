using Infrastructure.DI;
using Infrastructure.States;
using UnityEngine;

namespace Ui
{
    public class Menu : MonoBehaviour
    {
        public void OnPlayButtonPressed(string sceneName)
        {
            IGameStateMachine gameStateMachine = DiContainer.Container.Get<IGameStateMachine>();
            gameStateMachine.Enter<LoadSceneState, string>(sceneName);
        }

        public void OnExitButtonPressed()
        {
            Application.Quit();
        }
    }
}