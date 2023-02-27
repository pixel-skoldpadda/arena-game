using UnityEngine;

namespace Items.Perks
{
    public abstract class Perk : ScriptableObject
    {
        [SerializeField] protected string perkName;
        [SerializeField] protected string description;
        [SerializeField] protected Sprite icon;

        public string PerkName => perkName;

        public string Description => description;

        public Sprite Icon => icon;
    }
}