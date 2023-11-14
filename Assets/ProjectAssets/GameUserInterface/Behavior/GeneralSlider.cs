using UnityEngine;

namespace ProjectAssets.GameUserInterface.Behavior
{
    public class GeneralSlider : VolumeSlider
    {
        private void OnEnable()
        {
            _slider.maxValue = _maxValue;
            _slider.value = _saves.GetGeneralVolume();
            AudioListener.volume = _slider.value;
        }

        protected override void Change(float newValue)
        {
            AudioListener.volume = newValue;
            _saves.SetGeneralVolume(newValue);
        }
    }
}
