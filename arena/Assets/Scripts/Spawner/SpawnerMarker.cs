using Items;
using UnityEngine;

namespace Spawner
{
    public class SpawnerMarker : MonoBehaviour
    {
        [SerializeField] private EnemyType type;
        [SerializeField] private int amount;
        [SerializeField] private float cooldown;

        public EnemyType EnemyType => type;
        public int Amount => amount;
        public float Cooldown => cooldown;
    }
}