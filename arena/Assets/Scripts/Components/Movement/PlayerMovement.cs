using Infrastructure.DI;
using Infrastructure.DI.Services.Input;
using Items.Perks;
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

        public override float Speed
        {
            set => CurrentSpeed = value;
            get
            {
                SpeedPerk speedPerk = GameState.GetPerk<SpeedPerk>();
                return speedPerk != null ? CurrentSpeed + speedPerk.speedAmount : CurrentSpeed;
            }
        }
    }
}