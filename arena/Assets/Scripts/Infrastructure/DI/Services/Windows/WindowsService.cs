using Infrastructure.DI.Services.Factory.Ui;
using Ui.HUD;
using Window = Ui.Windows.Window;

namespace Infrastructure.DI.Services.Windows
{
    public class WindowsService : IWindowsService
    {
        private readonly IUiFactory _uiFactory;

        public WindowsService(IUiFactory uiFactory)
        {
            _uiFactory = uiFactory;
        }
        
        public void Open(WindowType type)
        {
            Window window = CreateWindow(type);
            if (window == null)
            {
                return;
            }
            
            Hud hud = _uiFactory.HUD;
            hud.Disable();
            window.OnWindowClosed += hud.Enable;
        }

        private Window CreateWindow(WindowType type)
        {
            return type switch
            {
                WindowType.Perks => _uiFactory.CreatePerksWindow(),
                WindowType.Death => _uiFactory.CreateDeathWindow(),
                WindowType.Pause => _uiFactory.CreatePauseWindow(),
                _ => null
            };
        }
    }
}