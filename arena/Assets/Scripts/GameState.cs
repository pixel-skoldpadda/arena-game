﻿using System;
using System.Collections.Generic;
using Items.Loot;
using Items.Perks;

[Serializable]
public class GameState
{
    private int _coins;
    private int _currentXp;
    private int _deathCount;
    
    private int _currentLevel;
    private int _needXp;
    
    private Dictionary<Type, Perk> _activePerks = new();

    private bool _isGameRunning;

    private float _musicVolume = .5f;
    private float _effectsVolume = .5f;
    
    private Action _onGamePaused;
    private Action _onGameResumed;
    
    private Action _coinsChanged;
    private Action _deathCountChanged;
    
    private Action _currentLevelChanged;
    private Action _currentXpChanged;

    private Action<Perk> _onNewPerkAdded;
    private Action<int> _onHealthAdded;

    public void AddPerk(Perk perk)
    {
        _activePerks[perk.GetType()] = perk;
        _onNewPerkAdded?.Invoke(perk);
    }

    public TPerk GetPerk<TPerk>() where TPerk : Perk
    {
        return _activePerks.TryGetValue(typeof(TPerk), out var perk) ? perk as TPerk: null;
    }

    public void IncrementDeathCounter()
    {
        DeathCount++;
    }
    
    public void Reset()
    {
        _activePerks.Clear();
        _deathCount = 0;
        _currentLevel = 0;
        _currentXp = 0;
        _needXp = 0;
    }
    
    public void AddLoot(CountedLoot loot)
    {
        switch (loot.Type)
        {
            case LootType.XpSmall:
            case LootType.XpBig:
                CurrentXp += loot.Count;
                break;
            case LootType.HealthSmall:
            case LootType.HealthBig:
                OnHealthAdded.Invoke(loot.Count);
                break;
            case LootType.Coins:
                Coins += loot.Count;
                break;
        }
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

    public Action<Perk> OnNewPerkAdded
    {
        get => _onNewPerkAdded;
        set => _onNewPerkAdded = value;
    }

    public Action<int> OnHealthAdded
    {
        get => _onHealthAdded;
        set => _onHealthAdded = value;
    }

    public Action OnGamePaused
    {
        get => _onGamePaused;
        set => _onGamePaused = value;
    }

    public Action OnGameResumed
    {
        get => _onGameResumed;
        set => _onGameResumed = value;
    }

    public bool IsGameRunning
    {
        get => _isGameRunning;
        set
        {
            _isGameRunning = value;
            if (_isGameRunning)
            {
                _onGameResumed.Invoke();
            }
            else
            {
                _onGamePaused.Invoke();
            }
        }
    }

    public float MusicVolume
    {
        get => _musicVolume;
        set => _musicVolume = value;
    }

    public float EffectsVolume
    {
        get => _effectsVolume;
        set => _effectsVolume = value;
    }
}