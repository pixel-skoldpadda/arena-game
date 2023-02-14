using UnityEngine;

namespace Infrastructure.DI.Services.Factory
{
    public interface IGameFactory : IService
    {
        GameObject CreatePlayer(Vector3 at);
        GameObject CreateEnemy(Vector3 at, string assetsPath);
        GameObject CreateSpawner(Vector3 at);
    }
}