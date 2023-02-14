using UnityEngine;
using Vector2 = UnityEngine.Vector2;

namespace Components.Movement
{
    [RequireComponent(typeof(Rigidbody2D))]
    public abstract class Movement : MonoBehaviour
    {
        [SerializeField] private Rigidbody2D body2D;
        [SerializeField] private float speed;
        [SerializeField] private AnimatorWrapper animator;
        
        private Vector2 _axis;

        protected abstract Vector2 GetAxis();

        protected virtual void Update()
        {
            _axis = GetAxis();
            animator.SetAxis(_axis);
        }

        protected void FixedUpdate()
        {
            body2D.MovePosition(body2D.position + _axis * (speed * Time.fixedDeltaTime));
        }

        protected void ResetAxis()
        {
            _axis = Vector2.zero;
        }
    }
}