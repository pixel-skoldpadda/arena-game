using System;
using System.Collections.Generic;
using Infrastructure.DI;
using Infrastructure.States.Interfaces;

namespace Infrastructure.States
{
    /**
     * Класс, описвающий машину состояний игры.
     */
    public class GameStateMachine
    {
        private readonly Dictionary<Type, IExitableState> _states;
        private IExitableState _activeState;

        public GameStateMachine(DiContainer container)
        {
            _states = new Dictionary<Type, IExitableState>
            {
                [typeof(BootstrapState)] = new BootstrapState(this, container),
                [typeof(LoadLevelState)] = new LoadLevelState(this),
                [typeof(GameLoopState)] = new GameLoopState()
            };
        }
        
        public void Enter<TState>() where TState : class, IState
        {
            IState state = ChangeState<TState>();
            state.Enter();
        }

        private TState GetState<TState>() where TState : class, IExitableState
        {
            return _states[typeof(TState)] as TState;
        }

        private TState ChangeState<TState>() where TState : class, IExitableState
        {
            _activeState?.Exit();
            
            TState state = GetState<TState>();
            _activeState = state;
            
            return state;
        }
    }
}