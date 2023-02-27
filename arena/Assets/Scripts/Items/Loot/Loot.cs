using UnityEngine;

namespace Items.Loot
{
    public abstract class Loot : ScriptableObject
    {
        [SerializeField] protected LootType type;
        [SerializeField] protected GameObject prefab;

        public LootType Type => type;

        public GameObject Prefab => prefab;
    }
}