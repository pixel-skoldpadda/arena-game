using Infrastructure.DI;
using Infrastructure.DI.Services.Game;
using Infrastructure.DI.Services.Input;
using Items.Perks;
using UnityEngine;

namespace Components.Movement
{
    public class PlayerMovement : Movement
    {
        private IInputService _inputService;

        private GameState _gameState;

        public void Construct(IGameManager gameManager, GameState gameState)
        {
            base.Construct(gameManager);

            _gameState = gameState;
        }

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
                SpeedPerk speedPerk = _gameState.GetPerk<SpeedPerk>();
                return speedPerk != null ? CurrentSpeed + speedPerk.speedAmount : CurrentSpeed;
            }
        }
    }
}