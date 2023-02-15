using System.Collections;
using UnityEngine;

namespace Ui
{
    public class LoadingCurtain : MonoBehaviour
    {
        [SerializeField] private CanvasGroup canvasGroup;

        private void Awake()
        { 
            DontDestroyOnLoad(this);
        }

        public void Show()
        {
            gameObject.SetActive(true);
            canvasGroup.alpha = 1;
        }
    
        public void Hide()
        { 
            StartCoroutine(DoFadeIn());
        }

        private IEnumerator DoFadeIn()
        {
            while (canvasGroup.alpha > 0)
            {
                canvasGroup.alpha -= 0.03f;
                yield return new WaitForSeconds(0.03f);
            }
      
            gameObject.SetActive(false);
        }
    }
}