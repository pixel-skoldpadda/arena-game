using Infrastructure.States;
using Ui;
using UnityEngine;

/**
 * Класс, описывающий загрузчик необходимых компонентов игры.
 */
public class GameBootstrapper : MonoBehaviour, ICoroutineRunner
{
    [SerializeField] private LoadingCurtain curtainPrefab;
    private ArenaGame _arenaGame;

    private void Awake()
    {
        _arenaGame = new ArenaGame(this, Instantiate(curtainPrefab));
        _arenaGame.GameStateMachine.Enter<BootstrapState>();
        
        DontDestroyOnLoad(this);
    }
}
