using Components;
using Components.Movement;
using Infrastructure.DI.Services.AssetsManagement;
using Infrastructure.DI.Services.Items.Items;
using Items;
using UnityEngine;

namespace Infrastructure.DI.Services.Factory
{
    public class GameFactory : IGameFactory
    {
        private readonly IAssetProvider _assets;
        private readonly IItemsService _items;

        private GameObject _playerGameObject;
        
        public GameFactory(IAssetProvider assets, IItemsService items)
        {
            _assets = assets;
            _items = items;
        }

        public GameObject CreatePlayer(Vector3 at)
        {
            CharacterItem characterItem = _items.CharacterItem;
            _playerGameObject = Object.Instantiate(characterItem.prefab, at, Quaternion.identity);

            PlayerMovement playerMovement = _playerGameObject.GetComponent<PlayerMovement>();
            playerMovement.Speed = characterItem.speed;

            Attack attack = _playerGameObject.GetComponent<Attack>();
            attack.AttackCooldown = characterItem.attackCooldown;
            attack.AttackRadius = characterItem.attackRadius;
            attack.Damage = characterItem.damage;

            Health health = _playerGameObject.GetComponent<Health>();
            health.MaxHp = characterItem.health;
            
            return _playerGameObject;
        }

        public GameObject CreateEnemy(EnemyType type, Transform parent)
        {
            EnemyItem enemyItem = _items.ForEnemy(type);
            GameObject enemy = Object.Instantiate(enemyItem.prefab, parent.position, Quaternion.identity, parent);

            EnemyMovement enemyMovement = enemy.GetComponent<EnemyMovement>();
            enemyMovement.Construct(_playerGameObject.transform);
            enemyMovement.Speed = enemyItem.speed;
            
            enemy.GetComponent<XpSpawner>().Construct(this);

            Attack attack = enemy.GetComponent<Attack>();
            attack.AttackCooldown = enemyItem.attackCooldown;
            attack.AttackRadius = enemyItem.attackRadius;
            attack.Damage = enemyItem.damage;

            Health health = enemy.GetComponent<Health>();
            health.MaxHp = enemyItem.health;

            return enemy;
        }

        public GameObject CreateEnemy(Vector3 at, string assetsPath)
        {
            return _assets.Instantiate(assetsPath, at);
        }

        public GameObject CreateSpawner(Vector3 at)
        {
            return _assets.Instantiate(AssetsPath.SpawnerPrefabPath, at);
        }

        public GameObject CreateXp(Vector3 at)
        {
            return _assets.Instantiate(AssetsPath.XpPrefabPath, at);
        }
    }
}