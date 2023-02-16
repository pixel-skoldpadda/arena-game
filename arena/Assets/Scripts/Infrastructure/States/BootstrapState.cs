using Infrastructure.DI;
using Infrastructure.DI.Services.AssetsManagement;
using Infrastructure.DI.Services.Factory.Game;
using Infrastructure.DI.Services.Factory.Ui;
using Infrastructure.DI.Services.Game;
using Infrastructure.DI.Services.Generator;
using Infrastructure.DI.Services.Input;
using Infrastructure.DI.Services.Items;
using Infrastructure.DI.Services.Perks;
using Infrastructure.DI.Services.StateService;
using Infrastructure.DI.Services.Windows;
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
            ILevelXpGenerator levelXpGenerator = new LevelXpGenerator();
            _container.Bind(levelXpGenerator);
            
            IGameStateService gameStateService = new GameStateService();
            gameStateService.State = new GameState();
            _container.Bind(gameStateService);

            IItemsService itemsService = new ItemsService();
            itemsService.LoadItems();
            _container.Bind(itemsService);
            
            _container.Bind<IInputService>(new InputService());
            
            IAssetProvider assetsProvider = new AssetsProvider();
            _container.Bind(assetsProvider);

            IPerksGenerator perksGenerator = new PerksGenerator(itemsService);
            _container.Bind(perksGenerator);
            
            IUiFactory uiFactory = new UiFactory(assetsProvider, gameStateService, itemsService, perksGenerator);
            _container.Bind(uiFactory);

            IWindowsService windowsService = new WindowsService(uiFactory);
            _container.Bind(windowsService);
            
            IGameManager gameManager = new GameManager(gameStateService, levelXpGenerator, windowsService, perksGenerator);
            _container.Bind(gameManager);
            
            _container.Bind<IGameFactory>(new GameFactory(
                assetsProvider, 
                itemsService, 
                gameStateService, 
                gameManager));
        }
    }
}