using System.Collections;
using TMPro;
using UnityEngine;

namespace Components
{
    public class FloatingText : MonoBehaviour
    {
        [SerializeField] private float destroyTime;
        [SerializeField] private TextMeshPro textMesh;
        [SerializeField] private Animator animator;

        public void Play(string text)
        {
            textMesh.text = text;
            animator.enabled = true;
            StartCoroutine(DestroyTime());
        }
        
        private IEnumerator DestroyTime()
        {
            yield return new WaitForSeconds(destroyTime);
            Destroy(gameObject);
        }
    }
}