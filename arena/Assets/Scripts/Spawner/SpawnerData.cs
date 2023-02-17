using System;
using Items;
using UnityEngine;

namespace Spawner
{
    [Serializable]
    public class SpawnerData
    {
        private EnemyType _type;
        private int _amount;
        private float _cooldown;
        private Vector3 _position;

        public SpawnerData(EnemyType type, int amount, float cooldown, Vector3 position)
        {
            _type = type;
            _amount = amount;
            _cooldown = cooldown;
            _position = position;
        }
        
        public EnemyType EnemyType => _type;
        public int Amount => _amount;
        public float Cooldown => _cooldown;
        public Vector3 Position => _position;
    }
}