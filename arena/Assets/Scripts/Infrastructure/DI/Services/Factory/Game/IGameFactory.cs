using Components;
using Items;
using Items.Loot;
using UnityEngine;

namespace Infrastructure.DI.Services.Factory.Game
{
    public interface IGameFactory : IService
    {
        GameObject CreatePlayer(Vector3 at);
        void CreateEnemy(EnemyType type, Transform parent);
        GameObject CreateSpawner(Vector3 at);
        FloatingText CreateFloatingText(Transform parent);
        void CreateLoot(CountedLoot loot, Vector3 at);
    }
}