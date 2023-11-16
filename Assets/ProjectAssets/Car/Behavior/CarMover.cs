using System;
using System.Collections;
using DG.Tweening;
using ProjectAssets.Platforms.Behavior;
using UnityEngine;

namespace ProjectAssets.Car.Behavior
{
    public class CarMover : MonoBehaviour
    {
        [SerializeField] private Animator _animator;
        [SerializeField] private ParticleSystem _jump0Fx;
        [SerializeField] private ParticleSystem _jump1Fx;
        
        public Platform CurrentPlatform;

        public event Action Finished;
        
        public bool CanMove { get; private set; }
        
        public void SetPosition(Platform newPlatform)
        {
            transform.position = newPlatform.Target.position;
            CurrentPlatform = newPlatform;
            CanMove = true;
        }

        public void JumpTo(Platform newPlatform)
        {
            CanMove = false;
            _animator.Play("Jump");
            Instantiate(_jump0Fx, transform.position, Quaternion.Euler(-45,0,0));
            
            transform.localScale = newPlatform.transform.position.x > transform.position.x ? new Vector3(-1, 1, 1) : new Vector3(1, 1, 1);
            
            transform.DOMove( newPlatform.Target.position, 0.5f);
            CurrentPlatform = newPlatform;

            if (newPlatform.IsRandomizingOnJump)
                StartCoroutine(Randomize(newPlatform));
        }

        private IEnumerator Randomize(Platform platform)
        {
            yield return new WaitForSeconds(0.3f);
            platform.Randomize();
        }

        private void OnJumped()
        {
            _animator.Play("Idle");
            Instantiate(_jump1Fx, transform.position, Quaternion.Euler(-45,0,0));
            
            if (CurrentPlatform.IsFinish)
                Finished?.Invoke();
            else
                CanMove = true;
        }
    }
}
