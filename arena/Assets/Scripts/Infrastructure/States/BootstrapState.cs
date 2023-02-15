using Infrastructure.DI;
using Infrastructure.DI.Services.AssetsManagement;
using Infrastructure.DI.Services.Data;
using Infrastructure.DI.Services.Factory.Game;
using Infrastructure.DI.Services.Factory.Ui;
using Infrastructure.DI.Services.Input;
using Infrastructure.DI.Services.Items.Items;
using Infrastructure.States.Interfaces;
using UnityEngine;

namespace Infrastructure.States
{
    /**
     * Класс, описывающий состояние начальной загрузки/инициализации необходимых компонентов игры.
     */
    public class BootstrapState : IState
    {
        private readonly GameStateMachine _stateMachine;
        private readonly DiContainer _container;

        public BootstrapState(GameStateMachine stateMachine, DiContainer container)
        {
            _stateMachine = stateMachine;
            _container = container;
            
            BindServices();
        }

        public void Enter()
        {
            Debug.Log("BootstrapState entered.");
            _stateMachine.Enter<LoadLevelState>();
        }

        public void Exit()
        {
            Debug.Log("BootstrapState exited.");
        }

        private void BindServices()
        {
            Debug.Log("Binding services.");

            IGameStateService gameStateService = new GameStateService();
            gameStateService.State = new GameState();
            _container.Bind(gameStateService);

            IItemsService itemsService = new ItemsService();
            itemsService.LoadItems();
            _container.Bind(itemsService);
            
            _container.Bind<IInputService>(new InputService());
            
            IAssetProvider assetsProvider = new AssetsProvider();
            _container.Bind(assetsProvider);
            
            _container.Bind<IUiFactory>(new UiFactory(assetsProvider, gameStateService));
            _container.Bind<IGameFactory>(new GameFactory(assetsProvider, itemsService, gameStateService));
        }
    }
}