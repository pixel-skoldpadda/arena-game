using UnityEngine;

namespace Ui.HUD
{
    public class Hud : MonoBehaviour
    {
        [SerializeField] private DeathContainer deathContainer;
        [SerializeField] private CoinsContainer coinsContainer;
        [SerializeField] private LevelProgressBar levelProgressBar;
        [SerializeField] private HudTimer hudTimer;
        [SerializeField] private ActivePerksContainer activePerksContainer;
        [SerializeField] private PauseGameButton pauseGameButton;

        public DeathContainer DeathContainer => deathContainer;
        public CoinsContainer CoinsContainer => coinsContainer;
        public LevelProgressBar LevelProgressBar => levelProgressBar;
        public HudTimer HudTimer => hudTimer;
        public ActivePerksContainer ActivePerksContainer => activePerksContainer;
        public PauseGameButton PauseGameButton => pauseGameButton;

        public void Disable()
        {
            pauseGameButton.Disable();
        }

        public void Enable()
        {
            pauseGameButton.Enable();
        }
    }
}