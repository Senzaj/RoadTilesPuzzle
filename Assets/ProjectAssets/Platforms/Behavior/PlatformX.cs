namespace ProjectAssets.Platforms.Behavior
{
    public class PlatformX : Platform
    {
        private void OnEnable()
        {
            UpRightTransit = true;
            DownLeftTransit = true;
            UpLeftTransit = true;
            DownRightTransit = true;
        }

        public override void AnimRotate()
        {
            
        }
    }
}
