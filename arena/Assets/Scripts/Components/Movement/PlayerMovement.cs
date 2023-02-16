using Infrastructure.DI;
using Infrastructure.DI.Services.Input;
using UnityEngine;

namespace Components.Movement
{
    public class PlayerMovement : Movement
    {
        private IInputService _inputService;

        private void Awake()
        {
            _inputService = DiContainer.Container.Get<IInputService>();
        }
        
        protected override Vector2 GetAxis()
        {
            return _inputService.Axis;
        }
    }
}