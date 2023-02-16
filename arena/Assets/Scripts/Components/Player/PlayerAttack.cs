using Items.Perks;

namespace Components.Player
{
    public class PlayerAttack : Attack
    {
        private GameState _gameState;

        public void Construct(GameState gameState)
        {
            _gameState = gameState;
        }

        public override int Damage
        {
            set => CurrentDamage = value;
            get
            {
                DamagePerk damagePerk = _gameState.GetPerk<DamagePerk>();
                return damagePerk != null ? CurrentDamage + damagePerk.damageAmount : CurrentDamage;
            }
        }
    }
}