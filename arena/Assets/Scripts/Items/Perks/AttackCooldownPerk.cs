using UnityEngine;

namespace Items.Perks
{
    [CreateAssetMenu(fileName = "AttackCooldownPerk", menuName = "Items/Perks/AttackCooldownPerk")]
    public class AttackCooldownPerk : Perk
    {
        [Range(.1f, .5f)]
        public float cooldownAmount;
    }
}