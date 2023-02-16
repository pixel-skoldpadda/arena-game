using UnityEngine;

namespace Items.Perks
{
    [CreateAssetMenu(fileName = "HealthPerk", menuName = "Items/Perks/HealthPerk")]
    public class HealthPerk : Perk
    {
        [Range(5, 100)]
        public int healthAmount;
    }
}