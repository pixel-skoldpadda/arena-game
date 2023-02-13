using UnityEngine;

namespace Player
{
    public class CameraFollow : MonoBehaviour
    {
        [SerializeField] private Transform following;
        [SerializeField] private float offsetZ;
        
        private void LateUpdate()
        {
            if (following == null)
            {
                return;
            }

            Vector3 position = following.position;
            position.z += offsetZ;

            transform.position = position;
        }
    }
}