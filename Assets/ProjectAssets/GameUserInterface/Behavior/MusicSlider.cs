using UnityEngine;

namespace ProjectAssets.GameUserInterface.Behavior
{
    public class MusicSlider : VolumeSlider
    {
        [SerializeField] private AudioSource _music;
        
        private void OnEnable()
        {
            _slider.maxValue = _maxValue;
            _slider.value = _saves.GetMusicVolume();
            _music.volume = _slider.value;
        }

        protected override void Change(float newValue)
        {
            _music.volume = newValue;
            _saves.SetMusicVolume(newValue);
        }
    }
}
