using System;
using System.Collections.Generic;
using Infrastructure.DI;
using Infrastructure.DI.Services.Factory.Game;
using Infrastructure.DI.Services.Factory.Ui;
using Infrastructure.DI.Services.Game;
using Infrastructure.DI.Services.Items;
using Infrastructure.DI.Services.StateService;
using Infrastructure.States.Interfaces;
using Ui;

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
                [typeof(LoadLevelState)] = new LoadLevelState(this, 
                    container.Get<IGameFactory>(), 
                    container.Get<IUiFactory>(),
                    container.Get<IGameManager>(),
                    sceneLoader,
                    loadingCurtain,
                    container.Get<IGameStateService>(),
                    container.Get<IItemsService>()),
                [typeof(GameLoopState)] = new GameLoopState(),
                [typeof(LoadSceneState)] = new LoadSceneState(sceneLoader)
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