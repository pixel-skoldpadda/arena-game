﻿using Infrastructure.DI.Services.Game;
using UnityEngine;
using Vector2 = UnityEngine.Vector2;

namespace Components.Movement
{
    [RequireComponent(typeof(Rigidbody2D))]
    public abstract class Movement : MonoBehaviour
    {
        [SerializeField] private Rigidbody2D body2D;
        [SerializeField] private AnimatorWrapper animator;

        private bool _moving;
        private Vector2 _axis;
        private IGameManager _gameManager;
        
        protected float CurrentSpeed;

        protected abstract Vector2 GetAxis();

        protected void Construct(IGameManager gameManager)
        {
            _gameManager = gameManager;
            _gameManager.OnGamePaused += Pause;
            _gameManager.OnGameResumed += Resume;
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
            _gameManager.OnGamePaused -= Pause;
            _gameManager.OnGameResumed -= Resume;
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