using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace ProjectAssets.GameUserInterface.Behavior
{
    public class LevelButton : MonoBehaviour
    {
        [SerializeField] private Image _image;
        [SerializeField] private TMP_Text _levelNumberT;
        [SerializeField] private TMP_Text _completeT;
        [SerializeField] private TMP_Text _notCompleteT;
        [SerializeField] private Color _enabledColor;
        [SerializeField] private Color _disabledColor;
        
        public Button ButtonLevel;
        
        public void SetNumber(int number)
        {
            _levelNumberT.text = number.ToString();
        }

        public void Completed()
        {
            _completeT.enabled = true;
            _notCompleteT.enabled = false;
        }

        public void NotCompleted()
        {
            _completeT.enabled = false;
            _notCompleteT.enabled = true;
        }

        public void Enable()
        {
            _image.color = _enabledColor;
        }

        public void Disable()
        {
            _image.color = _disabledColor;
        }
    }
}
