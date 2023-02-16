using UnityEngine;

namespace Items.Loot
{
    public abstract class Loot : ScriptableObject
    {
        public LootType type;
        public GameObject prefab;
    }
}