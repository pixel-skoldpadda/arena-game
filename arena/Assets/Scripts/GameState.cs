using System;
using System.Collections.Generic;
using Items.Perks;

[Serializable]
public class GameState
{
    private int _coins;
    private int _deathCount;
    private int _currentLevel;
    private int _currentXp;
    private int _needXp;
        
    private Action _coinsChanged;
    private Action _deathCountChanged;
    
    private Action _currentLevelChanged;
    private Action _currentXpChanged;

    private Action _onNewPerkAdded;

    private Dictionary<Type, Perk> _activePerks = new();

    public void IncrementDeathCounter()
    {
        DeathCount++;
    }

    public void AddPerk(Perk perk)
    {
        _activePerks[perk.GetType()] = perk;
        _onNewPerkAdded?.Invoke();
    }

    public TPerk GetPerk<TPerk>() where TPerk : Perk
    {
        return _activePerks.TryGetValue(typeof(TPerk), out var perk) ? perk as TPerk: null;
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

    public int CurrentLevel
    {
        get => _currentLevel;
        set
        {
            _currentLevel = value;
            _currentLevelChanged?.Invoke();
        }
    }

    public int CurrentXp
    {
        get => _currentXp;
        set
        {
            _currentXp = value;
            _currentXpChanged?.Invoke();
        }
    }

    public int NeedXp
    {
        get => _needXp;
        set => _needXp = value;
    }

    public Action CurrentLevelChanged
    {
        get => _currentLevelChanged;
        set => _currentLevelChanged = value;
    }

    public Action CurrentXpChanged
    {
        get => _currentXpChanged;
        set => _currentXpChanged = value;
    }

    public Action OnNewPerkAdded
    {
        get => _onNewPerkAdded;
        set => _onNewPerkAdded = value;
    }
}