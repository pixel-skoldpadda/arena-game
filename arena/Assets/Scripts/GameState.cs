using System;

[Serializable]
public class GameState
{
    private int _coins;
    private int _deathCount;
    private int _currentLevel;
        
    private Action _coinsChanged;
    private Action _deathCountChanged;

    public void IncrementDeathCounter()
    {
        DeathCount++;
    }
    
    public Action CoinsChanged
    {
        get => _coinsChanged;
        set => _coinsChanged = value;
    }

    public Action DeathCountChanged
    {
        get => _deathCountChanged;
        set => _deathCountChanged = value;
    }

    public int Coins
    {
        get => _coins;
        set
        {
            _coins = value;
            _coinsChanged?.Invoke();
        }
    }

    public int DeathCount
    {
        get => _deathCount;
        set
        {
            _deathCount = value;
            _deathCountChanged?.Invoke();
        }
    }
}