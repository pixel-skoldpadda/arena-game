using UnityEngine;

namespace Infrastructure.DI.Services.AssetsManagement
{
    public interface IAssetProvider : IService
    {
        GameObject Instantiate(string path, Vector3 at);
        GameObject Instantiate(string path, Transform parent);
    }
}