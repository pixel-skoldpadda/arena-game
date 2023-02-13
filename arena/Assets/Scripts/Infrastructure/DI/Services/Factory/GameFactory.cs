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
            return _assets.Instantiate(AsstetsPath.PlayerPrefabPath, at);
        }

        public GameObject CreateEnemy(Vector3 at)
        {
            return _assets.Instantiate(AsstetsPath.SkeletonWarriorPrefabPath, at);
        }
    }
}