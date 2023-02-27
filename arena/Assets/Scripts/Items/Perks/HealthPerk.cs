using UnityEngine;

namespace Items.Perks
{
    [CreateAssetMenu(fileName = "HealthPerk", menuName = "Items/Perks/HealthPerk")]
    public class HealthPerk : Perk
    {
        [Range(5, 100)]
        [SerializeField] private int healthAmount;

        public int HealthAmount => healthAmount;
    }
}