using Components.Player;
using Infrastructure.DI.Services.Factory;
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
        
        public LoadLevelState(GameStateMachine stateMachine, IGameFactory gameFactory)
        {
            _stateMachine = stateMachine;
            _gameFactory = gameFactory;
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

            GameObject player = CreatePlayer();
            CameraFollow(player);
            CreateSpawners(player.transform);
        }

        private void CreateSpawners(Transform playerTransform)
        {
            GameObject[] markers = GameObject.FindGameObjectsWithTag("Spawner");
            foreach (GameObject marker in markers)
            {
                SpawnerMarker spawnerMarker = marker.GetComponent<SpawnerMarker>();
                EnemySpawner enemySpawner = _gameFactory.CreateSpawner(marker.transform.position).GetComponent<EnemySpawner>();
                enemySpawner.Construct(_gameFactory, playerTransform.transform, spawnerMarker.EnemyType);
                enemySpawner.SpawnEnemy();
            }
        }
        
        private GameObject CreatePlayer()
        {
            GameObject gameObject = _gameFactory.CreatePlayer(Vector3.zero);
            return gameObject;
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