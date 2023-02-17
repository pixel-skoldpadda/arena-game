using UnityEngine;
using UnityEngine.UI;

namespace Ui.HUD
{
    public class ActivePerk : MonoBehaviour
    {
        [SerializeField] private Image icon;

        public void SetIcon(Sprite sprite)
        {
            icon.sprite = sprite;
        }
    }
}