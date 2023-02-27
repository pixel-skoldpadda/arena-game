using Infrastructure.DI.Services.Windows;
using UnityEngine;

namespace Items.Windows
{
    [CreateAssetMenu(fileName = "WindowItem", menuName = "Items/Windows/WindowItem")]
    public class WindowItem : ScriptableObject
    {
        [SerializeField] private WindowType type;
        [SerializeField] private GameObject windowPrefab;

        public WindowType Type => type;

        public GameObject WindowPrefab => windowPrefab;
    }
}