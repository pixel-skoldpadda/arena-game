using UnityEngine;

namespace Items.Perks
{
    public abstract class PerkItem : ScriptableObject
    {
        [SerializeField] public PerkType type;
        [SerializeField] public string perkName;
        [SerializeField] public string description;
        [SerializeField] public Sprite icon;
    }
}