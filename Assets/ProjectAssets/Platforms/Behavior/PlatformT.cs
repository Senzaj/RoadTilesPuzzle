using UnityEngine;

namespace ProjectAssets.Platforms.Behavior
{
    public class PlatformT : Platform
    {
        [SerializeField] private Sprite _downLeft;
        [SerializeField] private Sprite _upLeft;
        [SerializeField] private Sprite _upRight;
        [SerializeField] private Sprite _downRight;

        [SerializeField] private bool _isDownLeft;
        [SerializeField] private bool _isUpLeft;
        [SerializeField] private bool _isUpRight;
        [SerializeField] private bool _isDownRight;

        private void OnEnable()
        {
            if (_isDownLeft)
            {
                DownLeftTransit = true;
                UpLeftTransit = true;
                UpRightTransit = false;
                DownRightTransit = true;
            }
            else if (_isUpLeft)
            {
                DownLeftTransit = true;
                UpLeftTransit = true;
                UpRightTransit = true;
                DownRightTransit = false;
            }
            else if (_isUpRight)
            {
                DownLeftTransit = false;
                UpLeftTransit = true;
                UpRightTransit = true;
                DownRightTransit = true;
            }
            else if (_isDownRight)
            {
                DownLeftTransit = true;
                UpLeftTransit = false;
                UpRightTransit = true;
                DownRightTransit = true;
            }
        }

        public override void AnimRotate()
        {
            if (_isDownLeft)
            {
                SwitchUpLeftMode();
            }
            else if (_isUpLeft)
            {
                SwitchUpRightMode();
            }
            else if (_isUpRight)
            {
                SwitchDownRightMode();
            }
            else if (_isDownRight)
            {
                SwitchDownLeftMode();
            }
        }

        private void SwitchDownLeftMode()
        {
            _isDownLeft = true;
            _isUpLeft = false;
            _isUpRight = false;
            _isDownRight = false;
            
            DownLeftTransit = true;
            UpLeftTransit = true;
            UpRightTransit = false;
            DownRightTransit = true;

            _spriteRenderer.sprite = _downLeft;
        }
        
        private void SwitchUpLeftMode()
        {
            _isDownLeft = false;
            _isUpLeft = true;
            _isUpRight = false;
            _isDownRight = false;
            
            DownLeftTransit = true;
            UpLeftTransit = true;
            UpRightTransit = true;
            DownRightTransit = false;

            _spriteRenderer.sprite = _upLeft;
        }
        
        private void SwitchUpRightMode()
        {
            _isDownLeft = false;
            _isUpLeft = false;
            _isUpRight = true;
            _isDownRight = false;
            
            DownLeftTransit = false;
            UpLeftTransit = true;
            UpRightTransit = true;
            DownRightTransit = true;

            _spriteRenderer.sprite = _upRight;
        }
        
        private void SwitchDownRightMode()
        {
            _isDownLeft = false;
            _isUpLeft = false;
            _isUpRight = false;
            _isDownRight = true;
            
            DownLeftTransit = true;
            UpLeftTransit = false;
            UpRightTransit = true;
            DownRightTransit = true;

            _spriteRenderer.sprite = _downRight;
        }
    }
}
