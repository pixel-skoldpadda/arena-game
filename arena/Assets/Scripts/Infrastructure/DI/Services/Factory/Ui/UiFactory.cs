using Infrastructure.DI.Services.AssetsManagement;
using Infrastructure.DI.Services.Items;
using Infrastructure.DI.Services.Perks;
using Infrastructure.DI.Services.StateService;
using Infrastructure.DI.Services.Windows;
using Infrastructure.States;
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
        private readonly IPerksGenerator _perksGenerator;
        private readonly IGameStateMachine _gameStateMachine;
        private Hud _hud;
        
        public UiFactory(IAssetProvider assets, IGameStateService gameStateService, IItemsService itemsService, IPerksGenerator perksGenerator,
            IGameStateMachine gameStateMachine)
        {
            _assets = assets;
            _gameStateService = gameStateService;
            _itemsService = itemsService;
            _perksGenerator = perksGenerator;
            _gameStateMachine = gameStateMachine;
        }

        public void CreateUiRoot()
        {
            GameObject uiRoot = _assets.Instantiate(AssetsPath.UiRootPrefabPath);
            _uiRoot = uiRoot.transform;
        }
        
        public void CreateHud()
        {
            GameObject hudGameObject = _assets.Instantiate(AssetsPath.HudPrefabPath);
            _hud = hudGameObject.GetComponent<Hud>();

            _hud.DeathContainer.Construct(_gameStateService);
            _hud.CoinsContainer.Construct(_gameStateService);
            _hud.LevelProgressBar.Construct(_gameStateService);
            _hud.HudTimer.Construct(_gameStateService);
            _hud.ActivePerksContainer.Construct(_gameStateService);
            _hud.PauseGameButton.Construct(_gameStateService);
        }

        public PerksWindow CreatePerksWindow()
        {
            WindowItem windowItem = _itemsService.ForWindow(WindowType.Perks);
            PerksWindow perksWindow = Object.Instantiate(windowItem.windowPrefab, _uiRoot).GetComponent<PerksWindow>();
            perksWindow.Construct(_gameStateService, _perksGenerator);

            return perksWindow;
        }

        public DeathWindow CreateDeathWindow()
        {
            WindowItem windowItem = _itemsService.ForWindow(WindowType.Death);
            DeathWindow deathWindow = Object.Instantiate(windowItem.windowPrefab, _uiRoot).GetComponent<DeathWindow>();
            deathWindow.Construct(_gameStateMachine);

            return deathWindow;
        }

        public PauseWindow CreatePauseWindow()
        {
            WindowItem windowItem = _itemsService.ForWindow(WindowType.Pause);
            PauseWindow pauseWindow = Object.Instantiate(windowItem.windowPrefab, _uiRoot).GetComponent<PauseWindow>();
            pauseWindow.Construct(_gameStateService, _gameStateMachine);

            return pauseWindow;
        }

        public Hud HUD => _hud;
    }
}