using Infrastructure.DI.Services.Generator;
using Infrastructure.DI.Services.Perks;
using Infrastructure.DI.Services.StateService;
using Infrastructure.DI.Services.Windows;

namespace Infrastructure.DI.Services.Game
{
    /**
 * Класc, описывающий менеджер управления жизенным циклом игры
 */
    public class GameManager : IGameManager
    {
        private readonly GameState _gameState;
        private readonly ILevelXpGenerator _xpGenerator;
        private readonly IWindowsService _windows;
        private readonly IPerksGenerator _perksGenerator;

        public GameManager(IGameStateService gameStateService, ILevelXpGenerator xpGenerator, IWindowsService windows, IPerksGenerator perksGenerator)
        {
            _gameState = gameStateService.State;
            _xpGenerator = xpGenerator;
            _windows = windows;
            _perksGenerator = perksGenerator;
            
            _gameState.CurrentXpChanged += OnXpChanged;
            _gameState.OnNewPerkAdded += ResumeGame;
        }
        
        private void OnXpChanged()
        {
            if (_gameState.CurrentXp >= _gameState.NeedXp)
            {
                GenerateNextLevel();
            }
        }

        public void GenerateNextLevel()
        {
            int difference = _gameState.NeedXp - _gameState.CurrentXp;
            _gameState.CurrentXp = difference;
            _gameState.CurrentLevel++;
            _gameState.NeedXp = _xpGenerator.GenerateNextLevelXp(_gameState.CurrentLevel);
            
            if (_perksGenerator.HasPerks())
            {
                PauseGame();
                _windows.Open(WindowType.Perks);   
            }
        }

        public void PauseGame()
        {
            _gameState.IsGameRunning = false;
        }

        public void ResumeGame()
        {
            _gameState.IsGameRunning = true;
        }

        public void OnPLayerDie()
        {
            PauseGame();
            _gameState.Reset();
            _windows.Open(WindowType.Death);
        }
        
        public void InitStartLevel()
        {
            _gameState.CurrentLevel = 0;
            _gameState.NeedXp = _xpGenerator.GenerateNextLevelXp(_gameState.CurrentLevel);
            _gameState.IsGameRunning = true;
        }
    }
}