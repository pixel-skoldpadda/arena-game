using Infrastructure.DI.Services.AssetsManagement;
using Infrastructure.DI.Services.Items;
using Infrastructure.DI.Services.StateService;
using Infrastructure.DI.Services.Windows;
using Items.Windows;
using Ui.HUD;
using Ui.Windows;
using UnityEngine;

namespace Infrastructure.DI.Services.Factory.Ui
{
    public class UiFactory : IUiFactory
    {
        private Transform _uiRoot;

        private readonly IAssetProvider _assets;
        private readonly IGameStateService _gameStateService;
        private readonly IItemsService _itemsService;

        public UiFactory(IAssetProvider assets, IGameStateService gameStateService, IItemsService itemsService)
        {
            _assets = assets;
            _gameStateService = gameStateService;
            _itemsService = itemsService;
        }

        public void CreateUiRoot()
        {
            GameObject uiRoot = _assets.Instantiate(AssetsPath.UiRootPrefabPath);
            _uiRoot = uiRoot.transform;
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

        public void CreatePerksWindow()
        {
            WindowItem windowItem = _itemsService.ForWindow(WindowType.Perks);
            PerksWindow perksWindow = Object.Instantiate(windowItem.windowPrefab, _uiRoot).GetComponent<PerksWindow>();
            perksWindow.Construct(_gameStateService);
        }
    }
}