using Infrastructure.States.Interfaces;
using UnityEngine;

namespace Infrastructure.States
{
    /**
     * Класс, описывающий состояние игрового цикла.
     */
    public class GameLoopState : IState
    {
        public void Enter()
        {
            Debug.Log("GameLoopState entered.");
        }

        public void Exit()
        {
            Debug.Log("GameLoopState exited.");
        }
    }
}