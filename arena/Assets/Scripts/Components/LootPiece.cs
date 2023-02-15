using UnityEngine;

namespace Components
{
    public class LootPiece : MonoBehaviour
    {
        private bool _picked;

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

            _picked = true;
            
            Destroy(gameObject);
        }
    }
}