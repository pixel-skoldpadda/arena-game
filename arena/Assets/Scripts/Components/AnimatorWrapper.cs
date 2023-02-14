using UnityEngine;

namespace Components
{
    /**
     * Класс обертка над Unity классом Animator. Необходим для более удобного использования.
     */
    [RequireComponent(typeof(Animator))]
    public class AnimatorWrapper : MonoBehaviour
    {
        private static readonly int Horizontal = Animator.StringToHash("Horizontal");
        private static readonly int Vertical = Animator.StringToHash("Vertical");
        private static readonly int Speed = Animator.StringToHash("Speed");
        private static readonly int AttackTrigger = Animator.StringToHash("Attack");
        
        [SerializeField] private Animator animator;
        
        public void SetAxis(Vector2 axis)
        {
            animator.SetFloat(Horizontal, axis.x);
            animator.SetFloat(Vertical, axis.y);
            animator.SetFloat(Speed, axis.magnitude);
        }

        public void PLayAttack()
        {
            animator.SetTrigger(AttackTrigger);
        }
    }
}