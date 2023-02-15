using Items;
using UnityEngine;

namespace Spawner
{
    public class SpawnerMarker : MonoBehaviour
    {
        [SerializeField] private EnemyType type;

        public EnemyType EnemyType => type;
    }
}