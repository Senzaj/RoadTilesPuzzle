using ProjectAssets.Car.Behavior;
using ProjectAssets.Platforms.Behavior;
using UnityEngine;
using UnityEngine.UI;

namespace ProjectAssets.Level.Behavior
{
    public class InputController : MonoBehaviour
    {
        [SerializeField] private Button _modeSwitcher;
        
        private Platform[] _platforms;
        private CarMover _car;

        public bool CanPlay;
        public bool IsCarMode;

        public void SetData(Platform[] platforms, CarMover carMover)
        {
            _car = carMover;
            _platforms = platforms;
            
            foreach (var platform in _platforms)
                platform.OnClick += OnPlatformClick;
            
            _modeSwitcher.onClick.AddListener(SwitchMode);
        }

        private void OnDisable()
        {
            foreach (var platform in _platforms)
                platform.OnClick -= OnPlatformClick;
            
            _modeSwitcher.onClick.RemoveListener(SwitchMode);
        }

        private void SwitchMode()
        {
            IsCarMode = !IsCarMode;
        }

        public void OnPlatformClick(Platform platform)
        {
            if (CanPlay)
            {
                if (IsCarMode)
                {
                    Platform currentPlatform = _car.CurrentPlatform;

                    if (_car.CanMove)
                    {
                        if (currentPlatform.UpLeftP == platform && currentPlatform.UpLeftTransit &&
                            platform.DownRightTransit)
                        {
                            MoveCar(currentPlatform, platform);
                        }
                        else if (currentPlatform.UpRightP == platform && currentPlatform.UpRightTransit &&
                                 platform.DownLeftTransit)
                        {
                            MoveCar(currentPlatform, platform);
                        }
                        else if (currentPlatform.DownRightP == platform && currentPlatform.DownRightTransit &&
                                 platform.UpLeftTransit)
                        {
                            MoveCar(currentPlatform, platform);
                        }
                        else if (currentPlatform.DownLeftP == platform && currentPlatform.DownLeftTransit &&
                                 platform.UpRightTransit)
                        {
                            MoveCar(currentPlatform, platform);
                        }
                    }
                }
                else
                {
                    platform.Rotate();
                    
                    if (platform.IsRandomizingOnClick)
                        platform.Randomize();
                }
            }
        }

        private void MoveCar(Platform currentPlatform, Platform nextPlatform)
        {
            if (currentPlatform.IsTrap)
                currentPlatform.Disappear();
            else
                currentPlatform.EnableCollider();
                
            nextPlatform.DisableCollider();
            _car.JumpTo(nextPlatform);
            
        }
    }
}
