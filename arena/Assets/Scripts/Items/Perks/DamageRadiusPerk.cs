using UnityEngine;

namespace Items.Perks
{
    [CreateAssetMenu(fileName = "DamageRadiusPerk", menuName = "Items/Perks/DamageRadiusPerk")]
    public class DamageRadiusPerk : Perk
    {
        [Range(.01f, .05f)]
        public float radiusAmount;
    }
}