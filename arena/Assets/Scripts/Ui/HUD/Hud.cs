using UnityEngine;

namespace Ui.HUD
{
    public class Hud : MonoBehaviour
    {
        [SerializeField] private DeathContainer deathContainer;
        [SerializeField] private CoinsContainer coinsContainer;
        [SerializeField] private LevelProgressBar levelProgressBar;

        public DeathContainer DeathContainer => deathContainer;
        public CoinsContainer CoinsContainer => coinsContainer;
        public LevelProgressBar LevelProgressBar => levelProgressBar;
    }
}