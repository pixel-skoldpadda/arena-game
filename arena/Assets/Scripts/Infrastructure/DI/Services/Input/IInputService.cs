
using UnityEngine;

namespace Infrastructure.DI.Services.Input
{
    public interface IInputService : IService
    {
        Vector2 Axis { get; }
    }
}