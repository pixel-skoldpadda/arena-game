using System.Numerics;
using UnityEngine;
using Vector2 = UnityEngine.Vector2;

namespace Movement
{
    [RequireComponent(typeof(Animator), typeof(Rigidbody2D))]
    public abstract class Movement : MonoBehaviour
    {
        private static readonly int Horizontal = Animator.StringToHash("Horizontal");
        private static readonly int Vertical = Animator.StringToHash("Vertical");
        private static readonly int  Speed = Animator.StringToHash("Speed");
    
        [SerializeField] private Rigidbody2D body2D;
        [SerializeField] private Animator animator;
        [SerializeField] private float speed;

        private Vector2 _axis;

        protected abstract Vector2 GetAxis();

        protected virtual void Update()
        {
            _axis = GetAxis();
        
            animator.SetFloat(Horizontal, _axis.x);
            animator.SetFloat(Vertical, _axis.y);
            animator.SetFloat(Speed, _axis.magnitude);
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