using Items.Loot;
using UnityEngine;

namespace Components
{
    public class LootPiece : MonoBehaviour
    {
        private bool _picked;
        private GameState _gameState;
        private CountedLoot _loot;
        
        public void Construct(GameState gameState, CountedLoot loot)
        {
            _gameState = gameState;
            _loot = loot;
        }
        
        private void OnTriggerEnter2D(Collider2D col)
        {
            Pickup();
        }

        private void Pickup()
        {
            if (_picked)
            {
                return;
            }

            _gameState.AddLoot(_loot);
            _picked = true;
            
            Destroy(gameObject);
        }
    }
}