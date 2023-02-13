using Infrastructure.DI.Services.Factory;
using Infrastructure.States.Interfaces;
using Movement;
using Player;
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
        private readonly Transform _playerTransform;
        
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

            CreateEnemy(player.transform);
        }

        private GameObject CreatePlayer()
        {
            GameObject gameObject = _gameFactory.CreatePlayer(Vector3.zero);
            return gameObject;
        }

        private void CreateEnemy(Transform playerTransform)
        {
            Vector3 position = Vector3.zero;
            position.x = -4.5f;

            GameObject enemy = _gameFactory.CreateEnemy(position);
            enemy.GetComponent<EnemyMovement>().Construct(playerTransform);
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