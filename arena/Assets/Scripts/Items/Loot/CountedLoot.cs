using UnityEngine;

namespace Items.Loot
{
    [CreateAssetMenu(fileName = "CountedLoot", menuName = "Items/CountedLoot", order = 0)]
    public class CountedLoot : Loot
    {
        [SerializeField] private int count;

        public int Count => count;
    }
}