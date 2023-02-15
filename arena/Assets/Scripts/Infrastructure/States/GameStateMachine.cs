using System;
using System.Collections.Generic;
using Infrastructure.DI;
using Infrastructure.DI.Services.Factory.Game;
using Infrastructure.DI.Services.Factory.Ui;
using Infrastructure.States.Interfaces;
using Ui;
using IExitableState = Infrastructure.States.Interfaces.IExitableState;

namespace Infrastructure.States
{
    /**
     * Класс, описвающий машину состояний игры.
     */
    public class GameStateMachine : IGameStateMachine
    {
        private readonly Dictionary<Type, IExitableState> _states;
        private IExitableState _activeState;

        public GameStateMachine(DiContainer container, SceneLoader sceneLoader, LoadingCurtain loadingCurtain)
        {
            _states = new Dictionary<Type, IExitableState>
            {
                [typeof(BootstrapState)] = new BootstrapState(container, this, sceneLoader),
                [typeof(LoadSceneState)] = new LoadSceneState(this, 
                    container.Get<IGameFactory>(), 
                    container.Get<IUiFactory>(), 
                    sceneLoader,
                    loadingCurtain),
                [typeof(GameLoopState)] = new GameLoopState()
            };
        }
        
        public void Enter<TState>() where TState : class, IState
        {
            IState state = ChangeState<TState>();
            state.Enter();
        }

        public void Enter<TState, TPayload>(TPayload payload) where TState : class, IPayLoadedState<TPayload>
        {
            IPayLoadedState<TPayload> state = ChangeState<TState>();
            state.Enter(payload);
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