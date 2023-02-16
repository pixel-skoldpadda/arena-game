using UnityEngine;

namespace Items.Perks
{
    [CreateAssetMenu(fileName = "DamagePerk", menuName = "Items/Perks/DamagePerk")]
    public class DamagePerk : Perk
    {
        [Range(1, 50)]
        public int damageAmount;
    }
}