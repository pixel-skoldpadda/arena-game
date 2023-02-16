using Infrastructure.DI.Services.Generator;
using UnityEngine;

/**
 * Класc, описывающий менеджер управления жизенным циклом игры
 */
public class GameManager : MonoBehaviour
{
    private GameState _gameState;
    private ILevelXpGenerator _xpGenerator;

    public void Construct(GameState gameState, ILevelXpGenerator xpGenerator)
    {
        _gameState = gameState;
        _xpGenerator = xpGenerator;
        _gameState.CurrentXpChanged += OnXpChanged;
    }

    private void OnXpChanged()
    {
        if (_gameState.CurrentXp >= _gameState.NeedXp)
        {
            GenerateNextLevel();
        }
    }

    private void GenerateNextLevel()
    {
        int difference = _gameState.NeedXp - _gameState.CurrentXp;
        _gameState.CurrentXp = difference;
        _gameState.CurrentLevel++;
        _gameState.NeedXp = _xpGenerator.GenerateNextLevelXp(_gameState.CurrentLevel);
    }

    public void InitStartLevel()
    {
        _gameState.CurrentLevel = 0;
        _gameState.NeedXp = _xpGenerator.GenerateNextLevelXp(_gameState.CurrentLevel);
    }
}