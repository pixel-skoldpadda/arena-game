using System;
using Infrastructure.DI.Services.StateService;
using TMPro;
using UnityEngine;

namespace Ui.HUD
{
    public class HudTimer : MonoBehaviour
    {
        [SerializeField] private TextMeshProUGUI timeText;
        
        private float _time;
        private bool _isRunning;

        private GameState _gameState;
        
        public void Construct(IGameStateService gameStateService)
        {
            _gameState = gameStateService.State;
            _gameState.OnGamePaused += StopTimer;
            _gameState.OnGameResumed += StartTimer;
        }

        private void Update()
        {
            if (_isRunning)
            {
                _time += Time.deltaTime;
                DisplayTime(_time);
            }
        }

        private void OnDestroy()
        {
            _gameState.OnGamePaused -= StopTimer;
            _gameState.OnGameResumed -= StartTimer;
        }

        private void DisplayTime(float timeToDisplay)
        {
            timeToDisplay += 1;
            float minutes = Mathf.FloorToInt(timeToDisplay / 60); 
            float seconds = Mathf.FloorToInt(timeToDisplay % 60);
            timeText.text = $"{minutes:00}:{seconds:00}";
        }

        private void StartTimer()
        {
            _isRunning = true;
        }

        private void StopTimer()
        {
            _isRunning = false;
        }
    }
}