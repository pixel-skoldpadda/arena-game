using UnityEngine;

namespace Player
{
    public class CameraFollow : MonoBehaviour
    {
        [SerializeField] private float offsetZ;
        private Transform _following;

        public void Follow(Transform following)
        {
            _following = following;
        }
        
        private void LateUpdate()
        {
            if (_following == null)
            {
                return;
            }

            Vector3 position = _following.position;
            position.z += offsetZ;

            transform.position = position;
        }
    }
}