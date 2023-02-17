using Ui.HUD;
using Ui.Windows;

namespace Infrastructure.DI.Services.Factory.Ui
{
    public interface IUiFactory : IService
    {
        void CreateHud();
        void CreateUiRoot();
        PerksWindow CreatePerksWindow();
        DeathWindow CreateDeathWindow();
        PauseWindow CreatePauseWindow();
        Hud HUD { get; }
    }
}