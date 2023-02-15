using UnityEngine;

namespace Infrastructure.DI.Services.Factory.Ui
{
    public interface IUiFactory : IService
    {
        GameObject CreateHud();
    }
}