using UnityEngine;

namespace Infrastructure.DI.Services.AssetsManagement
{
    public class AssetsProvider : IAssetProvider
    {
        public GameObject Instantiate(string path, Vector3 at)
        {
            GameObject prefab = Resources.Load<GameObject>(path);
            return Object.Instantiate(prefab, at, Quaternion.identity);
        }
    }
}