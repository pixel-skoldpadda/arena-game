using Infrastructure.States.Interfaces;
using UnityEngine;

namespace Infrastructure.States
{
    public class LoadSceneState : IPayLoadedState<string>
    {
        private readonly SceneLoader _sceneLoader;

        public LoadSceneState(SceneLoader sceneLoader)
        {
            _sceneLoader = sceneLoader;
        }

        public void Enter(string payload)
        {
            Debug.Log($"Load scene {payload} state entered.");
            _sceneLoader.Load(payload);
        }

        public void Exit()
        {
            Debug.Log("LoadSceneState exited.");
        }
    }
}