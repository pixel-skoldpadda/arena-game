namespace Infrastructure.DI.Services.Game
{
    public interface IGameManager : IService
    {
        void InitStartLevel();
        void OnPLayerDie();
    }
}