using UnityEngine;
using Vector2 = UnityEngine.Vector2;

namespace Components.Movement
{
    [RequireComponent(typeof(Rigidbody2D))]
    public abstract class Movement : MonoBehaviour
    {
        [SerializeField] private Rigidbody2D body2D;
        [SerializeField] private AnimatorWrapper animator;
        
        private float _speed;
        private bool _moving;
        private Vector2 _axis;

        protected abstract Vector2 GetAxis();

        private void Start()
        {
            _moving = true;
        }

        protected virtual void Update()
        {
            if (_moving)
            {
                _axis = GetAxis();
                animator.SetAxis(_axis);   
            }
        }

        protected void FixedUpdate()
        {
            if (_moving)
            {
                body2D.MovePosition(body2D.position + _axis * (_speed * Time.fixedDeltaTime));   
            }
        }

        protected void ResetAxis()
        {
            _axis = Vector2.zero;
        }

        public void Pause()
        {
            body2D.simulated = false;
            _moving = false;
        }

        public void Resume()
        {
            body2D.simulated = true;
            _moving = true;
        }
        
        public float Speed
        {
            set => _speed = value;
        }
    }
}