using Items.Perks;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Ui.Windows
{
    public class PerkGridItem : MonoBehaviour
    {
        [SerializeField] private Image icon;
        [SerializeField] private TextMeshProUGUI perkName;
        [SerializeField] private TextMeshProUGUI perkDescription;

        private PerksWindow _perksWindow;
        
        public void Construct(PerksWindow perksWindow)
        {
            _perksWindow = perksWindow;
        }
        
        public void Init(PerkItem item)
        {
            icon.sprite = item.icon;
            perkName.text = item.perkName;
            perkDescription.text = item.description;
        }

        public void OnTakeButtonPressed()
        {
            _perksWindow.Close();
        }
    }
}