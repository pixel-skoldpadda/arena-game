using Infrastructure.DI;
using Infrastructure.DI.Services.Input;
using UnityEngine;

namespace Player
{
    [RequireComponent(typeof(Rigidbody2D), typeof(Animator))]
    public class PlayerMovement : MonoBehaviour
    {
        private static readonly int Horizontal = Animator.StringToHash("Horizontal");
        private static readonly int Vertical = Animator.StringToHash("Vertical");
        private static readonly int Speed = Animator.StringToHash("Speed");

        [SerializeField] private float speed;
        [SerializeField] private Rigidbody2D body2D;
        [SerializeField] private Animator animator;

        private IInputService _inputService;
        private Vector2 _axis;

        private void Awake()
        {
            _inputService = DiContainer.Container.Get<IInputService>();
        }

        private void Update()
        {
            _axis = _inputService.Axis;

            animator.SetFloat(Horizontal, _axis.x);
            animator.SetFloat(Vertical, _axis.y);
            animator.SetFloat(Speed, _axis.sqrMagnitude);
        }

        private void FixedUpdate()
        {
            body2D.MovePosition(body2D.position + _axis * (speed * Time.fixedDeltaTime));
        }
    }
}