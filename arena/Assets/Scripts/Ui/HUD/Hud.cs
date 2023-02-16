using UnityEngine;

namespace Ui.HUD
{
    public class Hud : MonoBehaviour
    {
        [SerializeField] private DeathContainer deathContainer;
        [SerializeField] private CoinsContainer coinsContainer;
        [SerializeField] private LevelProgressBar levelProgressBar;
        [SerializeField] private HudTimer hudTimer;

        public DeathContainer DeathContainer => deathContainer;
        public CoinsContainer CoinsContainer => coinsContainer;
        public LevelProgressBar LevelProgressBar => levelProgressBar;
        public HudTimer HudTimer => hudTimer;
    }
}