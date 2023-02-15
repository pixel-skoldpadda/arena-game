using Infrastructure.DI;
using Infrastructure.States;
using Ui;

/**
 * Класс, описывающий объект игры.
 */
public class ArenaGame
{
    private readonly GameStateMachine _stateMachine;

    public ArenaGame(ICoroutineRunner coroutineRunner, LoadingCurtain loadingCurtain)
    {
        _stateMachine = new GameStateMachine(DiContainer.Container, new SceneLoader(coroutineRunner), loadingCurtain);
    }

    public GameStateMachine GameStateMachine => _stateMachine;
}