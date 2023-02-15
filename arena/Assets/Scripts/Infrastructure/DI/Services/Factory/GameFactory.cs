using Infrastructure.DI.Services.AssetsManagment;
using UnityEngine;

namespace Infrastructure.DI.Services.Factory
{
    public class GameFactory : IGameFactory
    {
        private readonly IAssetProvider _assets;

        public GameFactory(IAssetProvider assets)
        {
            _assets = assets;
        }

        public GameObject CreatePlayer(Vector3 at)
        {
            return _assets.Instantiate(AssetsPath.PlayerPrefabPath, at);
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