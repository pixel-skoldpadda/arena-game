using Infrastructure.DI.Services.AssetsManagement;
using Infrastructure.DI.Services.Data;
using Ui.HUD;
using UnityEngine;

namespace Infrastructure.DI.Services.Factory.Ui
{
    public class UiFactory : IUiFactory
    {
        private readonly IAssetProvider _assets;
        private readonly IGameStateService _gameStateService;

        public UiFactory(IAssetProvider assets, IGameStateService gameStateService)
        {
            _assets = assets;
            _gameStateService = gameStateService;
        }
        
        public GameObject CreateHud()
        {
            GameObject hudGameObject = _assets.Instantiate(AssetsPath.HudPrefabPath);
            Hud hud = hudGameObject.GetComponent<Hud>();

            hud.DeathContainer.Construct(_gameStateService);
            hud.CoinsContainer.Construct(_gameStateService);
            hud.LevelProgressBar.Construct(_gameStateService);
            
            return hudGameObject;
        }
    }
}