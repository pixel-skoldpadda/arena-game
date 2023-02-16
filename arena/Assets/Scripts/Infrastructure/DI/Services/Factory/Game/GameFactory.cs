using Components;
using Components.Enemy;
using Components.Movement;
using Components.Player;
using Infrastructure.DI.Services.AssetsManagement;
using Infrastructure.DI.Services.Game;
using Infrastructure.DI.Services.Items;
using Infrastructure.DI.Services.StateService;
using Items;
using UnityEngine;

namespace Infrastructure.DI.Services.Factory.Game
{
    public class GameFactory : IGameFactory
    {
        private readonly IAssetProvider _assets;
        private readonly IItemsService _items;
        private readonly GameState _gameState;
        private readonly IGameManager _gameManager;

        private GameObject _playerGameObject;
        
        public GameFactory(IAssetProvider assets, IItemsService items, IGameStateService gameStateService, IGameManager gameManager)
        {
            _assets = assets;
            _items = items;
            _gameState = gameStateService.State;
            _gameManager = gameManager;
        }

        public GameObject CreatePlayer(Vector3 at)
        {
            CharacterItem characterItem = _items.CharacterItem;
            _playerGameObject = Object.Instantiate(characterItem.prefab, at, Quaternion.identity);

            PlayerMovement playerMovement = _playerGameObject.GetComponent<PlayerMovement>();
            playerMovement.Construct(_gameManager, _gameState);
            playerMovement.Speed = characterItem.speed;

            PlayerAttack attack = _playerGameObject.GetComponent<PlayerAttack>();
            attack.Construct(_gameState);
            attack.AttackCooldown = characterItem.attackCooldown;
            attack.AttackRadius = characterItem.attackRadius;
            attack.Damage = characterItem.damage;

            IHealth health = _playerGameObject.GetComponent<IHealth>();
            ((PlayerHealth) health).Construct(_gameState);
            health.MaxHp = characterItem.health;
            
            return _playerGameObject;
        }

        public GameObject CreateEnemy(EnemyType type, Transform parent)
        {
            EnemyItem enemyItem = _items.ForEnemy(type);
            GameObject enemy = Object.Instantiate(enemyItem.prefab, parent.position, Quaternion.identity, parent);

            EnemyMovement enemyMovement = enemy.GetComponent<EnemyMovement>();
            enemyMovement.Construct(_playerGameObject.transform, _gameManager);
            enemyMovement.Speed = enemyItem.speed;
            
            enemy.GetComponent<XpSpawner>().Construct(this);

            Attack attack = enemy.GetComponent<Attack>();
            attack.AttackCooldown = enemyItem.attackCooldown;
            attack.AttackRadius = enemyItem.attackRadius;
            attack.Damage = enemyItem.damage;

            EnemyHealth health = enemy.GetComponent<EnemyHealth>();
            health.Construct(this);
            health.MaxHp = enemyItem.health;

            enemy.GetComponent<EnemyDeath>().Construct(_gameState);

            return enemy;
        }

        public FloatingText CreateFloatingText(Transform parent)
        {
            GameObject gameObject = _assets.Instantiate(AssetsPath.FloatingText, parent);
            return gameObject.GetComponent<FloatingText>();
        }

        public GameObject CreateSpawner(Vector3 at)
        {
            return _assets.Instantiate(AssetsPath.SpawnerPrefabPath, at);
        }

        public GameObject CreateXp(Vector3 at)
        {
            GameObject xp = _assets.Instantiate(AssetsPath.XpPrefabPath, at);
            xp.GetComponent<LootPiece>().Construct(_gameState);

            return xp;
        }
    }
}