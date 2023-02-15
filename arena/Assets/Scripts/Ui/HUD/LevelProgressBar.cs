using Infrastructure.DI.Services.Data;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Ui.HUD
{
    public class LevelProgressBar : MonoBehaviour
    {
        [SerializeField] private TextMeshProUGUI levelNumber;
        [SerializeField] private Image progress;

        private int _currentLevel;
        private int _currentXp;
        private int _needXp;

        private IGameStateService _gameStateService;
        
        private void UpdateProgress()
        {
            progress.fillAmount = (float)_currentXp / _needXp;
        }

        public void Construct(IGameStateService gameStateService)
        {
            _gameStateService = gameStateService;
        }
    }
}