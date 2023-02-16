using UnityEngine;

namespace Items.Loot
{
    [CreateAssetMenu(fileName = "CountedLoot", menuName = "Items/CountedLoot", order = 0)]
    public class CountedLoot : Loot
    {
        public int count;
    }
}