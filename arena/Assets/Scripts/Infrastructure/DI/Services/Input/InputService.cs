using UnityEngine;

namespace Infrastructure.DI.Services.Input
{
    /**
     * Сервис пользовательского ввода.
     */
    public class InputService : IInputService
    {
        private const string Horizontal = "Horizontal";
        private const string Vertical = "Vertical";

        public Vector2 Axis => new(UnityEngine.Input.GetAxis(Horizontal), UnityEngine.Input.GetAxis(Vertical));
    }
}