using UnityEngine;

namespace Components.Movement
{
    [RequireComponent(typeof(Rigidbody2D))]
    public abstract class Movement : MonoBehaviour
    {
        [SerializeField] private Rigidbody2D body2D;
        [SerializeField] private AnimatorWrapper animator;

        private bool _moving;
        private Vector2 _axis;

        protected GameState GameState;
        protected float CurrentSpeed;

        protected abstract Vector2 GetAxis();

        public void Construct(GameState gameState)
        {
            GameState = gameState;
            GameState.OnGamePaused += Pause;
            GameState.OnGameResumed += Resume;
        }
        
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
                body2D.MovePosition(body2D.position + _axis * (Speed * Time.fixedDeltaTime));   
            }
        }

        private void OnDestroy()
        {
            GameState.OnGamePaused -= Pause;
            GameState.OnGameResumed -= Resume;
        }

        public void Pause()
        {
            body2D.simulated = false;
            _moving = false;
        }

        public virtual float Speed
        {
            get => CurrentSpeed;
            set => CurrentSpeed = value;
        }

        protected void ResetAxis()
        {
            _axis = Vector2.zero;
        }

        private void Resume()
        {
            body2D.simulated = true;
            _moving = true;
        }
    }
}