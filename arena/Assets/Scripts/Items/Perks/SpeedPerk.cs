using UnityEngine;

namespace Items.Perks
{
    [CreateAssetMenu(fileName = "SpeedPerk", menuName = "Items/Perks/SpeedPerk")]
    public class SpeedPerk : Perk
    {
        [Range(.1f, 3)]
        [SerializeField] private float speedAmount;

        public float SpeedAmount => speedAmount;
    }
}