using Infrastructure.States;
using UnityEngine;

/**
 * Класс, описывающий загрузчик необходимых компонентов игры.
 */
public class GameBootstrapper : MonoBehaviour
{
    private ArenaGame _arenaGame;

    private void Awake()
    {
        _arenaGame = new ArenaGame();
        _arenaGame.GameStateMachine.Enter<BootstrapState>();
        
        DontDestroyOnLoad(this);
    }
}
