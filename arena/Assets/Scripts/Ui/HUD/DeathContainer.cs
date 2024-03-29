﻿using Infrastructure.DI.Services.StateService;
using TMPro;
using UnityEngine;

namespace Ui.HUD
{
    public class DeathContainer : MonoBehaviour
    {
        [SerializeField] private TextMeshProUGUI deathCounter;

        private GameState _gameState;
        
        public void Construct(IGameStateService gameStateService)
        {
            _gameState = gameStateService.State;
            _gameState.DeathCountChanged += UpdateCounter;
        }
        
        private void UpdateCounter()
        {
            deathCounter.text = $"{_gameState.DeathCount}";
        }

        private void OnDestroy()
        {
            _gameState.DeathCountChanged -= UpdateCounter;
        }
    }
}