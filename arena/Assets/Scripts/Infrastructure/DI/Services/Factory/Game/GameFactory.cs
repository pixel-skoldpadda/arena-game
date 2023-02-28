using Components;
using Components.Enemy;
using Components.Loot;
using Components.Movement;
using Components.Player;
using Infrastructure.DI.Services.AssetsManagement;
using Infrastructure.DI.Services.Game;
using Infrastructure.DI.Services.Input;
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
        private readonly IInputService _input;

        private GameObject _playerGameObject;
        
        public GameFactory(IAssetProvider assets, IItemsService items, IGameStateService gameStateService, IGameManager gameManager, IInputService input)
        {
            _assets = assets;
            _items = items;
            _gameState = gameStateService.State;
            _gameManager = gameManager;
            _input = input;
        }

        public GameObject CreatePlayer(Vector3 at)
        {
            CharacterItem characterItem = _items.CharacterItem;
            _playerGameObject = Object.Instantiate(characterItem.Prefab, at, Quaternion.identity);

            PlayerMovement playerMovement = _playerGameObject.GetComponent<PlayerMovement>();
            playerMovement.Construct(_gameState, _input);
            playerMovement.Speed = characterItem.Speed;

            PlayerAttack attack = _playerGameObject.GetComponent<PlayerAttack>();
            attack.Construct(_gameState);
            attack.AttackCooldown = characterItem.AttackCooldown;
            attack.AttackRadius = characterItem.AttackRadius;
            attack.Damage = characterItem.Damage;

            IHealth health = _playerGameObject.GetComponent<IHealth>();
            ((PlayerHealth) health).Construct(_gameState);
            health.MaxHp = characterItem.Health;

            PlayerDeath playerDeath = _playerGameObject.GetComponent<PlayerDeath>();
            playerDeath.OnDie += _gameManager.OnPLayerDie;

            return _playerGameObject;
        }

        public void CreateEnemy(EnemyType type, Transform parent)
        {
            EnemyItem enemyItem = _items.ForEnemy(type);
            GameObject enemy = Object.Instantiate(enemyItem.Prefab, parent.position, Quaternion.identity, parent);

            EnemyMovement enemyMovement = enemy.GetComponent<EnemyMovement>();
            enemyMovement.Construct(_playerGameObject.transform, _gameState);
            enemyMovement.Speed = enemyItem.Speed;

            Attack attack = enemy.GetComponent<Attack>();
            attack.AttackCooldown = enemyItem.AttackCooldown;
            attack.AttackRadius = enemyItem.AttackRadius;
            attack.Damage = enemyItem.Damage;

            enemy.GetComponent<LootSpawner>().Construct(_items, this);
            
            EnemyHealth health = enemy.GetComponent<EnemyHealth>();
            health.Construct(this);
            health.MaxHp = enemyItem.Health;

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
            LootPiece lootPiece = Object.Instantiate(loot.Prefab, at, Quaternion.identity).GetComponent<LootPiece>();
            lootPiece.Construct(_gameState, loot);
        }
    }
}