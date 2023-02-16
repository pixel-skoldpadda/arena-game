using Infrastructure.DI.Services.Windows;
using UnityEngine;

namespace Items.Windows
{
    [CreateAssetMenu(fileName = "WindowItem", menuName = "Items/Windows/WindowItem")]
    public class WindowItem : ScriptableObject
    {
        public WindowType type;
        public GameObject windowPrefab;
    }
}