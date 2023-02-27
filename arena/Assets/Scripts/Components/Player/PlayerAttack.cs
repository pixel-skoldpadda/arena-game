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
                return damagePerk != null ? CurrentDamage + damagePerk.DamageAmount : CurrentDamage;
            }
        }

        public override float AttackRadius
        {
            set => CurrentAttackRadius = value;
            get
            {
                DamageRadiusPerk damageRadiusPerk = _gameState?.GetPerk<DamageRadiusPerk>();
                return damageRadiusPerk != null ? CurrentAttackRadius + damageRadiusPerk.RadiusAmount : CurrentAttackRadius;
            }
        }

        public override float AttackCooldown
        {
            set
            {
                CurrentAttackCooldown = value;
                Cooldown = CurrentAttackCooldown;
            }
            get
            {
                AttackCooldownPerk cooldownPerk = _gameState.GetPerk<AttackCooldownPerk>();
                return cooldownPerk != null ? CurrentAttackCooldown - cooldownPerk.CooldownAmount : CurrentAttackCooldown;
            }
        }
    }
}