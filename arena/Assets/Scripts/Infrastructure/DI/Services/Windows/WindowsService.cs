using Infrastructure.DI.Services.Factory.Ui;

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
            if (type == WindowType.Perks)
            {
                _uiFactory.CreatePerksWindow();
            }
        }
    }
}