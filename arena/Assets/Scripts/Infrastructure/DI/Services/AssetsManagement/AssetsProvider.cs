using UnityEngine;

namespace Infrastructure.DI.Services.AssetsManagement
{
    public class AssetsProvider : IAssetProvider
    {
        public GameObject Instantiate(string path)
        {
            GameObject gameObject = Resources.Load<GameObject>(path);
            return Object.Instantiate(gameObject);
        }

        public GameObject Instantiate(string path, Vector3 at)
        {
            GameObject prefab = Resources.Load<GameObject>(path);
            return Object.Instantiate(prefab, at, Quaternion.identity);
        }

        public GameObject Instantiate(string path, Transform parent)
        {
            GameObject prefab = Resources.Load<GameObject>(path);
            return Object.Instantiate(prefab, parent.position, Quaternion.identity, parent);
        }
    }
}