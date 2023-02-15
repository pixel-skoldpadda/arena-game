using Components;
using Items;
using UnityEngine;

namespace Infrastructure.DI.Services.Factory
{
    public interface IGameFactory : IService
    {
        GameObject CreatePlayer(Vector3 at);
        GameObject CreateEnemy(EnemyType type, Transform parent);
        GameObject CreateSpawner(Vector3 at);
        GameObject CreateXp(Vector3 at);
        FloatingText CreateFloatingText(Transform parent);
    }
}