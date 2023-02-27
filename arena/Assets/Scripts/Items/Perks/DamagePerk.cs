using UnityEngine;

namespace Items.Perks
{
    [CreateAssetMenu(fileName = "DamagePerk", menuName = "Items/Perks/DamagePerk")]
    public class DamagePerk : Perk
    {
        [Range(1, 50)]
        [SerializeField] private int damageAmount;

        public int DamageAmount => damageAmount;
    }
}