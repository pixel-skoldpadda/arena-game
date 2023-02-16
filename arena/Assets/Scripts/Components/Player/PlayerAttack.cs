using Items.Perks;
using UnityEngine;

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
                int d = damagePerk != null ? CurrentDamage + damagePerk.damageAmount : CurrentDamage;
                
                Debug.Log($"Player damage : {d}");
                
                return d;
            }
        }
    }
}