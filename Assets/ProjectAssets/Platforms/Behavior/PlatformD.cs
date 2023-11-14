using UnityEngine;

namespace ProjectAssets.Platforms.Behavior
{
    public class PlatformD : Platform
    {
        [SerializeField] private ParticleSystem _tapFx;
        [SerializeField] private Transform _tapPos;
        
        private void OnEnable()
        {
            UpRightTransit = false;
            DownLeftTransit = false;
            UpLeftTransit = false;
            DownRightTransit = false;
        }
        
        public override void AnimRotate()
        {
        
        }
    }
}
