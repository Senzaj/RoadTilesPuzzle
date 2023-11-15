using ProjectAssets.Car.Behavior;
using ProjectAssets.Platforms.Behavior;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace ProjectAssets.Level.Behavior
{
    public class InputController : MonoBehaviour
    {
        [SerializeField] private Button _modeSwitcher;
        [SerializeField] private TMP_Text _carModeT;
        [SerializeField] private TMP_Text _roadsModeT;
        [SerializeField] private ParticleSystem _hitFx;
        
        private Platform[] _platforms;
        private CarMover _car;

        public bool CanPlay;
        public bool IsCarMode;

        public void SetData(Platform[] platforms, CarMover carMover)
        {
            SetRoadsMode();
            
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
            if (IsCarMode)
                SetRoadsMode();
            else
                SetCarMode();
        }

        private void SetCarMode()
        {
            IsCarMode = true;
            _roadsModeT.enabled = false;
            _carModeT.enabled = true;
        }

        private void SetRoadsMode()
        {
            IsCarMode = false;
            _carModeT.enabled = false;
            _roadsModeT.enabled = true;
        }
        
        public void OnPlatformClick(Platform platform)
        {
            if (CanPlay)
            {
                Instantiate(_hitFx, platform.transform.position, Quaternion.identity);
                
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
