namespace Infrastructure.DI.Services.Windows
{
    public interface IWindowsService : IService
    {
        void Open(WindowType type);
    }
}