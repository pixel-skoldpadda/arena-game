using UnityEngine;

namespace Items.Perks
{
    [CreateAssetMenu(fileName = "PercentPerk", menuName = "Items/Perks/AmountPerkItem")]
    public class AmountPerkItem : PerkItem
    {
        [Range(.1f, 100f)]
        [SerializeField] private float amount;
    }
}