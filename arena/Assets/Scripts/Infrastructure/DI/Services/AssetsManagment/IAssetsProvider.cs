using UnityEngine;

namespace Infrastructure.DI.Services.AssetsManagment
{
    public interface IAssetProvider : IService
    {
        GameObject Instantiate(string path);
        GameObject Instantiate(string path, Vector3 at);
    }
}