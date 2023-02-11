using Infrastructure.States.Interfaces;
using UnityEngine;

namespace Infrastructure.States
{
    /**
     * Класс, описывающий состояние загрузки игрового уровня.
     */
    public class LoadLevelState : IState
    {
        private readonly GameStateMachine _stateMachine;

        public LoadLevelState(GameStateMachine stateMachine)
        {
            _stateMachine = stateMachine;
        }

        public void Enter()
        {
            Debug.Log("LoadLevelState entered.");
            
            _stateMachine.Enter<GameLoopState>();
        }

        public void Exit()
        {
            Debug.Log("LoadLevelState exited");
        }
    }
}