using UnityEngine;

namespace Infrastructure.DI.Services.Factory
{
    public interface IGameFactory : IService
    {
        GameObject CreatePlayer(Vector3 at);
    }
}