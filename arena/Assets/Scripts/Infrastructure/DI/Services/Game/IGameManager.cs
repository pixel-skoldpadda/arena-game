using System;

namespace Infrastructure.DI.Services.Game
{
    public interface IGameManager : IService
    {
        void GenerateNextLevel();
        void PauseGame();
        void ResumeGame();
        void InitStartLevel();
        Action OnGamePaused { get; set; }
        Action OnGameResumed { get; set; }
        void OnPLayerDie();
    }
}