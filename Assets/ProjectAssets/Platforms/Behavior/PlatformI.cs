using UnityEngine;

namespace ProjectAssets.Platforms.Behavior
{
    public class PlatformI : Platform
    {
        [SerializeField] private Sprite _upRight_downLeft;
        [SerializeField] private Sprite _upLeft_downRight;
        [SerializeField] private bool _isUpRight_downLeft;

        private void OnEnable()
        {
            if (_isUpRight_downLeft)
            {
                UpRightTransit = true;
                DownLeftTransit = true;
            }
            else
            {
                UpLeftTransit = true;
                DownRightTransit = true;
            }
        }

        public override void AnimRotate()
        {
            if (_isUpRight_downLeft)
                SwitchUpLeftToDownRightMode();
            else
                SwitchUpRightToDownLeftMode();
        }

        private void SwitchUpRightToDownLeftMode()
        {
            _isUpRight_downLeft = true;
            
            UpLeftTransit = false;
            DownRightTransit = false;
            
            UpRightTransit = true;
            DownLeftTransit = true;

            _spriteRenderer.sprite = _upRight_downLeft;
        }

        private void SwitchUpLeftToDownRightMode()
        {
            _isUpRight_downLeft = false;
            
            UpRightTransit = false;
            DownLeftTransit = false;
            
            UpLeftTransit = true;
            DownRightTransit = true;

            _spriteRenderer.sprite = _upLeft_downRight;
        }
    }
}
