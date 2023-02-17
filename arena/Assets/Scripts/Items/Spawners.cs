using System.Collections.Generic;
using Spawner;
using UnityEngine;

namespace Items
{
    [CreateAssetMenu(fileName = "Spawners", menuName = "Items/Spawners")]
    public class Spawners : ScriptableObject
    {
        public List<SpawnerData> SpawnersData;
    }
}