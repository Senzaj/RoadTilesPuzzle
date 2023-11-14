using UnityEngine;

namespace ProjectAssets.Platforms.Behavior
{
    public class PlatformV : Platform
    {
        [SerializeField] private Sprite _downLeft_upLeft;
        [SerializeField] private Sprite _upLeft_upRight;
        [SerializeField] private Sprite _upRight_downRight;
        [SerializeField] private Sprite _downRight_downLeft;

        [SerializeField] private bool _isDownLeft_upLeft;
        [SerializeField] private bool _isUpLeft_upRight;
        [SerializeField] private bool _isUpRight_downRight;
        [SerializeField] private bool _isDownRight_downLeft;

        private void OnEnable()
        {
            if (_isDownLeft_upLeft)
            {
                DownLeftTransit = true;
                UpLeftTransit = true;
                UpRightTransit = false;
                DownRightTransit = false;
            }
            else if (_isUpLeft_upRight)
            {
                UpLeftTransit = true;
                UpRightTransit = true;
                DownLeftTransit = false;
                DownRightTransit = false;
            }
            else if (_isUpRight_downRight)
            {
                DownRightTransit = true;
                UpRightTransit = true;
                UpLeftTransit = false;
                DownLeftTransit = false;
            }
            else if (_isDownRight_downLeft)
            {
                DownLeftTransit = true;
                DownRightTransit = true;
                UpLeftTransit = false;
                UpRightTransit = false;
            }
        }

        public override void AnimRotate()
        {
            if (_isDownLeft_upLeft)
            {
                SwitchUpLeftToUpRightMode();
            }
            else if (_isUpLeft_upRight)
            {
                SwitchUpRightToDownRightMode();
            }
            else if (_isUpRight_downRight)
            {
                SwitchDownRightToDownLeftMode();
            }
            else if (_isDownRight_downLeft)
            {
                SwitchDownLeftToUpLeftMode();
            }
        }

        private void SwitchDownLeftToUpLeftMode()
        {
            _isDownLeft_upLeft = true;
            _isUpLeft_upRight = false;
            _isUpRight_downRight = false;
            _isDownRight_downLeft = false;
            
            DownLeftTransit = true;
            UpLeftTransit = true;
            UpRightTransit = false;
            DownRightTransit = false;

            _spriteRenderer.sprite = _downLeft_upLeft;
        }
        
        private void SwitchUpLeftToUpRightMode()
        {
            _isDownLeft_upLeft = false;
            _isUpLeft_upRight = true;
            _isUpRight_downRight = false;
            _isDownRight_downLeft = false;
            
            UpLeftTransit = true;
            UpRightTransit = true;
            DownLeftTransit = false;
            DownRightTransit = false;

            _spriteRenderer.sprite = _upLeft_upRight;
        }
        
        private void SwitchUpRightToDownRightMode()
        {
            _isDownLeft_upLeft = false;
            _isUpLeft_upRight = false;
            _isUpRight_downRight = true;
            _isDownRight_downLeft = false;
            
            DownRightTransit = true;
            UpRightTransit = true;
            UpLeftTransit = false;
            DownLeftTransit = false;

            _spriteRenderer.sprite = _upRight_downRight;
        }
        
        private void SwitchDownRightToDownLeftMode()
        {
            _isDownLeft_upLeft = false;
            _isUpLeft_upRight = false;
            _isUpRight_downRight = false;
            _isDownRight_downLeft = true;
            
            DownLeftTransit = true;
            DownRightTransit = true;
            UpLeftTransit = false;
            UpRightTransit = false;

            _spriteRenderer.sprite = _downRight_downLeft;
        }
    }
}
