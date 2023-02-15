namespace Infrastructure.States.Interfaces
{
    public interface IPayLoadedState<TPayLoad> : IExitableState
    {
        void Enter(TPayLoad payload);
    }
}