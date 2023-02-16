using Components.Player;
using Infrastructure.DI.Services.Factory.Game;
using Infrastructure.DI.Services.Factory.Ui;
using Infrastructure.States.Interfaces;
using Spawner;
using Ui;
using UnityEngine;

namespace Infrastructure.States
{
    /**
     * Класс, описывающий состояние загрузки игрового уровня.
     */
    public class LoadSceneState : IPayLoadedState<string>
    {
        private readonly GameStateMachine _stateMachine;
        private readonly IGameFactory _gameFactory;
        private readonly IUiFactory _uiFactory;
        private readonly SceneLoader _sceneLoader;
        private readonly LoadingCurtain _loadingCurtain;
        
        public LoadSceneState(GameStateMachine stateMachine, IGameFactory gameFactory, IUiFactory uiFactory, SceneLoader sceneLoader, 
            LoadingCurtain loadingCurtain)
        {
            _stateMachine = stateMachine;
            _gameFactory = gameFactory;
            _uiFactory = uiFactory;
            _sceneLoader = sceneLoader;
            _loadingCurtain = loadingCurtain;
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

            _uiFactory.CreateHud();
            GameObject player = CreatePlayer();
            CameraFollow(player);
            CreateSpawners();

            GameManager gameManager = _gameFactory.CreateGameManager();
            gameManager.InitStartLevel();
        }

        private void CreateSpawners()
        {
            GameObject[] markers = GameObject.FindGameObjectsWithTag("Spawner");
            foreach (GameObject marker in markers)
            {
                SpawnerMarker spawnerMarker = marker.GetComponent<SpawnerMarker>();
                EnemySpawner enemySpawner = _gameFactory.CreateSpawner(marker.transform.position).GetComponent<EnemySpawner>();
                enemySpawner.Construct(_gameFactory, spawnerMarker.EnemyType);
                enemySpawner.SpawnEnemy();
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