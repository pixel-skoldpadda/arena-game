using UnityEngine;

namespace Components.Movement
{
    public class EnemyMovement : Movement
    {
        [SerializeField] private float minDistance;

        private Transform _playerTransform;

        public void Construct(Transform playerTransform)
        {
            _playerTransform = playerTransform;
        }

        protected override void Update()
        {
            Vector3 playerPosition = _playerTransform.position;
            Vector3 enemyPosition = transform.position;

            float distance = Vector3.Distance(playerPosition, enemyPosition);
            if (distance <= minDistance)
            {
                ResetAxis();
            }
            else
            {
                base.Update();   
            }
        }

        protected override Vector2 GetAxis()
        {
            Vector3 axis = _playerTransform.position - transform.position;
            axis.Normalize();
            return axis;
        }
    }
}