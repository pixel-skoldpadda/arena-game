using UnityEngine;

namespace Infrastructure.DI.Services.AssetsManagement
{
    public interface IAssetProvider : IService
    {
        GameObject Instantiate(string path, Vector3 at);
    }
}