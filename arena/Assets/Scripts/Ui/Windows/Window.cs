using System;
using UnityEngine;

namespace Ui.Windows
{
    public abstract class Window : MonoBehaviour
    {
        private Action _onWindowClosed;

        protected virtual void Close()
        {
            _onWindowClosed?.Invoke();
            Destroy(gameObject);
        }

        public Action OnWindowClosed
        {
            get => _onWindowClosed;
            set => _onWindowClosed = value;
        }
    }
}