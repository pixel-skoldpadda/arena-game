using Infrastructure.DI.Services.StateService;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Ui.HUD
{
    public class LevelProgressBar : MonoBehaviour
    {
        [SerializeField] private TextMeshProUGUI levelNumber;
        [SerializeField] private Image progress;

        private GameState _gameState;

        public void Construct(IGameStateService gameStateService)
        {
            _gameState = gameStateService.State;

            UpdateLevel();

            _gameState.CurrentLevelChanged += UpdateLevel;
            _gameState.CurrentXpChanged += UpdateProgress;
        }

        private void UpdateLevel()
        {
            levelNumber.text = $"LV { _gameState.CurrentLevel}";
            UpdateProgress();
        }
        
        private void UpdateProgress()
        {
            progress.fillAmount = (float)_gameState.CurrentXp / _gameState.NeedXp;
        }
    }
}