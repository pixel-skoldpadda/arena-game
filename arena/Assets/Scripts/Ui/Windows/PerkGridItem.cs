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
        private Perk _currentPerk;
        
        public void Construct(PerksWindow perksWindow)
        {
            _perksWindow = perksWindow;
        }
        
        public void Init(Perk perk)
        {
            _currentPerk = perk;
            icon.sprite = _currentPerk.Icon;
            perkName.text = _currentPerk.PerkName;
            perkDescription.text = _currentPerk.Description;
        }

        public void OnTakeButtonPressed()
        {
            _perksWindow.OnPerkTaken(_currentPerk);
        }
    }
}