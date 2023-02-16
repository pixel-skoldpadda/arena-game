using UnityEngine;

namespace Components
{
    // todo: Переработать систему лута
    public class LootPiece : MonoBehaviour
    {
        [SerializeField] private int xpAmount;
        
        private bool _picked;
        private GameState _gameState;
        
        public void Construct(GameState gameState)
        {
            _gameState = gameState;
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

            _gameState.CurrentXp += xpAmount;
            _picked = true;
            
            Destroy(gameObject);
        }
    }
}