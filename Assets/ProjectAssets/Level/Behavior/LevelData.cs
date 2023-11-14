using System;
using ProjectAssets.Car.Behavior;
using ProjectAssets.Platforms.Behavior;
using UnityEngine;

namespace ProjectAssets.Level.Behavior
{
    public class LevelData : MonoBehaviour
    {
        [SerializeField] private Platform[] _platforms;

        public event Action Complete;
        
        private CarMover _car;
        
        public void SetData(InputController inputController, CarMover car)
        {
            _car = car;

            foreach (var platform in _platforms)
            {
                if (platform.IsStart)
                {
                    platform.DisableCollider();
                    _car.SetPosition(platform);
                }
            }
            
            inputController.SetData(_platforms, _car);

            _car.Finished += OnCarFinished;
        }

        private void OnDisable()
        {
            _car.Finished -= OnCarFinished;
        }

        private void OnCarFinished()
        {
            Complete?.Invoke();
        }
    }
}
