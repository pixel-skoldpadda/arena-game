using UnityEngine;

namespace Items.Perks
{
    public abstract class Perk : ScriptableObject
    {
        [SerializeField] public string perkName;
        [SerializeField] public string description;
        [SerializeField] public Sprite icon;
    }
}