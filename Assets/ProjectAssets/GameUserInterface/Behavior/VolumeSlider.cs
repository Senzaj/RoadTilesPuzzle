using ProjectAssets.Saves.Behavior;
using UnityEngine;
using UnityEngine.UI;

namespace ProjectAssets.GameUserInterface.Behavior
{
    public abstract class VolumeSlider : MonoBehaviour
    {
        [SerializeField] protected ParamsSaves _saves;
        [SerializeField] protected Slider _slider;
        [SerializeField] protected float _maxValue;

        private void Awake() => _slider.onValueChanged.AddListener(Change);

        private void OnDisable() => _slider.onValueChanged.RemoveListener(Change);
        
        protected abstract void Change(float newValue);
    }
}
