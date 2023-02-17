using System.Collections.Generic;
using Components.Player;
using Infrastructure.DI.Services.Factory.Game;
using Infrastructure.DI.Services.Factory.Ui;
using Infrastructure.DI.Services.Game;
using Infrastructure.DI.Services.Items;
using Infrastructure.DI.Services.StateService;
using Infrastructure.States.Interfaces;
using Spawner;
using Ui;
using UnityEngine;

namespace Infrastructure.States
{
    /**
     * Класс, описывающий состояние загрузки игрового уровня.
     */
    public class LoadLevelState : IPayLoadedState<string>
    {
        private readonly GameStateMachine _stateMachine;
        private readonly IGameFactory _gameFactory;
        private readonly IUiFactory _uiFactory;
        private readonly SceneLoader _sceneLoader;
        private readonly LoadingCurtain _loadingCurtain;
        private readonly IGameManager _gameManager;
        private readonly GameState _gameState;
        private readonly IItemsService _items;
        
        public LoadLevelState(GameStateMachine stateMachine, IGameFactory gameFactory, IUiFactory uiFactory, IGameManager gameManager, SceneLoader sceneLoader, 
            LoadingCurtain loadingCurtain, IGameStateService gameStateService, IItemsService items)
        {
            _stateMachine = stateMachine;
            _gameFactory = gameFactory;
            _uiFactory = uiFactory;
            _sceneLoader = sceneLoader;
            _loadingCurtain = loadingCurtain;
            _gameManager = gameManager;
            _gameState = gameStateService.State;
            _items = items;
        }

        public void Enter(string sceneName)
        {
            Debug.Log("LoadLevelState entered.");

            _loadingCurtain.Show();
            _sceneLoader.Load(sceneName, OnLoaded);
        }

        private void OnLoaded()
        {
            InitGameWorld();
            _stateMachine.Enter<GameLoopState>();
        }
        
        private void InitGameWorld()
        {
            Debug.Log("Init game world.");

            _uiFactory.CreateUiRoot();
            _uiFactory.CreateHud();
            GameObject player = CreatePlayer();
            CameraFollow(player);
            CreateSpawners();
            
            _gameManager.InitStartLevel();
        }

        private void CreateSpawners()
        {
            List<SpawnerData> spawnerData = _items.Spawners.SpawnersData;
            foreach (SpawnerData data in spawnerData)
            {
                EnemySpawner enemySpawner = _gameFactory.CreateSpawner(data.Position).GetComponent<EnemySpawner>();
                enemySpawner.Construct(_gameFactory, data.EnemyType, data.Amount, data.Cooldown, _gameState);
            }
        }
        
        private GameObject CreatePlayer()
        {
            return _gameFactory.CreatePlayer(Vector3.zero);
        }
        
        private void CameraFollow(GameObject following)
        {
            Camera.main.GetComponent<CameraFollow>().Follow(following.transform);
        }
        
        public void Exit()
        {
            Debug.Log("LoadLevelState exited");
            _loadingCurtain.Hide();
        }
    }
}