using UnityEngine;
using UnityEngine.UI;

namespace ProjectAssets.GameUserInterface.Behavior
{
    public class List : MonoBehaviour
    {
        [SerializeField] private Animator _animator;
        [SerializeField] private Button[] _buttonsToOpen;
        [SerializeField] private Button[] _buttonsToClose;

        private void Awake()
        {
            CloseTransition();
            TryAddListeners();
        }
        
        private void OnDisable() => TryRemoveListeners();
        
        public void Open() => _animator.Play("Open0");
        
        public void Close() => _animator.Play("Close0");
        
        public void OpenTransition() => _animator.Play("Open1");

        public void CloseTransition() => _animator.Play("Close1");

        private void TryAddListeners()
        {
            if (_buttonsToOpen != null)
                foreach (Button btn in _buttonsToOpen)
                    btn.onClick.AddListener(Open);

            if (_buttonsToClose != null)
                foreach (Button btn in _buttonsToClose)
                    btn.onClick.AddListener(Close);
        }

        private void TryRemoveListeners()
        {
            if (_buttonsToOpen != null)
                foreach (Button btn in _buttonsToOpen)
                    btn.onClick.RemoveListener(Open);

            if (_buttonsToClose != null)
                foreach (Button btn in _buttonsToClose)
                    btn.onClick.RemoveListener(Close);
        }
    }
}
