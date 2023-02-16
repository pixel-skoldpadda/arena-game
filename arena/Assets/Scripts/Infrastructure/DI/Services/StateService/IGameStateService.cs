namespace Infrastructure.DI.Services.StateService
{
    public interface IGameStateService : IService
    {
        GameState State { get; set; }
    }
}