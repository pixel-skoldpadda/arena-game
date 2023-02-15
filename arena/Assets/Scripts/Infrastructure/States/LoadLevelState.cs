using Components.Player;
using Infrastructure.DI.Services.Factory;
using Infrastructure.DI.Services.Factory.Game;
using Infrastructure.DI.Services.Factory.Ui;
using Infrastructure.States.Interfaces;
using Spawner;
using UnityEngine;

namespace Infrastructure.States
{
    /**
     * Класс, описывающий состояние загрузки игрового уровня.
     */
    public class LoadLevelState : IState
    {
        private readonly GameStateMachine _stateMachine;
        private readonly IGameFactory _gameFactory;
        private readonly IUiFactory _uiFactory;
        
        public LoadLevelState(GameStateMachine stateMachine, IGameFactory gameFactory, IUiFactory uiFactory)
        {
            _stateMachine = stateMachine;
            _gameFactory = gameFactory;
            _uiFactory = uiFactory;
        }

        public void Enter()
        {
            Debug.Log("LoadLevelState entered.");

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
        }
    }
}