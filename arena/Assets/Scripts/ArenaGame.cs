using Infrastructure.DI;
using Infrastructure.States;

/**
 * Класс, описывающий объект игры.
 */
public class ArenaGame
{
    private readonly GameStateMachine _stateMachine;

    public ArenaGame()
    {
        _stateMachine = new GameStateMachine(DiContainer.Container);
    }

    public GameStateMachine GameStateMachine => _stateMachine;
}