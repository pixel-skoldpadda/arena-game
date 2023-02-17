using Components;
using Components.Enemy;
using Components.Loot;
using Components.Movement;
using Components.Player;
using Infrastructure.DI.Services.AssetsManagement;
using Infrastructure.DI.Services.Game;
using Infrastructure.DI.Services.Items;
using Infrastructure.DI.Services.StateService;
using Items;
using Items.Loot;
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
            playerMovement.Construct(_gameState);
            playerMovement.Speed = characterItem.speed;

            PlayerAttack attack = _playerGameObject.GetComponent<PlayerAttack>();
            attack.Construct(_gameState);
            attack.AttackCooldown = characterItem.attackCooldown;
            attack.AttackRadius = characterItem.attackRadius;
            attack.Damage = characterItem.damage;

            IHealth health = _playerGameObject.GetComponent<IHealth>();
            ((PlayerHealth) health).Construct(_gameState);
            health.MaxHp = characterItem.health;

            PlayerDeath playerDeath = _playerGameObject.GetComponent<PlayerDeath>();
            playerDeath.OnDie += _gameManager.OnPLayerDie;

            return _playerGameObject;
        }

        public void CreateEnemy(EnemyType type, Transform parent)
        {
            EnemyItem enemyItem = _items.ForEnemy(type);
            GameObject enemy = Object.Instantiate(enemyItem.prefab, parent.position, Quaternion.identity, parent);

            EnemyMovement enemyMovement = enemy.GetComponent<EnemyMovement>();
            enemyMovement.Construct(_playerGameObject.transform, _gameState);
            enemyMovement.Speed = enemyItem.speed;

            Attack attack = enemy.GetComponent<Attack>();
            attack.AttackCooldown = enemyItem.attackCooldown;
            attack.AttackRadius = enemyItem.attackRadius;
            attack.Damage = enemyItem.damage;

            enemy.GetComponent<LootSpawner>().Construct(_items, this);
            
            EnemyHealth health = enemy.GetComponent<EnemyHealth>();
            health.Construct(this);
            health.MaxHp = enemyItem.health;

            enemy.GetComponent<EnemyDeath>().Construct(_gameState);
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

        public void CreateLoot(CountedLoot loot, Vector3 at)
        {
            LootPiece lootPiece = Object.Instantiate(loot.prefab, at, Quaternion.identity).GetComponent<LootPiece>();
            lootPiece.Construct(_gameState, loot);
        }
    }
}