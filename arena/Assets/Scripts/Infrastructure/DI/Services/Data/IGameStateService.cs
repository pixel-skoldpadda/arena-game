namespace Infrastructure.DI.Services.Data
{
    public interface IGameStateService : IService
    {
        GameState State { get; set; }
    }
}