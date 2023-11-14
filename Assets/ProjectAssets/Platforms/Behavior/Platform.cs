using System;
using UnityEngine;

namespace ProjectAssets.Platforms.Behavior
{
    public abstract class Platform : MonoBehaviour
    {
        public Transform Target;

        public Platform UpRightP;
        public Platform UpLeftP;
        public Platform DownRightP;
        public Platform DownLeftP;
        
        public bool UpRightTransit;
        public bool UpLeftTransit;
        public bool DownRightTransit;
        public bool DownLeftTransit;

        public bool IsStart;
        public bool IsFinish;
        public bool IsTrap;
        public bool IsRandomizingOnJump;
        public bool IsRandomizingOnClick;

        [SerializeField] protected Animator _animator;
        [SerializeField] protected SpriteRenderer _spriteRenderer;
        [SerializeField] protected Collider2D _collider;
        [SerializeField] private Platform[] _randomizedPlatforms;

        public event Action<Platform> OnClick;

        private bool _disabled;

        private void OnMouseDown()
        {
            if (_disabled == false)
                OnClick?.Invoke(this);
        }

        public void Rotate()
        {
            DisableCollider();
            _animator.Play("Rotate");
        }

        public void OnRotated()
        {
            _animator.Play("Idle");
            EnableCollider();
        }

        public abstract void AnimRotate();

        public void Disappear()
        {
            _animator.Play("Disappear");
        }

        private void OnDisappeared()
        {
            _spriteRenderer.color = Color.clear;
            _disabled = true;
        }
        
        public void Randomize()
        {
            foreach (var plat in _randomizedPlatforms)
                plat.Rotate();
        }
        
        public void DisableCollider()
        {
            _collider.enabled = false;
        }

        public void EnableCollider()
        {
            _collider.enabled = true;
        }
    }
}
