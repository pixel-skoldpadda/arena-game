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
        private const string MenuScene = "MenuScene";
        private readonly DiContainer _container;
        private readonly IGameStateMachine _gameStateMachine;
        private readonly SceneLoader _sceneLoader;
        
        public BootstrapState(DiContainer container, IGameStateMachine gameStateMachine, SceneLoader sceneLoader)
        {
            _container = container;
            _gameStateMachine = gameStateMachine;
            _sceneLoader = sceneLoader;
            
            BindServices();
        }

        public void Enter()
        {
            Debug.Log("BootstrapState entered.");
            _sceneLoader.Load(MenuScene);
        }

        public void Exit()
        {
            Debug.Log("BootstrapState exited.");
        }

        private void BindServices()
        {
            Debug.Log("Binding services.");

            _container.Bind(_gameStateMachine);
            
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